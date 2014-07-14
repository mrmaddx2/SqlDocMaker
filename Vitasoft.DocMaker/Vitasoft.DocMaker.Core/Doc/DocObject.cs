using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.pdf.qrcode;
using Vitasoft.DocMaker.Core.SQLWorker;
using Color = System.Drawing.Color;
using Spd = Vitasoft.DocMaker.Core.Generated.SpdModelClasses;

namespace Vitasoft.DocMaker.Core
{
    public abstract class DocObject
    {
        public Doc Doc { get; private set; } 
        public List<SqlObjectParameter> Parameters { get; private set; }
        public SqlObject SqlObject { get; private set; }
        public Logger _logger;
        public abstract OutputSet OutputDataSet { get; protected set; }


        public DocObject(SqlObject sqlObject, DbSchemaReader dbSchemaReader, Logger logger = null, Spd.Model1 model = null)
        {
            this._logger = logger;
            this.SqlObject = sqlObject;

            string body = dbSchemaReader.GetObjectDefinition(this.SqlObject.name, logger);

            this.Parameters = dbSchemaReader.GetParameters(this.SqlObject.name); 

            this.Doc = GetDocsFromBody(body);

            FillDocParameters(model);

            if (this._logger != null)
            {
                string nonComments = string.Join(Environment.NewLine,
                    this.Doc.Params.Where(x => string.IsNullOrWhiteSpace(x.Comment)).Select(x => x.Name));

                if (!string.IsNullOrWhiteSpace(nonComments))
                {
                    this._logger.WriteWarning(this.SqlObject.name + ": Не найдены комментарии для параметров " + nonComments);
                }
            }
        }

        private bool FillDocParameters(Spd.Model1 model = null)
        {
            bool result = false;

            this.Doc.Params =
                this.Doc.Params.Concat(this.Parameters.Where(
                    x =>
                        !this.Doc.Params.Any(
                            y =>
                                string.Equals(y.Name, x.PARAMETER_NAME, StringComparison.InvariantCultureIgnoreCase)))
                    .Select(x => DocParam.CreateNew(x.PARAMETER_NAME, x.FullDataType, string.Empty))).ToArray();

            List<string> baseOnObjects = this.Doc.BasedOnObjects.Split(Convert.ToChar("|")).ToList();

            if (model != null && baseOnObjects.Count > 0)
            {
                foreach (DocParam docParam in this.Doc.Params.Where(x => string.IsNullOrWhiteSpace(x.Comment)))
                {
                    string commentString = string.Empty;

                    foreach (string currentObject in baseOnObjects)
                    {
                        Spd.View view = model.Views.FirstOrDefault(
                            x => string.Equals(x.Name, currentObject, StringComparison.InvariantCultureIgnoreCase));

                        if (view != null)
                        {
                            var viewColumn =
                                view.Columns.ViewColumn.FirstOrDefault(x => string.Equals("@" + x.Name, docParam.Name,
                                    StringComparison.InvariantCultureIgnoreCase));

                            if (viewColumn != null)
                            {
                                commentString = viewColumn.Comment;
                            }
                        }
                        else
                        {
                            Spd.Table table =
                                model.Tables.FirstOrDefault(
                                    x =>
                                        string.Equals(x.Name, currentObject, StringComparison.InvariantCultureIgnoreCase));

                            if (table != null)
                            {
                                var tablecolumn =
                                    table.Columns.Column.FirstOrDefault(x => string.Equals("@" + x.Name, docParam.Name,
                                        StringComparison.InvariantCultureIgnoreCase));

                                if (tablecolumn != null)
                                {
                                    commentString = tablecolumn.Comment;
                                }
                            }
                        }

                        docParam.Comment = commentString;

                        if (!string.IsNullOrWhiteSpace(commentString))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public string GetOutputFieldComment(OutputField outputField)
        {
            DocOutput_DatasetField firstOrDefault = null;

            if (this.Doc != null && this.Doc.Params != null)
            {
                firstOrDefault = this.Doc.Output_Dataset.Fields.FirstOrDefault(
                x =>
                    string.Equals(x.Name, outputField.Name,
                        StringComparison.InvariantCultureIgnoreCase));
            }

            return (firstOrDefault != null ? firstOrDefault.Comment : string.Empty);
        }

        public virtual List<DocSections> SectionsList
        {
            get
            {
                List<DocSections> result = new List<DocSections>();

                if (this.Doc != null && !string.IsNullOrWhiteSpace(this.Doc.DocSection))
                {
                    var splittedDocSections = this.Doc.DocSection.Split(Convert.ToChar("|"));

                    for (int i = 0; i <= splittedDocSections.Count() - 1; i++)
                    {
                        string currentSectionArray = splittedDocSections[i];

                        List<int?> SortSections = new List<int?>();

                        if (!string.IsNullOrWhiteSpace(this.Doc.SortSection) && this.Doc.SortSection.Split(Convert.ToChar("|")).Count() >= i + 1)
                        {
                            int testInt;

                            foreach (string currentSortSection in this.Doc.SortSection.Split(Convert.ToChar("|"))[i].Split(new char[]{Convert.ToChar(@"\"), Convert.ToChar("/")}))
                            {
                                if (!string.IsNullOrWhiteSpace(currentSortSection) && int.TryParse(currentSortSection, out testInt))
                                {
                                    SortSections.Add(testInt);
                                }
                                else
                                {
                                    SortSections.Add(null);
                                }
                            }
                        }

                        DocSections docSections = new DocSections();

                        result.Add(docSections);

                        List<string> sections = (string.IsNullOrWhiteSpace(currentSectionArray)
                            ? Doc.DefaultSection + @"\" + this.SqlObject.name
                            : currentSectionArray)
                            .Split(new char[] {Convert.ToChar(@"\"), Convert.ToChar("/")}).ToList();

                        for (int j = 0; j <= sections.Count() - 1; j++)
                        {
                            string currentSection = sections[j];

                            docSections.Add(new DocSection(currentSection.Trim(), (SortSections.Count >= j + 1 ? SortSections[j] : null)));
                        }
                    }
                }
                else
                {
                    result = new List<DocSections>();

                    DocSections docSections = new DocSections();
                    docSections.AddRange((Doc.DefaultSection + @"\" + this.SqlObject.name).Split(Convert.ToChar(@"\")).Select(x => new DocSection(x)));

                    result.Add(docSections);
                }

                return result;
            }
        }

        protected bool FillDocDataSets(Spd.Model1 model = null)
        {
            bool result = false;

            if (this.Doc.Output_Dataset == null)
            {
                this.Doc.Output_Dataset = new DocOutput_Dataset();
            }

            var outputFields =
                this.OutputDataSet.OutputFields.Where(
                    x =>
                        !this.Doc.Output_Dataset.Fields.Any(
                            y => string.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrWhiteSpace(y.Comment)));

            if (model != null)
            {
                foreach (OutputField outputField in outputFields)
                {
                    string commentString = string.Empty;

                    if (!string.IsNullOrWhiteSpace(outputField.SourceObjectName) && !string.IsNullOrWhiteSpace(outputField.SourceFieldName))
                    {
                        Spd.View view =
                            model.Views.FirstOrDefault(
                                x =>
                                    string.Equals(x.Name, outputField.SourceObjectName,
                                        StringComparison.InvariantCultureIgnoreCase));



                        if (view != null)
                        {
                            var viewColumn = view.Columns.ViewColumn.FirstOrDefault(
                                x =>
                                    string.Equals(x.Name, outputField.SourceFieldName,
                                        StringComparison.InvariantCultureIgnoreCase));

                            if (viewColumn != null)
                            {
                                commentString = viewColumn.Comment;
                            }
                            else
                            {
                                if (this._logger != null)
                                {
                                    this._logger.LogError("Не найдено поле " + outputField.SourceFieldName + " во вьюхе " + outputField.SourceObjectName);
                                }
                            }
                        }
                        else
                        {
                            Spd.Table table =
                                model.Tables.FirstOrDefault(
                                    x =>
                                        string.Equals(x.Name, outputField.SourceObjectName,
                                            StringComparison.InvariantCultureIgnoreCase));

                            if (table != null)
                            {
                                var tableColumn = table.Columns.Column.FirstOrDefault(
                                    x =>
                                        string.Equals(x.Name, outputField.SourceFieldName,
                                            StringComparison.InvariantCultureIgnoreCase));

                                if (tableColumn != null)
                                {
                                    commentString = tableColumn.Comment;
                                }
                                else
                                {
                                    if (this._logger != null)
                                    {
                                        this._logger.LogError("Не найдено поле " + outputField.SourceFieldName + " в таблице " + outputField.SourceObjectName);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        List<string> baseOnObjects = this.Doc.BasedOnObjects.Split(Convert.ToChar("|")).ToList();

                        foreach (string currentObject in baseOnObjects)
                        {
                            Spd.View view = model.Views.FirstOrDefault(
                            x => string.Equals(x.Name, currentObject, StringComparison.InvariantCultureIgnoreCase));

                            if (view != null)
                            {
                                var viewColumn =
                                    view.Columns.ViewColumn.FirstOrDefault(
                                        x =>
                                            string.Equals(x.Name, outputField.Name,
                                                StringComparison.InvariantCultureIgnoreCase));

                                if (viewColumn != null)
                                {
                                    commentString = viewColumn.Comment;
                                }
                            }
                            else
                            {
                                Spd.Table table =
                                    model.Tables.FirstOrDefault(
                                        x =>
                                            string.Equals(x.Name, currentObject, StringComparison.InvariantCultureIgnoreCase));

                                if (table != null)
                                {
                                    var tablecolumn =
                                        table.Columns.Column.FirstOrDefault(x => string.Equals(x.Name, outputField.Name,
                                            StringComparison.InvariantCultureIgnoreCase));

                                    if (tablecolumn != null)
                                    {
                                        commentString = tablecolumn.Comment;
                                    }
                                }
                            }


                            if (!string.IsNullOrWhiteSpace(commentString))
                            {
                                break;
                            }
                        }
                    }

                    outputField.Comment = commentString;
                }
            }

            if (outputFields.Any(x => !string.IsNullOrWhiteSpace(x.Comment)))
            {
                result = true;
            }

            this.Doc.Output_Dataset.Fields =
                this.Doc.Output_Dataset.Fields.Concat(
                    outputFields.Select(x => DocOutput_DatasetField.CreateNew(x.Name, x.DataTypeName, x.Comment)))
                    .ToArray();

            return result;
        }

        public virtual object UploadToDoc(IDocUploader docUploader, string sectionName)
        {
            try
            {
                var section =
                docUploader.ForceSection(string.IsNullOrWhiteSpace(sectionName)
                    ? Doc.DefaultSection + @"\" + this.SqlObject.name
                    : sectionName);

                var summaryObject = docUploader.AddSummaryInfo(section, this, Color.Gainsboro);

                object paramsObject = null;

                if (this.Parameters.Count > 0)
                {
                    paramsObject = docUploader.AddParametersInfo(summaryObject, this, Color.Gainsboro, Color.Transparent);
                }

                if (paramsObject != null)
                {
                    return paramsObject;
                }
                else
                {
                    return summaryObject;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Выгрузка в документ объекта " + this.SqlObject.name, exception);
            }
            
        }

        private static Doc GetDocsFromBody(string inputString)
        {
            try
            {
                Doc doc = null;

                var matches = Regex.Matches(inputString, "<Doc>?(\n|.)*</Doc>");

                if (matches.Count > 1)
                {
                    throw new Exception("XML с документацией больше одного!");
                }
                else if (matches.Count == 1)
                {
                    using (StringReader reader = new StringReader(matches[0].Value))
                    {

                        //throw new Exception(reader.ReadToEnd());
                        XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Doc));

                        doc = (Doc)_xmlSerializer.Deserialize(reader);

                        if (doc.Output_Dataset == null)
                        {
                            doc.Output_Dataset = new DocOutput_Dataset();
                        }

                        if (doc.Output_Dataset.Fields == null)
                        {
                            doc.Output_Dataset.Fields = new DocOutput_DatasetField[0];
                        }

                        if (doc.Params == null)
                        {
                            doc.Params = new DocParam[0];
                        }
                    }
                }
                else
                {
                    doc = Doc.CreateNew();
                }

                return doc;
            }
            catch (Exception exception)
            {
                Exception tmpException = new Exception(inputString, exception);

                throw new Exception("Ошибка при извлечении докуменатции из тела sql объекта", tmpException);
            }
        }

        public string GetFileName(InputXmlArguments xmlArguments)
        {
            Regex regex = new Regex(@"(\:|\*|\?|\""\<\>|\|)");

            string result = string.Empty;

            if (this.Doc == null || string.IsNullOrWhiteSpace(this.Doc.DocName))
            {
                result += xmlArguments.DefFileName;
            }
            else
            {
                result += this.Doc.DocName;
            }

            if (xmlArguments.OneSectionPerFile)
            {
                result += @"\";

                if (this.Doc == null || string.IsNullOrWhiteSpace(this.Doc.DocSection))
                {
                    result += Doc.DefaultSection + @"\" + this.SqlObject.name;
                }
                else
                {
                    result += regex.Replace(this.Doc.DocSection.Split(Convert.ToChar("|")).First(), "");
                }
            }

            return result;
        }

        public string GetParamComment(SqlObjectParameter sqlObjectParameter)
        {
            DocParam firstOrDefault = null;

            if (this.Doc != null && this.Doc.Params != null)
            {
                firstOrDefault = this.Doc.Params.FirstOrDefault(
                x =>
                    string.Equals(x.Name, sqlObjectParameter.PARAMETER_NAME,
                        StringComparison.InvariantCultureIgnoreCase));
            }

            return (firstOrDefault != null ? firstOrDefault.Comment : string.Empty);
        }
    }
}

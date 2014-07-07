using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.Excel;
using Vitasoft.DocMaker.Core.ErrorProcessing;
using Vitasoft.DocMaker.Core.SQLWorker;
using Color = System.Drawing.Color;
using Spd = Vitasoft.DocMaker.Core.Generated.SpdModelClasses;

namespace Vitasoft.DocMaker.Core
{
    public class DocProcedure : DocObject
    {
        public OutputSet OutputDataSet { get; private set; }

        public DocProcedure(SqlObject sqlObject, DbSchemaReader dbSchemaReader, Logger logger = null, Spd.Model1 model = null, bool getOutputDataSetsByExec = false)
            : base(sqlObject, dbSchemaReader, logger, model)
        {

            var searchArea = (this.Doc != null && this.Doc.Output_Dataset != null) ? this.Doc.Output_Dataset.SearcArea : SearcAreaEnum.AUTO;

            if (searchArea == SearcAreaEnum.AUTO)
            {
                try
                {
                    this.OutputDataSet = dbSchemaReader.GetOutputDataSetsByMetadata(this);
                }
                catch (Exception exception)
                {
                    try
                    {
                        if (getOutputDataSetsByExec)
                        {
                            this.OutputDataSet = dbSchemaReader.GetOutputDataSetsByExec(this);
                        }
                        else
                        {
                            throw new Exception("Получение исходящего датасета выполнением процедуры запрещено параметрами!");
                        }
                    }
                    catch (Exception execException)
                    {
                        if (GetOutputDatasetInfoFromDoc())
                        {
                            if (this._logger != null)
                            {
                                this._logger.WriteWarning(ExceptionConverter.GetMessage(execException), true);
                                this._logger.WriteWarning(ExceptionConverter.GetMessage(new Exception("Описание датасета взято из документации", exception)), true);
                            }
                        }
                        else
                        {
                            Exception tmpException = new Exception("Невозможно изъять откуда либо информацию об исходящих датасетах объекта.", exception);

                            if (this._logger == null)
                            {
                                throw tmpException;
                            }
                            else
                            {
                                this._logger.LogError(ExceptionConverter.GetMessage(execException), true);
                                this._logger.LogError(ExceptionConverter.GetMessage(tmpException), true);
                            }
                        }
                    }


                }
            }
            else if (searchArea == SearcAreaEnum.DOCONLY)
            {
                if (!GetOutputDatasetInfoFromDoc())
                {
                    if (this._logger != null)
                    {
                        this._logger.WriteWarning("Указано получение информации о датасете из документации, но извлечь ее оттуда не удалось.", true);
                    }
                }
            }
            else if (searchArea == SearcAreaEnum.NONE)
            {
                if (this._logger != null)
                {
                    this._logger.WriteLine("Получение информации об исходящем датасете отключено настройками.", true);
                }
            }


            if (this.OutputDataSet == null)
            {
                this.OutputDataSet = new OutputSet();
            }
            else
            {
                this.FillDocDataSets(model);
            }


            if (this._logger != null)
            {
                string nonComments = string.Join(Environment.NewLine,
                    this.Doc.Output_Dataset.Fields.Where(x => string.IsNullOrWhiteSpace(x.Comment)).Select(x => x.Name));

                if (!string.IsNullOrWhiteSpace(nonComments))
                {
                    this._logger.WriteWarning(this.SqlObject.name + ": Не найдены комментарии для исходящих полей " + nonComments);
                }
            }
        }


        public bool GetOutputDatasetInfoFromDoc()
        {
            bool result = false;

            if (this.Doc != null && this.Doc.Output_Dataset != null && this.Doc.Output_Dataset.Fields.Count() > 0)
            {
                this.OutputDataSet = new OutputSet();

                OutputDataSet.OutputFields.AddRange(this.Doc.Output_Dataset.Fields.Select(x => new OutputField(x.Name, x.DataTypeName)));

                result = true;
            }

            return result;
        }


        public bool FillDocDataSets(Spd.Model1 model = null)
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

        public override List<DocSections> SectionsList
        {
            get
            {
                var result = base.SectionsList;
                /*
                foreach (var currentList in result)
                {
                    currentList.Insert(0, new DocSection("Процедуры", 1));
                }
                */
                return result;
            }
        }

        public override object UploadToDoc(IDocUploader docUploader, string sectionName)
        {
            try
            {
                var insertAfter = base.UploadToDoc(docUploader, sectionName);

                object datasetObject = null;

                if (this.OutputDataSet.OutputFields.Count > 0)
                {
                    datasetObject = docUploader.AddReturnDatasetInfo(insertAfter, this, Color.Gainsboro, Color.Transparent);
                }

                if (datasetObject != null)
                {
                    return datasetObject;
                }
                else
                {
                    return insertAfter;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Выгрузка в документ процедуры " + this.SqlObject.name, exception);
            }
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
    }
}

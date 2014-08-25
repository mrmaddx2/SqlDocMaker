using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Vitasoft.DocMaker.Core.SQLWorker;
using Color = System.Drawing.Color;

namespace Vitasoft.DocMaker.Core
{
    public class DocxUploader : IDocUploader
    {
        public NewDocDocxTemplate DocxDocument { get; private set; }

        public DocxUploader(string fullFileName)
        {
            if (!string.Equals(Path.GetExtension(fullFileName), ".docx", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception("Расширение файла должно быть .DOCX, сейчас указано: " + Path.GetExtension(fullFileName));
            }

            if (File.Exists(fullFileName))
            {
                throw new Exception("Файл с именем " + fullFileName + " уже существует!");
            }

            this.DocxDocument = new NewDocDocxTemplate(fullFileName, true);

            this.DocxDocument.Document.PackageProperties.Creator = Assembly.GetEntryAssembly().GetName().Name;
            this.DocxDocument.Document.PackageProperties.Revision = "1";
            this.DocxDocument.Document.PackageProperties.Created = DateTime.Now;

            this.DocxDocument.Document.PackageProperties.LastModifiedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }


        public void Dispose()
        {
            if (this.DocxDocument != null)
            {
                this.DocxDocument.Document.PackageProperties.Modified = DateTime.Now;
                this.DocxDocument.Dispose();
            }
        }

        public object AddSummaryInfo(object insertAfter, DocObject docObject, Color backgroundColor)
        {
            Paragraph objectNameParagraph = DocxWorker.GenerateProcNameParagraph(docObject.SqlObject.name);
            
            (insertAfter as OpenXmlElement).InsertAfterSelf(objectNameParagraph);

            Paragraph objectDescriptionParagraph =
                DocxWorker.GenerateSummaryParagraph(docObject.Doc != null &&
                                                    !string.IsNullOrWhiteSpace(docObject.Doc.Summary)
                    ? docObject.Doc.Summary
                    : string.Empty);

            objectNameParagraph.InsertAfterSelf(objectDescriptionParagraph);

            return objectDescriptionParagraph;
        }

        public object ForceSection(string headerText = null)
        {
            headerText = string.IsNullOrEmpty(headerText) ? Doc.DefaultSection : headerText;

            string[] sections = headerText.Split(new char[] {Convert.ToChar(@"\"), Convert.ToChar(@"/")}).ToArray();

            Paragraph currentSection = null;
            Paragraph parentSection = null;

            for (int i = 0; i <= sections.Count() - 1; i++)
            {
                int currentLevel = i + 1;

                if (string.IsNullOrWhiteSpace(sections[i]))
                {
                    continue;
                }

                currentSection = null;

                if (parentSection == null)
                {
                    currentSection =
                        DocxWorker.FindNextEqualOrLessLevelHeader(
                            this.DocxDocument.Document.MainDocumentPart.Document.Body.ChildElements.OfType<Paragraph>(),
                            currentLevel, sections[i]);

                    if (currentSection == null)
                    {
                        currentSection = DocxWorker.CreateHeader(sections[i], currentLevel);

                        var lastChild =
                            this.DocxDocument.Document.MainDocumentPart.Document.Body.ChildElements.LastOrDefault(
                                x => x.GetType() != typeof(SectionProperties));

                        if (lastChild != null)
                        {
                            lastChild.InsertAfterSelf(currentSection);
                        }
                        else
                        {
                            this.DocxDocument.Document.MainDocumentPart.Document.Body.AppendChild(currentSection);
                        }
                    }
                }
                else
                {
                    Paragraph NextEqualOrLessLevelHeader = DocxWorker.FindNextEqualOrLessLevelHeader(parentSection);

                    IEnumerable<OpenXmlElement> before = null; 

                    IEnumerable<OpenXmlElement> after = parentSection.ElementsAfter();

                    if (NextEqualOrLessLevelHeader != null)
                    {
                        before = NextEqualOrLessLevelHeader.ElementsBefore();
                    }

                    if (before == null)
                    {
                        before = after;
                    }

                    IEnumerable<OpenXmlElement> cross = after.Where(x => before.Contains(x));

                    currentSection =
                        DocxWorker.FindNextEqualOrLessLevelHeader(
                            cross.OfType<Paragraph>(),
                            currentLevel, sections[i]);

                    if (currentSection == null)
                    {
                        currentSection = DocxWorker.CreateHeader(sections[i], currentLevel);

                        var lastChild = cross.LastOrDefault();

                        if (lastChild != null)
                        {
                            lastChild.InsertAfterSelf(currentSection);
                        }
                        else if (NextEqualOrLessLevelHeader != null)
                        {
                            NextEqualOrLessLevelHeader.InsertBeforeSelf(currentSection);
                        }
                        else
                        {
                            parentSection.InsertAfterSelf(currentSection);
                        }
                    }

                }
               
                parentSection = currentSection;
            }

            return currentSection;
        }

        public object AddParametersInfo(object insertAfter, DocObject docObject, Color headerColor, Color elseColor)
        {
            if (docObject.Parameters.Count > 0)
            {
                Paragraph paramHeader = DocxWorker.GenerateParamsParagraph();

                (insertAfter as OpenXmlElement).InsertAfterSelf(paramHeader);

                Table paramTable = DocxWorker.GenerateParamsTable();

                paramHeader.InsertAfterSelf(paramTable);

                TableRow rowTemplate = paramTable.ChildElements.OfType<TableRow>().Last().Clone() as TableRow;

                paramTable.RemoveChild(paramTable.ChildElements.OfType<TableRow>().Last());

                foreach (SqlObjectParameter parameter in docObject.Parameters)
                {
                    TableRow currentRow = rowTemplate.Clone() as TableRow;

                    this.SetTableCellText(currentRow.ChildElements.OfType<TableCell>().ElementAt(0), parameter.PARAMETER_NAME);
                    this.SetTableCellText(currentRow.ChildElements.OfType<TableCell>().ElementAt(1), parameter.PARAMETER_MODE);
                    this.SetTableCellText(currentRow.ChildElements.OfType<TableCell>().ElementAt(2), parameter.FullDataType);

                    this.SetTableCellText(currentRow.ChildElements.OfType<TableCell>().ElementAt(3), docObject.GetParamComment(parameter));

                    paramTable.AppendChild(currentRow);
                }

                return paramTable;
            }
            else
            {
                return insertAfter;
            }
        }

        private void SetTableCellText(TableCell tableCell, string inputText)
        {
            Text templateText = tableCell.ChildElements.OfType<Paragraph>()
                .Select(x => x.ChildElements.OfType<Run>().First())
                .First()
                .ChildElements.OfType<Text>()
                .First();

            OpenXmlElement insertAfter = templateText;

            foreach (OpenXmlElement currentElement in DocxWorker.ConvertToMultiLineText(templateText, inputText, DocxWorker.TextLinesDelimeters))
            {
                insertAfter.InsertAfterSelf(currentElement);
                insertAfter = currentElement;
            }

            templateText.Remove();
        }

        public object AddReturnDatasetInfo(object insertAfter, DocObject docObject, Color headerColor, Color elseColor)
        {
            if (docObject.OutputDataSet != null)
            {
                Paragraph datasetHeader = DocxWorker.GenerateOutputDatasetsParagraph();

                Table datasetTable = DocxWorker.GenerateOutputDatasetTable();

                (insertAfter as OpenXmlElement).InsertAfterSelf(datasetHeader);

                TableRow rowTemplate = datasetTable.ChildElements.OfType<TableRow>().Last().Clone() as TableRow;

                datasetTable.RemoveChild(datasetTable.ChildElements.OfType<TableRow>().Last());

                foreach (var outputField in docObject.OutputDataSet.OutputFields)
                {
                    TableRow currentRow = rowTemplate.Clone() as TableRow;

                    this.SetTableCellText(currentRow.ChildElements.OfType<TableCell>().ElementAt(0), outputField.Name);
                    this.SetTableCellText(currentRow.ChildElements.OfType<TableCell>().ElementAt(1), outputField.DataTypeName);
                    this.SetTableCellText(currentRow.ChildElements.OfType<TableCell>().ElementAt(2), docObject.GetOutputFieldComment(outputField));

                    datasetTable.AppendChild(currentRow);
                }

                datasetHeader.InsertAfterSelf(datasetTable);

                return datasetTable;
            }

            return insertAfter;
        }

        public object AddReturnValueInfo(object insertAfter, DocFunction docFunction, Color backgrouColor)
        {
            Paragraph resultHeader = DocxWorker.GenerateFunctionResultParagraph();

            Table resulTable = DocxWorker.GenerateFunctuionResultTable();

            (insertAfter as OpenXmlElement).InsertAfterSelf(resultHeader);


            TableRow rowTemplate = resulTable.ChildElements.OfType<TableRow>().Last().Clone() as TableRow;

            resulTable.RemoveChild(resulTable.ChildElements.OfType<TableRow>().Last());

            TableRow currentRow = rowTemplate.Clone() as TableRow;


            this.SetTableCellText(currentRow.ChildElements.OfType<TableCell>().ElementAt(0), docFunction.ReturnValueDataType);
            this.SetTableCellText(currentRow.ChildElements.OfType<TableCell>().ElementAt(1), docFunction.ResultComment);

            resulTable.AppendChild(currentRow);

            resultHeader.InsertAfterSelf(resulTable);

            return resulTable;
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace Vitasoft.DocMaker.Core
{
    public class PdfUploader : IDocUploader
    {
        /*
        private static iTextSharp.text.Font boldFont10 = new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\WINDOWS\Fonts\arial.ttf", Encoding.GetEncoding(0x4e3).BodyName, true), 10f, 1);
        private static iTextSharp.text.Font boldFont8 = new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\WINDOWS\Fonts\arial.ttf", Encoding.GetEncoding(0x4e3).BodyName, true), 8f, 1);
        private static iTextSharp.text.Font font10 = new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\WINDOWS\Fonts\arial.ttf", Encoding.GetEncoding(0x4e3).BodyName, true), 10f);
        private static iTextSharp.text.Font font8 = new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\WINDOWS\Fonts\arial.ttf", Encoding.GetEncoding(0x4e3).BodyName, true), 8f);
        */
        private Document _document;

        public PdfUploader(string fullFileName)
        {
            if (!string.Equals(Path.GetExtension(fullFileName), ".pdf", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception("Расширение файла должно быть .PDF, сейчас указано: " + Path.GetExtension(fullFileName));
            }

            _document = new Document(PageSize.A4);

            if (File.Exists(fullFileName))
            {
                throw new Exception("Файл с именем " + fullFileName + " уже существует!");
                //PdfWriter.GetInstance(_document, new FileStream(fullFileName, FileMode.Append));
            }
            else
            {
                PdfWriter.GetInstance(_document, new FileStream(fullFileName, FileMode.CreateNew));

                _document.AddAuthor(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                _document.AddCreationDate();
                _document.AddCreator(Assembly.GetEntryAssembly().GetName().Name);
                _document.AddTitle("Собранная автоматически документация");
            }

            _document.Open();
            
        }


        public object AddNewTableCell(object table, string content, Color color, CustomFont customFont = null)
        {
            if (customFont == null)
            {
                customFont = new CustomFont();
            }

            Font font =
                new iTextSharp.text.Font(
                    BaseFont.CreateFont(
                        @"C:\WINDOWS\Fonts\" + customFont.Name + ".ttf",
                        Encoding.GetEncoding(0x4e3).BodyName, true), customFont.Size, customFont.Bold ? 1 : 0);

            if (table == null || !(table is PdfPTable))
            {
                throw new Exception("Объект не является PDF таблицей!");
            }

            PdfPCell cell = new PdfPCell(new Phrase(content, font as iTextSharp.text.Font))
            {
                BorderWidth = 1,
                BackgroundColor = new BaseColor(color.R, color.G, color.B),
                HorizontalAlignment = 0,
                VerticalAlignment = 4
            };

            (table as PdfPTable).AddCell(cell);

            return cell;
        }


        public bool AddTableToDoc(object table)
        {
            return this._document.Add(table as PdfPTable);
        }

        public object CreateParagraph(string Text = null, CustomFont customFont = null)
        {
            if (customFont == null)
            {
                customFont = new CustomFont();
            }

            Font font =
                new iTextSharp.text.Font(
                    BaseFont.CreateFont(
                        @"C:\WINDOWS\Fonts\" + customFont.Name + ".ttf",
                        Encoding.GetEncoding(0x4e3).BodyName, true), customFont.Size, customFont.Bold ? 1 : 0);

            Paragraph paragraph = new Paragraph();

            paragraph.Alignment = customFont.Alignment;
            paragraph.Font = font;
            paragraph.Add(string.IsNullOrWhiteSpace(Text) ? string.Empty : Text);

            return paragraph;
        }

        public bool AddParagraphToDoc(object paragraph)
        {
            return this._document.Add(paragraph as Paragraph);
        }

        public object AddSummaryInfo(object section, DocObject docObject, Color backgrouColor)
        {
            var table = CreateTable(1) as PdfPTable;

            this.AddParagraphToDoc(this.CreateParagraph(Text: docObject.SqlObject.name, customFont:new CustomFont(fontSize:10, bold:true)));

            this.AddNewTableCell(table,
                docObject.Doc != null && !string.IsNullOrWhiteSpace(docObject.Doc.Summary)
                    ? docObject.Doc.Summary
                    : string.Empty, backgrouColor, new CustomFont(fontSize: 10));

            this.AddTableToDoc(table);

            return null;
        }

        public object CreateTable(int columnsCount)
        {
            PdfPTable table = new PdfPTable(columnsCount)
            {
                WidthPercentage = 100f,
                SpacingBefore = 5f,
                HorizontalAlignment = 0,
            };

            return table;
        }

        public object CreateTable(float[] widths)
        {
            PdfPTable table = new PdfPTable(widths)
            {
                WidthPercentage = 100f,
                SpacingBefore = 5f,
                HorizontalAlignment = 0,
            };

            return table;
        }

        public object CreateParamTable(float[] widths, Color headerColor)
        {

            PdfPTable table = CreateTable(widths) as PdfPTable;

            if (table.NumberOfColumns != 4)
            {
                throw new Exception("Таблица с описанием параметров должна состоять из 4х колонок!");
            }

            this.AddNewTableCell(table, "Имя параметра", headerColor, new CustomFont(fontSize: 8, bold: true));
            this.AddNewTableCell(table, "Тип параметра", headerColor, new CustomFont(fontSize: 8, bold: true));
            this.AddNewTableCell(table, "Тип данных", headerColor, new CustomFont(fontSize: 8, bold: true));
            this.AddNewTableCell(table, "Описание", headerColor, new CustomFont(fontSize: 8, bold: true));

            table.HeaderRows = 1;

            return table;
        }

        public object CreateDatasetTable(float[] widths)
        {
            PdfPTable table = CreateTable(widths) as PdfPTable;

            if (table.NumberOfColumns != 3)
            {
                throw new Exception("Таблица с описанием возвращаемого датасета должна состоять из 3х колонок!");
            }

            this.AddNewTableCell(table, "Имя Поля", Color.Gainsboro, new CustomFont(fontSize: 8, bold: true));
            this.AddNewTableCell(table, "Тип данных", Color.Gainsboro, new CustomFont(fontSize: 8, bold: true));
            this.AddNewTableCell(table, "Описание", Color.Gainsboro, new CustomFont(fontSize: 8, bold: true));

            table.HeaderRows = 1;

            return table;
        }

        public object AddNewPage(string headerText = null)
        {
            this._document.NewPage();

            Paragraph paragraph = this.CreateParagraph(Text:headerText, customFont:new CustomFont(fontSize:12, bold:true, alignment:1)) as Paragraph;
            paragraph.SetLeading(0f, 1.2f);
            this._document.Add(paragraph);

            return paragraph;
        }

        public void Dispose()
        {
            this._document.Close();
            this._document = null;
        }

        public object ForceSection(string headerText = null)
        {
            return this.AddNewPage(headerText);
        }

        public object AddParametersInfo(object insertAfter, DocObject docObject, Color headerColor, Color elseColor)
        {
            if (docObject.Parameters.Count > 0)
            {
                this.AddParagraphToDoc(this.CreateParagraph(Text: "Параметры", customFont: new CustomFont(fontSize: 10, bold: true)));

                var table = this.CreateParamTable(new float[] { 35f, 20f, 45f, 45f }, headerColor);

                foreach (var sqlObjectParameter in docObject.Parameters.OrderBy(x => x.ORDINAL_POSITION))
                {

                    this.AddNewTableCell(table, sqlObjectParameter.PARAMETER_NAME, elseColor);
                    this.AddNewTableCell(table, sqlObjectParameter.PARAMETER_MODE, elseColor);

                    this.AddNewTableCell(table, sqlObjectParameter.FullDataType, elseColor);

                    this.AddNewTableCell(table, docObject.GetParamComment(sqlObjectParameter), elseColor);
                }

                this.AddTableToDoc(table);

                return table;
            }

            return insertAfter;
        }

        public object AddReturnDatasetInfo(object insertAfter, DocProcedure docProcedure, Color headerColor, Color elseColor)
        {
            if (docProcedure.OutputDataSet != null)
            {
                var table = this.CreateDatasetTable(new float[] { 35f, 20f, 45f });

                this.AddParagraphToDoc(this.CreateParagraph(Text: "Возвращаемый курсор", customFont: new CustomFont(fontSize: 10, bold: true)));

                foreach (OutputField outputField in docProcedure.OutputDataSet.OutputFields)
                {
                    this.AddNewTableCell(table, outputField.Name, Color.Transparent);
                    this.AddNewTableCell(table, outputField.DataTypeName, Color.Transparent);

                    DocOutput_DatasetField docOutputDatasetField = null;

                    if (docProcedure.Doc != null && docProcedure.Doc.Output_Dataset != null && docProcedure.Doc.Output_Dataset.Fields != null)
                    {
                        docOutputDatasetField = docProcedure.Doc.Output_Dataset.Fields.FirstOrDefault(
                            x => x.Name != null &&
                                 string.Equals(x.Name, outputField.Name,
                                     StringComparison.InvariantCultureIgnoreCase));

                    }

                    this.AddNewTableCell(table,
                        (docOutputDatasetField != null ? docOutputDatasetField.Comment : string.Empty),
                        Color.Transparent);
                }

                this.AddTableToDoc(table);

                return table;
            }

            return insertAfter;
        }

        public object AddReturnValueInfo(object insertAfter, DocFunction docFunction, Color backgrouColor)
        {
            var table = CreateTable(2) as PdfPTable;

            this.AddParagraphToDoc(this.CreateParagraph(Text: "Возвращаемое значение", customFont: new CustomFont(fontSize: 10, bold: true)));

            this.AddNewTableCell(table,
                docFunction.Result.FullDataType, backgrouColor, new CustomFont(fontSize: 10));

            this.AddNewTableCell(table,
                docFunction.ResultComment, backgrouColor, new CustomFont(fontSize: 10));

            this.AddTableToDoc(table);

            return null;
        }
    }
}

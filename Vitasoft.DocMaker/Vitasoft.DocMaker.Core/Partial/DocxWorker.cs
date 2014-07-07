using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Vitasoft.DocMaker.Core
{
    public static class DocxWorker
    {
        public static string[] TextLinesDelimeters = new string[]{Environment.NewLine};

        public static Paragraph GenerateBreakeParagraph()
        {
            Paragraph paragraph1 = new Paragraph() { RsidParagraphAddition = "00F51E38", RsidRunAdditionDefault = "00F51E38" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", EastAsia = "SimSun", ComplexScript = "Arial" };
            Bold bold1 = new Bold();
            BoldComplexScript boldComplexScript1 = new BoldComplexScript();
            Color color1 = new Color() { Val = "365F91" };
            FontSize fontSize1 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "20" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(boldComplexScript1);
            paragraphMarkRunProperties1.Append(color1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run();

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Color color2 = new Color() { Val = "365F91" };
            FontSize fontSize2 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "20" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(color2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Break break1 = new Break() { Type = BreakValues.Page };

            run1.Append(runProperties1);
            run1.Append(break1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);
            return paragraph1;
        }

        public static IEnumerable<Paragraph> FindAllEqualOrLessLevelHeaders(IEnumerable<Paragraph> elements,
            int level, string text = null)
        {
            int tmpInt;

            return elements.OfType<Paragraph>()
                .Where(
                    nextParagraph => nextParagraph.ParagraphProperties != null && nextParagraph.ParagraphProperties.ParagraphStyleId != null && nextParagraph.ParagraphProperties.ParagraphStyleId.Val != null &&
                        int.TryParse(nextParagraph.ParagraphProperties.ParagraphStyleId.Val, out tmpInt) &&
                        int.Parse(nextParagraph.ParagraphProperties.ParagraphStyleId.Val) <= level &&
                        nextParagraph.ChildElements.OfType<Run>()
                            .Any(
                                run =>
                                    run.ChildElements.OfType<Text>()
                                        .Any(
                                            x =>
                                                string.IsNullOrWhiteSpace(text) ||
                                                string.Equals(x.Text, text, StringComparison.InvariantCultureIgnoreCase))));
        }

        public static Paragraph FindNextEqualOrLessLevelHeader(IEnumerable<Paragraph> elements, int level, string text = null)
        {
            return FindAllEqualOrLessLevelHeaders(elements, level, text).FirstOrDefault();
        }

        public static int GetHeaderLevel(Paragraph paragraph)
        {
            string currentLevel = paragraph.ParagraphProperties.ParagraphStyleId.Val;
            int intCurrentLevel;

            if (int.TryParse(currentLevel, out intCurrentLevel))
            {
                return intCurrentLevel;
            }
            else
            {
                throw new Exception("Стиль текущего параграфа не является заголовком! ParagraphStyleId:" + currentLevel);
            }
        }

        public static Paragraph FindNextEqualOrLessLevelHeader(Paragraph paragraph, string text = null)
        {
            int intCurrentLevel = GetHeaderLevel(paragraph);
            return FindNextEqualOrLessLevelHeader(paragraph.ElementsAfter().OfType<Paragraph>(), intCurrentLevel, text);
        }

        // Creates an Paragraph instance and adds its children.
        public static Paragraph CreateHeader(string text, int level)
        {
            if (level > 9 || level < 1)
            {
                throw new Exception("Уровень вне допустимых границ! current level:" + level.ToString());
            }

            Paragraph paragraph1 = new Paragraph();//{ RsidParagraphMarkRevision = "009826F4", RsidParagraphAddition = "00191222", RsidParagraphProperties = "009826F4", RsidRunAdditionDefault = "00191222" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = level.ToString() };

            paragraphProperties1.Append(paragraphStyleId1);

            Run run1 = new Run();
            Text text1 = new Text();
            text1.Text = text;
            
            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);
            return paragraph1;
        }

        // Creates an Table instance and adds its children.
        public static Table GenerateOutputDatasetTable()
        {
            Table table1 = new Table();

            TableProperties tableProperties1 = new TableProperties();
            TableWidth tableWidth1 = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };

            TableBorders tableBorders1 = new TableBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Nil };
            InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.Nil };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 0, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 0, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);
            TableLook tableLook1 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableCellMarginDefault1);
            tableProperties1.Append(tableLook1);

            TableGrid tableGrid1 = new TableGrid();
            GridColumn gridColumn1 = new GridColumn() { Width = "2098" };
            GridColumn gridColumn2 = new GridColumn() { Width = "1203" };
            GridColumn gridColumn3 = new GridColumn() { Width = "7273" };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);
            tableGrid1.Append(gridColumn3);

            TableRow tableRow1 = new TableRow() { RsidTableRowMarkRevision = "00667990", RsidTableRowAddition = "00C00F62", RsidTableRowProperties = "001F49E5" };

            TableCell tableCell1 = new TableCell();

            TableCellProperties tableCellProperties1 = new TableCellProperties();
            TableCellWidth tableCellWidth1 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders1 = new TableCellBorders();
            TopBorder topBorder2 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder2 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder2 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders1.Append(topBorder2);
            tableCellBorders1.Append(leftBorder2);
            tableCellBorders1.Append(bottomBorder2);
            tableCellBorders1.Append(rightBorder2);
            Shading shading1 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin1 = new TableCellMargin();
            LeftMargin leftMargin1 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin1.Append(leftMargin1);
            TableCellVerticalAlignment tableCellVerticalAlignment1 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties1.Append(tableCellWidth1);
            tableCellProperties1.Append(tableCellBorders1);
            tableCellProperties1.Append(shading1);
            tableCellProperties1.Append(tableCellMargin1);
            tableCellProperties1.Append(tableCellVerticalAlignment1);

            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00667990", RsidParagraphAddition = "00C00F62", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "00C00F62" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold1 = new Bold();
            BoldComplexScript boldComplexScript1 = new BoldComplexScript();
            FontSize fontSize1 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(boldComplexScript1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphMarkRunProperties1);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "1" };

            Run run1 = new Run() { RsidRunProperties = "00667990" };

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold2 = new Bold();
            BoldComplexScript boldComplexScript2 = new BoldComplexScript();
            FontSize fontSize2 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "16" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(bold2);
            runProperties1.Append(boldComplexScript2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Text text1 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text1.Text = "Имя ";

            run1.Append(runProperties1);
            run1.Append(text1);

            Run run2 = new Run() { RsidRunAddition = "0002594A" };

            RunProperties runProperties2 = new RunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold3 = new Bold();
            BoldComplexScript boldComplexScript3 = new BoldComplexScript();
            FontSize fontSize3 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "16" };

            runProperties2.Append(runFonts3);
            runProperties2.Append(bold3);
            runProperties2.Append(boldComplexScript3);
            runProperties2.Append(fontSize3);
            runProperties2.Append(fontSizeComplexScript3);
            Text text2 = new Text();
            text2.Text = "поля";

            run2.Append(runProperties2);
            run2.Append(text2);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(bookmarkStart1);
            paragraph1.Append(run1);
            paragraph1.Append(run2);

            tableCell1.Append(tableCellProperties1);
            tableCell1.Append(paragraph1);

            TableCell tableCell2 = new TableCell();

            TableCellProperties tableCellProperties2 = new TableCellProperties();
            TableCellWidth tableCellWidth2 = new TableCellWidth() { Width = "569", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders2 = new TableCellBorders();
            TopBorder topBorder3 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder3 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder3 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders2.Append(topBorder3);
            tableCellBorders2.Append(leftBorder3);
            tableCellBorders2.Append(bottomBorder3);
            tableCellBorders2.Append(rightBorder3);
            Shading shading2 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin2 = new TableCellMargin();
            LeftMargin leftMargin2 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin2.Append(leftMargin2);
            TableCellVerticalAlignment tableCellVerticalAlignment2 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties2.Append(tableCellWidth2);
            tableCellProperties2.Append(tableCellBorders2);
            tableCellProperties2.Append(shading2);
            tableCellProperties2.Append(tableCellMargin2);
            tableCellProperties2.Append(tableCellVerticalAlignment2);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphMarkRevision = "00FD0905", RsidParagraphAddition = "00C00F62", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "00C00F62" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
            RunFonts runFonts4 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold4 = new Bold();
            BoldComplexScript boldComplexScript4 = new BoldComplexScript();
            FontSize fontSize4 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties2.Append(runFonts4);
            paragraphMarkRunProperties2.Append(bold4);
            paragraphMarkRunProperties2.Append(boldComplexScript4);
            paragraphMarkRunProperties2.Append(fontSize4);
            paragraphMarkRunProperties2.Append(fontSizeComplexScript4);

            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run3 = new Run();

            RunProperties runProperties3 = new RunProperties();
            RunFonts runFonts5 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold5 = new Bold();
            BoldComplexScript boldComplexScript5 = new BoldComplexScript();
            FontSize fontSize5 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "16" };

            runProperties3.Append(runFonts5);
            runProperties3.Append(bold5);
            runProperties3.Append(boldComplexScript5);
            runProperties3.Append(fontSize5);
            runProperties3.Append(fontSizeComplexScript5);
            Text text3 = new Text();
            text3.Text = "Тип данных";

            run3.Append(runProperties3);
            run3.Append(text3);

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run3);

            tableCell2.Append(tableCellProperties2);
            tableCell2.Append(paragraph2);

            TableCell tableCell3 = new TableCell();

            TableCellProperties tableCellProperties3 = new TableCellProperties();
            TableCellWidth tableCellWidth3 = new TableCellWidth() { Width = "3439", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders3 = new TableCellBorders();
            TopBorder topBorder4 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder4 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder4 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder4 = new RightBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders3.Append(topBorder4);
            tableCellBorders3.Append(leftBorder4);
            tableCellBorders3.Append(bottomBorder4);
            tableCellBorders3.Append(rightBorder4);
            Shading shading3 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin3 = new TableCellMargin();
            LeftMargin leftMargin3 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin3.Append(leftMargin3);
            TableCellVerticalAlignment tableCellVerticalAlignment3 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties3.Append(tableCellWidth3);
            tableCellProperties3.Append(tableCellBorders3);
            tableCellProperties3.Append(shading3);
            tableCellProperties3.Append(tableCellMargin3);
            tableCellProperties3.Append(tableCellVerticalAlignment3);

            Paragraph paragraph3 = new Paragraph() { RsidParagraphMarkRevision = "00667990", RsidParagraphAddition = "00C00F62", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "00C00F62" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
            RunFonts runFonts6 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold6 = new Bold();
            BoldComplexScript boldComplexScript6 = new BoldComplexScript();
            FontSize fontSize6 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties3.Append(runFonts6);
            paragraphMarkRunProperties3.Append(bold6);
            paragraphMarkRunProperties3.Append(boldComplexScript6);
            paragraphMarkRunProperties3.Append(fontSize6);
            paragraphMarkRunProperties3.Append(fontSizeComplexScript6);

            paragraphProperties3.Append(paragraphMarkRunProperties3);

            Run run4 = new Run() { RsidRunProperties = "00667990" };

            RunProperties runProperties4 = new RunProperties();
            RunFonts runFonts7 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold7 = new Bold();
            BoldComplexScript boldComplexScript7 = new BoldComplexScript();
            FontSize fontSize7 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "16" };

            runProperties4.Append(runFonts7);
            runProperties4.Append(bold7);
            runProperties4.Append(boldComplexScript7);
            runProperties4.Append(fontSize7);
            runProperties4.Append(fontSizeComplexScript7);
            Text text4 = new Text();
            text4.Text = "Описание";

            run4.Append(runProperties4);
            run4.Append(text4);

            paragraph3.Append(paragraphProperties3);
            paragraph3.Append(run4);

            tableCell3.Append(tableCellProperties3);
            tableCell3.Append(paragraph3);

            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);
            tableRow1.Append(tableCell3);

            TableRow tableRow2 = new TableRow() { RsidTableRowMarkRevision = "00667990", RsidTableRowAddition = "00C00F62", RsidTableRowProperties = "001F49E5" };

            TableCell tableCell4 = new TableCell();

            TableCellProperties tableCellProperties4 = new TableCellProperties();
            TableCellWidth tableCellWidth4 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders4 = new TableCellBorders();
            TopBorder topBorder5 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder5 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder5 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder5 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders4.Append(topBorder5);
            tableCellBorders4.Append(leftBorder5);
            tableCellBorders4.Append(bottomBorder5);
            tableCellBorders4.Append(rightBorder5);
            Shading shading4 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin4 = new TableCellMargin();
            LeftMargin leftMargin4 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin4.Append(leftMargin4);
            TableCellVerticalAlignment tableCellVerticalAlignment4 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties4.Append(tableCellWidth4);
            tableCellProperties4.Append(tableCellBorders4);
            tableCellProperties4.Append(shading4);
            tableCellProperties4.Append(tableCellMargin4);
            tableCellProperties4.Append(tableCellVerticalAlignment4);

            Paragraph paragraph4 = new Paragraph() { RsidParagraphMarkRevision = "001F49E5", RsidParagraphAddition = "00C00F62", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "001F49E5" };

            ParagraphProperties paragraphProperties4 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
            RunFonts runFonts8 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize8 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties4.Append(runFonts8);
            paragraphMarkRunProperties4.Append(fontSize8);
            paragraphMarkRunProperties4.Append(fontSizeComplexScript8);

            paragraphProperties4.Append(paragraphMarkRunProperties4);

            Run run5 = new Run();

            RunProperties runProperties5 = new RunProperties();
            RunFonts runFonts9 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize9 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "16" };

            runProperties5.Append(runFonts9);
            runProperties5.Append(fontSize9);
            runProperties5.Append(fontSizeComplexScript9);
            Text text5 = new Text();
            text5.Text = "текст";

            run5.Append(runProperties5);
            run5.Append(text5);

            paragraph4.Append(paragraphProperties4);
            paragraph4.Append(run5);

            tableCell4.Append(tableCellProperties4);
            tableCell4.Append(paragraph4);

            TableCell tableCell5 = new TableCell();

            TableCellProperties tableCellProperties5 = new TableCellProperties();
            TableCellWidth tableCellWidth5 = new TableCellWidth() { Width = "569", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders5 = new TableCellBorders();
            TopBorder topBorder6 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder6 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder6 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder6 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders5.Append(topBorder6);
            tableCellBorders5.Append(leftBorder6);
            tableCellBorders5.Append(bottomBorder6);
            tableCellBorders5.Append(rightBorder6);
            Shading shading5 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin5 = new TableCellMargin();
            LeftMargin leftMargin5 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin5.Append(leftMargin5);
            TableCellVerticalAlignment tableCellVerticalAlignment5 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties5.Append(tableCellWidth5);
            tableCellProperties5.Append(tableCellBorders5);
            tableCellProperties5.Append(shading5);
            tableCellProperties5.Append(tableCellMargin5);
            tableCellProperties5.Append(tableCellVerticalAlignment5);

            Paragraph paragraph5 = new Paragraph() { RsidParagraphMarkRevision = "0002594A", RsidParagraphAddition = "00C00F62", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "001F49E5" };

            ParagraphProperties paragraphProperties5 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties5 = new ParagraphMarkRunProperties();
            RunFonts runFonts10 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize10 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties5.Append(runFonts10);
            paragraphMarkRunProperties5.Append(fontSize10);
            paragraphMarkRunProperties5.Append(fontSizeComplexScript10);

            paragraphProperties5.Append(paragraphMarkRunProperties5);

            Run run6 = new Run();

            RunProperties runProperties6 = new RunProperties();
            RunFonts runFonts11 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize11 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "16" };

            runProperties6.Append(runFonts11);
            runProperties6.Append(fontSize11);
            runProperties6.Append(fontSizeComplexScript11);
            Text text6 = new Text();
            text6.Text = "текст";

            run6.Append(runProperties6);
            run6.Append(text6);

            paragraph5.Append(paragraphProperties5);
            paragraph5.Append(run6);

            tableCell5.Append(tableCellProperties5);
            tableCell5.Append(paragraph5);

            TableCell tableCell6 = new TableCell();

            TableCellProperties tableCellProperties6 = new TableCellProperties();
            TableCellWidth tableCellWidth6 = new TableCellWidth() { Width = "3439", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders6 = new TableCellBorders();
            TopBorder topBorder7 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder7 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder7 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder7 = new RightBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders6.Append(topBorder7);
            tableCellBorders6.Append(leftBorder7);
            tableCellBorders6.Append(bottomBorder7);
            tableCellBorders6.Append(rightBorder7);
            Shading shading6 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin6 = new TableCellMargin();
            LeftMargin leftMargin6 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin6.Append(leftMargin6);
            TableCellVerticalAlignment tableCellVerticalAlignment6 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties6.Append(tableCellWidth6);
            tableCellProperties6.Append(tableCellBorders6);
            tableCellProperties6.Append(shading6);
            tableCellProperties6.Append(tableCellMargin6);
            tableCellProperties6.Append(tableCellVerticalAlignment6);

            Paragraph paragraph6 = new Paragraph() { RsidParagraphMarkRevision = "00667990", RsidParagraphAddition = "00C00F62", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "001F49E5" };

            ParagraphProperties paragraphProperties6 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties6 = new ParagraphMarkRunProperties();
            RunFonts runFonts12 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize12 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties6.Append(runFonts12);
            paragraphMarkRunProperties6.Append(fontSize12);
            paragraphMarkRunProperties6.Append(fontSizeComplexScript12);

            paragraphProperties6.Append(paragraphMarkRunProperties6);

            Run run7 = new Run();

            RunProperties runProperties7 = new RunProperties();
            RunFonts runFonts13 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize13 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "16" };

            runProperties7.Append(runFonts13);
            runProperties7.Append(fontSize13);
            runProperties7.Append(fontSizeComplexScript13);
            Text text7 = new Text();
            text7.Text = "текст";

            run7.Append(runProperties7);
            run7.Append(text7);

            paragraph6.Append(paragraphProperties6);
            paragraph6.Append(run7);

            tableCell6.Append(tableCellProperties6);
            tableCell6.Append(paragraph6);

            tableRow2.Append(tableCell4);
            tableRow2.Append(tableCell5);
            tableRow2.Append(tableCell6);
            BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "0" };
            BookmarkEnd bookmarkEnd2 = new BookmarkEnd() { Id = "1" };

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);
            table1.Append(tableRow2);
            table1.Append(bookmarkEnd1);
            table1.Append(bookmarkEnd2);
            return table1;
        }


        // Creates an Paragraph instance and adds its children.
        public static Paragraph GenerateOutputDatasetsParagraph()
        {
            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00C00F62", RsidParagraphAddition = "00A52419", RsidRunAdditionDefault = "00A52419" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold1 = new Bold();
            FontSize fontSize1 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "20" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphMarkRunProperties1);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_Toc388858671", Id = "0" };

            Run run1 = new Run() { RsidRunProperties = "00C00F62" };

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold2 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "20" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(bold2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Text text1 = new Text();
            text1.Text = "Возвращаемый набор данных";

            run1.Append(runProperties1);
            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(bookmarkStart1);
            paragraph1.Append(run1);
            return paragraph1;
        }


        // Creates an Table instance and adds its children.
        public static Table GenerateParamsTable()
        {
            Table table1 = new Table();

            TableProperties tableProperties1 = new TableProperties();
            TableWidth tableWidth1 = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };

            TableBorders tableBorders1 = new TableBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Nil };
            InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.Nil };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 0, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 0, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);
            TableLook tableLook1 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableCellMarginDefault1);
            tableProperties1.Append(tableLook1);

            TableGrid tableGrid1 = new TableGrid();
            GridColumn gridColumn1 = new GridColumn() { Width = "2555" };
            GridColumn gridColumn2 = new GridColumn() { Width = "1903" };
            GridColumn gridColumn3 = new GridColumn() { Width = "2197" };
            GridColumn gridColumn4 = new GridColumn() { Width = "3919" };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);
            tableGrid1.Append(gridColumn3);
            tableGrid1.Append(gridColumn4);

            TableRow tableRow1 = new TableRow() { RsidTableRowMarkRevision = "00667990", RsidTableRowAddition = "002961E3", RsidTableRowProperties = "006B7D79" };

            TableCell tableCell1 = new TableCell();

            TableCellProperties tableCellProperties1 = new TableCellProperties();
            TableCellWidth tableCellWidth1 = new TableCellWidth() { Width = "1208", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders1 = new TableCellBorders();
            TopBorder topBorder2 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder2 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder2 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders1.Append(topBorder2);
            tableCellBorders1.Append(leftBorder2);
            tableCellBorders1.Append(bottomBorder2);
            tableCellBorders1.Append(rightBorder2);
            Shading shading1 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin1 = new TableCellMargin();
            LeftMargin leftMargin1 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin1.Append(leftMargin1);

            tableCellProperties1.Append(tableCellWidth1);
            tableCellProperties1.Append(tableCellBorders1);
            tableCellProperties1.Append(shading1);
            tableCellProperties1.Append(tableCellMargin1);

            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00667990", RsidParagraphAddition = "002961E3", RsidParagraphProperties = "00363C05", RsidRunAdditionDefault = "002961E3" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold1 = new Bold();
            BoldComplexScript boldComplexScript1 = new BoldComplexScript();
            FontSize fontSize1 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(boldComplexScript1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run() { RsidRunProperties = "00667990" };

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold2 = new Bold();
            BoldComplexScript boldComplexScript2 = new BoldComplexScript();
            FontSize fontSize2 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "16" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(bold2);
            runProperties1.Append(boldComplexScript2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Text text1 = new Text();
            text1.Text = "Имя параметра";

            run1.Append(runProperties1);
            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);

            tableCell1.Append(tableCellProperties1);
            tableCell1.Append(paragraph1);

            TableCell tableCell2 = new TableCell();

            TableCellProperties tableCellProperties2 = new TableCellProperties();
            TableCellWidth tableCellWidth2 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders2 = new TableCellBorders();
            TopBorder topBorder3 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder3 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder3 = new RightBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders2.Append(topBorder3);
            tableCellBorders2.Append(leftBorder3);
            tableCellBorders2.Append(bottomBorder3);
            tableCellBorders2.Append(rightBorder3);
            Shading shading2 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            tableCellProperties2.Append(tableCellWidth2);
            tableCellProperties2.Append(tableCellBorders2);
            tableCellProperties2.Append(shading2);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphAddition = "002961E3", RsidParagraphProperties = "00FD0905", RsidRunAdditionDefault = "002961E3" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold3 = new Bold();
            BoldComplexScript boldComplexScript3 = new BoldComplexScript();
            FontSize fontSize3 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties2.Append(runFonts3);
            paragraphMarkRunProperties2.Append(bold3);
            paragraphMarkRunProperties2.Append(boldComplexScript3);
            paragraphMarkRunProperties2.Append(fontSize3);
            paragraphMarkRunProperties2.Append(fontSizeComplexScript3);

            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();

            RunProperties runProperties2 = new RunProperties();
            RunFonts runFonts4 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold4 = new Bold();
            BoldComplexScript boldComplexScript4 = new BoldComplexScript();
            FontSize fontSize4 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "16" };

            runProperties2.Append(runFonts4);
            runProperties2.Append(bold4);
            runProperties2.Append(boldComplexScript4);
            runProperties2.Append(fontSize4);
            runProperties2.Append(fontSizeComplexScript4);
            Text text2 = new Text();
            text2.Text = "Тип параметра";

            run2.Append(runProperties2);
            run2.Append(text2);

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run2);

            tableCell2.Append(tableCellProperties2);
            tableCell2.Append(paragraph2);

            TableCell tableCell3 = new TableCell();

            TableCellProperties tableCellProperties3 = new TableCellProperties();
            TableCellWidth tableCellWidth3 = new TableCellWidth() { Width = "1039", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders3 = new TableCellBorders();
            TopBorder topBorder4 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder4 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder4 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder4 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders3.Append(topBorder4);
            tableCellBorders3.Append(leftBorder4);
            tableCellBorders3.Append(bottomBorder4);
            tableCellBorders3.Append(rightBorder4);
            Shading shading3 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin2 = new TableCellMargin();
            LeftMargin leftMargin2 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin2.Append(leftMargin2);

            tableCellProperties3.Append(tableCellWidth3);
            tableCellProperties3.Append(tableCellBorders3);
            tableCellProperties3.Append(shading3);
            tableCellProperties3.Append(tableCellMargin2);

            Paragraph paragraph3 = new Paragraph() { RsidParagraphMarkRevision = "00FD0905", RsidParagraphAddition = "002961E3", RsidParagraphProperties = "00FD0905", RsidRunAdditionDefault = "002961E3" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
            RunFonts runFonts5 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold5 = new Bold();
            BoldComplexScript boldComplexScript5 = new BoldComplexScript();
            FontSize fontSize5 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties3.Append(runFonts5);
            paragraphMarkRunProperties3.Append(bold5);
            paragraphMarkRunProperties3.Append(boldComplexScript5);
            paragraphMarkRunProperties3.Append(fontSize5);
            paragraphMarkRunProperties3.Append(fontSizeComplexScript5);

            paragraphProperties3.Append(paragraphMarkRunProperties3);

            Run run3 = new Run();

            RunProperties runProperties3 = new RunProperties();
            RunFonts runFonts6 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold6 = new Bold();
            BoldComplexScript boldComplexScript6 = new BoldComplexScript();
            FontSize fontSize6 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "16" };

            runProperties3.Append(runFonts6);
            runProperties3.Append(bold6);
            runProperties3.Append(boldComplexScript6);
            runProperties3.Append(fontSize6);
            runProperties3.Append(fontSizeComplexScript6);
            Text text3 = new Text();
            text3.Text = "Тип данных";

            run3.Append(runProperties3);
            run3.Append(text3);

            paragraph3.Append(paragraphProperties3);
            paragraph3.Append(run3);

            tableCell3.Append(tableCellProperties3);
            tableCell3.Append(paragraph3);

            TableCell tableCell4 = new TableCell();

            TableCellProperties tableCellProperties4 = new TableCellProperties();
            TableCellWidth tableCellWidth4 = new TableCellWidth() { Width = "1853", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders4 = new TableCellBorders();
            TopBorder topBorder5 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder5 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder5 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder5 = new RightBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders4.Append(topBorder5);
            tableCellBorders4.Append(leftBorder5);
            tableCellBorders4.Append(bottomBorder5);
            tableCellBorders4.Append(rightBorder5);
            Shading shading4 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin3 = new TableCellMargin();
            LeftMargin leftMargin3 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin3.Append(leftMargin3);

            tableCellProperties4.Append(tableCellWidth4);
            tableCellProperties4.Append(tableCellBorders4);
            tableCellProperties4.Append(shading4);
            tableCellProperties4.Append(tableCellMargin3);

            Paragraph paragraph4 = new Paragraph() { RsidParagraphMarkRevision = "00667990", RsidParagraphAddition = "002961E3", RsidParagraphProperties = "00363C05", RsidRunAdditionDefault = "002961E3" };

            ParagraphProperties paragraphProperties4 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
            RunFonts runFonts7 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold7 = new Bold();
            BoldComplexScript boldComplexScript7 = new BoldComplexScript();
            FontSize fontSize7 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties4.Append(runFonts7);
            paragraphMarkRunProperties4.Append(bold7);
            paragraphMarkRunProperties4.Append(boldComplexScript7);
            paragraphMarkRunProperties4.Append(fontSize7);
            paragraphMarkRunProperties4.Append(fontSizeComplexScript7);

            paragraphProperties4.Append(paragraphMarkRunProperties4);

            Run run4 = new Run() { RsidRunProperties = "00667990" };

            RunProperties runProperties4 = new RunProperties();
            RunFonts runFonts8 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold8 = new Bold();
            BoldComplexScript boldComplexScript8 = new BoldComplexScript();
            FontSize fontSize8 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "16" };

            runProperties4.Append(runFonts8);
            runProperties4.Append(bold8);
            runProperties4.Append(boldComplexScript8);
            runProperties4.Append(fontSize8);
            runProperties4.Append(fontSizeComplexScript8);
            Text text4 = new Text();
            text4.Text = "Описание";

            run4.Append(runProperties4);
            run4.Append(text4);

            paragraph4.Append(paragraphProperties4);
            paragraph4.Append(run4);

            tableCell4.Append(tableCellProperties4);
            tableCell4.Append(paragraph4);

            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);
            tableRow1.Append(tableCell3);
            tableRow1.Append(tableCell4);

            TableRow tableRow2 = new TableRow() { RsidTableRowMarkRevision = "00667990", RsidTableRowAddition = "002961E3", RsidTableRowProperties = "00C20F46" };

            TableCell tableCell5 = new TableCell();

            TableCellProperties tableCellProperties5 = new TableCellProperties();
            TableCellWidth tableCellWidth5 = new TableCellWidth() { Width = "1208", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders5 = new TableCellBorders();
            TopBorder topBorder6 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder6 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder6 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder6 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders5.Append(topBorder6);
            tableCellBorders5.Append(leftBorder6);
            tableCellBorders5.Append(bottomBorder6);
            tableCellBorders5.Append(rightBorder6);
            Shading shading5 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin4 = new TableCellMargin();
            LeftMargin leftMargin4 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin4.Append(leftMargin4);
            TableCellVerticalAlignment tableCellVerticalAlignment1 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties5.Append(tableCellWidth5);
            tableCellProperties5.Append(tableCellBorders5);
            tableCellProperties5.Append(shading5);
            tableCellProperties5.Append(tableCellMargin4);
            tableCellProperties5.Append(tableCellVerticalAlignment1);

            Paragraph paragraph5 = new Paragraph() { RsidParagraphMarkRevision = "004D4D97", RsidParagraphAddition = "002961E3", RsidParagraphProperties = "00C20F46", RsidRunAdditionDefault = "004D4D97" };

            ParagraphProperties paragraphProperties5 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties5 = new ParagraphMarkRunProperties();
            RunFonts runFonts9 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize9 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties5.Append(runFonts9);
            paragraphMarkRunProperties5.Append(fontSize9);
            paragraphMarkRunProperties5.Append(fontSizeComplexScript9);

            paragraphProperties5.Append(paragraphMarkRunProperties5);

            Run run5 = new Run();

            RunProperties runProperties5 = new RunProperties();
            RunFonts runFonts10 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize10 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "16" };

            runProperties5.Append(runFonts10);
            runProperties5.Append(fontSize10);
            runProperties5.Append(fontSizeComplexScript10);
            Text text5 = new Text();
            text5.Text = "текст";

            run5.Append(runProperties5);
            run5.Append(text5);

            paragraph5.Append(paragraphProperties5);
            paragraph5.Append(run5);

            tableCell5.Append(tableCellProperties5);
            tableCell5.Append(paragraph5);

            TableCell tableCell6 = new TableCell();

            TableCellProperties tableCellProperties6 = new TableCellProperties();
            TableCellWidth tableCellWidth6 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders6 = new TableCellBorders();
            TopBorder topBorder7 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder7 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder7 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder7 = new RightBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders6.Append(topBorder7);
            tableCellBorders6.Append(leftBorder7);
            tableCellBorders6.Append(bottomBorder7);
            tableCellBorders6.Append(rightBorder7);
            Shading shading6 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };
            TableCellVerticalAlignment tableCellVerticalAlignment2 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties6.Append(tableCellWidth6);
            tableCellProperties6.Append(tableCellBorders6);
            tableCellProperties6.Append(shading6);
            tableCellProperties6.Append(tableCellVerticalAlignment2);

            Paragraph paragraph6 = new Paragraph() { RsidParagraphMarkRevision = "0002594A", RsidParagraphAddition = "002961E3", RsidParagraphProperties = "00C20F46", RsidRunAdditionDefault = "004D4D97" };

            ParagraphProperties paragraphProperties6 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties6 = new ParagraphMarkRunProperties();
            RunFonts runFonts11 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize11 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties6.Append(runFonts11);
            paragraphMarkRunProperties6.Append(fontSize11);
            paragraphMarkRunProperties6.Append(fontSizeComplexScript11);

            paragraphProperties6.Append(paragraphMarkRunProperties6);

            Run run6 = new Run();

            RunProperties runProperties6 = new RunProperties();
            RunFonts runFonts12 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize12 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "16" };

            runProperties6.Append(runFonts12);
            runProperties6.Append(fontSize12);
            runProperties6.Append(fontSizeComplexScript12);
            Text text6 = new Text();
            text6.Text = "текст";

            run6.Append(runProperties6);
            run6.Append(text6);

            paragraph6.Append(paragraphProperties6);
            paragraph6.Append(run6);

            tableCell6.Append(tableCellProperties6);
            tableCell6.Append(paragraph6);

            TableCell tableCell7 = new TableCell();

            TableCellProperties tableCellProperties7 = new TableCellProperties();
            TableCellWidth tableCellWidth7 = new TableCellWidth() { Width = "1039", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders7 = new TableCellBorders();
            TopBorder topBorder8 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder8 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder8 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder8 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders7.Append(topBorder8);
            tableCellBorders7.Append(leftBorder8);
            tableCellBorders7.Append(bottomBorder8);
            tableCellBorders7.Append(rightBorder8);
            Shading shading7 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin5 = new TableCellMargin();
            LeftMargin leftMargin5 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin5.Append(leftMargin5);
            TableCellVerticalAlignment tableCellVerticalAlignment3 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties7.Append(tableCellWidth7);
            tableCellProperties7.Append(tableCellBorders7);
            tableCellProperties7.Append(shading7);
            tableCellProperties7.Append(tableCellMargin5);
            tableCellProperties7.Append(tableCellVerticalAlignment3);

            Paragraph paragraph7 = new Paragraph() { RsidParagraphMarkRevision = "0002594A", RsidParagraphAddition = "002961E3", RsidParagraphProperties = "00C20F46", RsidRunAdditionDefault = "004D4D97" };

            ParagraphProperties paragraphProperties7 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties7 = new ParagraphMarkRunProperties();
            RunFonts runFonts13 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize13 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties7.Append(runFonts13);
            paragraphMarkRunProperties7.Append(fontSize13);
            paragraphMarkRunProperties7.Append(fontSizeComplexScript13);

            paragraphProperties7.Append(paragraphMarkRunProperties7);

            Run run7 = new Run();

            RunProperties runProperties7 = new RunProperties();
            RunFonts runFonts14 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize14 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript14 = new FontSizeComplexScript() { Val = "16" };

            runProperties7.Append(runFonts14);
            runProperties7.Append(fontSize14);
            runProperties7.Append(fontSizeComplexScript14);
            Text text7 = new Text();
            text7.Text = "текст";

            run7.Append(runProperties7);
            run7.Append(text7);

            paragraph7.Append(paragraphProperties7);
            paragraph7.Append(run7);

            tableCell7.Append(tableCellProperties7);
            tableCell7.Append(paragraph7);

            TableCell tableCell8 = new TableCell();

            TableCellProperties tableCellProperties8 = new TableCellProperties();
            TableCellWidth tableCellWidth8 = new TableCellWidth() { Width = "1853", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders8 = new TableCellBorders();
            TopBorder topBorder9 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder9 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder9 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder9 = new RightBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders8.Append(topBorder9);
            tableCellBorders8.Append(leftBorder9);
            tableCellBorders8.Append(bottomBorder9);
            tableCellBorders8.Append(rightBorder9);
            Shading shading8 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin6 = new TableCellMargin();
            LeftMargin leftMargin6 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin6.Append(leftMargin6);
            TableCellVerticalAlignment tableCellVerticalAlignment4 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties8.Append(tableCellWidth8);
            tableCellProperties8.Append(tableCellBorders8);
            tableCellProperties8.Append(shading8);
            tableCellProperties8.Append(tableCellMargin6);
            tableCellProperties8.Append(tableCellVerticalAlignment4);

            Paragraph paragraph8 = new Paragraph() { RsidParagraphMarkRevision = "00667990", RsidParagraphAddition = "002961E3", RsidParagraphProperties = "00C20F46", RsidRunAdditionDefault = "004D4D97" };

            ParagraphProperties paragraphProperties8 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties8 = new ParagraphMarkRunProperties();
            RunFonts runFonts15 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize15 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript15 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties8.Append(runFonts15);
            paragraphMarkRunProperties8.Append(fontSize15);
            paragraphMarkRunProperties8.Append(fontSizeComplexScript15);

            paragraphProperties8.Append(paragraphMarkRunProperties8);

            Run run8 = new Run();

            RunProperties runProperties8 = new RunProperties();
            RunFonts runFonts16 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize16 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript16 = new FontSizeComplexScript() { Val = "16" };

            runProperties8.Append(runFonts16);
            runProperties8.Append(fontSize16);
            runProperties8.Append(fontSizeComplexScript16);
            Text text8 = new Text();
            text8.Text = "текст";
            

            run8.Append(runProperties8);
            run8.Append(text8);

            paragraph8.Append(paragraphProperties8);
            paragraph8.Append(run8);

            tableCell8.Append(tableCellProperties8);
            tableCell8.Append(paragraph8);

            tableRow2.Append(tableCell5);
            tableRow2.Append(tableCell6);
            tableRow2.Append(tableCell7);
            tableRow2.Append(tableCell8);

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);
            table1.Append(tableRow2);
            return table1;
        }



        // Creates an Paragraph instance and adds its children.
        public static Paragraph GenerateParamsParagraph()
        {
            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00667990", RsidParagraphAddition = "00820AEF", RsidParagraphProperties = "00820AEF", RsidRunAdditionDefault = "00667990" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "a4" };

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold1 = new Bold();
            FontSize fontSize1 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "20" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphStyleId1);
            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run() { RsidRunProperties = "00667990" };

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold2 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "20" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(bold2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Text text1 = new Text();
            text1.Text = "Параметры";

            run1.Append(runProperties1);
            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);
            return paragraph1;
        }

        // Creates an Table instance and adds its children.
        public static Table GenerateFunctuionResultTable()
        {
            Table table1 = new Table();

            TableProperties tableProperties1 = new TableProperties();
            TableWidth tableWidth1 = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };

            TableBorders tableBorders1 = new TableBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Nil };
            InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.Nil };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 0, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 0, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);
            TableLook tableLook1 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableCellMarginDefault1);
            tableProperties1.Append(tableLook1);

            TableGrid tableGrid1 = new TableGrid();
            GridColumn gridColumn1 = new GridColumn() { Width = "1502" };
            GridColumn gridColumn2 = new GridColumn() { Width = "9072" };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);

            TableRow tableRow1 = new TableRow() { RsidTableRowMarkRevision = "00667990", RsidTableRowAddition = "00FF4227", RsidTableRowProperties = "00FF4227" };

            TableCell tableCell1 = new TableCell();

            TableCellProperties tableCellProperties1 = new TableCellProperties();
            TableCellWidth tableCellWidth1 = new TableCellWidth() { Width = "710", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders1 = new TableCellBorders();
            TopBorder topBorder2 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder2 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder2 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders1.Append(topBorder2);
            tableCellBorders1.Append(leftBorder2);
            tableCellBorders1.Append(bottomBorder2);
            tableCellBorders1.Append(rightBorder2);
            Shading shading1 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin1 = new TableCellMargin();
            LeftMargin leftMargin1 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin1.Append(leftMargin1);
            TableCellVerticalAlignment tableCellVerticalAlignment1 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties1.Append(tableCellWidth1);
            tableCellProperties1.Append(tableCellBorders1);
            tableCellProperties1.Append(shading1);
            tableCellProperties1.Append(tableCellMargin1);
            tableCellProperties1.Append(tableCellVerticalAlignment1);

            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00FD0905", RsidParagraphAddition = "00FF4227", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "00FF4227" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold1 = new Bold();
            BoldComplexScript boldComplexScript1 = new BoldComplexScript();
            FontSize fontSize1 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(boldComplexScript1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run();

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold2 = new Bold();
            BoldComplexScript boldComplexScript2 = new BoldComplexScript();
            FontSize fontSize2 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "16" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(bold2);
            runProperties1.Append(boldComplexScript2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Text text1 = new Text();
            text1.Text = "Тип данных";

            run1.Append(runProperties1);
            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);

            tableCell1.Append(tableCellProperties1);
            tableCell1.Append(paragraph1);

            TableCell tableCell2 = new TableCell();

            TableCellProperties tableCellProperties2 = new TableCellProperties();
            TableCellWidth tableCellWidth2 = new TableCellWidth() { Width = "4290", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders2 = new TableCellBorders();
            TopBorder topBorder3 = new TopBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder3 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder3 = new RightBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders2.Append(topBorder3);
            tableCellBorders2.Append(leftBorder3);
            tableCellBorders2.Append(bottomBorder3);
            tableCellBorders2.Append(rightBorder3);
            Shading shading2 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin2 = new TableCellMargin();
            LeftMargin leftMargin2 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin2.Append(leftMargin2);
            TableCellVerticalAlignment tableCellVerticalAlignment2 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties2.Append(tableCellWidth2);
            tableCellProperties2.Append(tableCellBorders2);
            tableCellProperties2.Append(shading2);
            tableCellProperties2.Append(tableCellMargin2);
            tableCellProperties2.Append(tableCellVerticalAlignment2);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphMarkRevision = "00667990", RsidParagraphAddition = "00FF4227", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "00FF4227" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold3 = new Bold();
            BoldComplexScript boldComplexScript3 = new BoldComplexScript();
            FontSize fontSize3 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties2.Append(runFonts3);
            paragraphMarkRunProperties2.Append(bold3);
            paragraphMarkRunProperties2.Append(boldComplexScript3);
            paragraphMarkRunProperties2.Append(fontSize3);
            paragraphMarkRunProperties2.Append(fontSizeComplexScript3);

            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run() { RsidRunProperties = "00667990" };

            RunProperties runProperties2 = new RunProperties();
            RunFonts runFonts4 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold4 = new Bold();
            BoldComplexScript boldComplexScript4 = new BoldComplexScript();
            FontSize fontSize4 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "16" };

            runProperties2.Append(runFonts4);
            runProperties2.Append(bold4);
            runProperties2.Append(boldComplexScript4);
            runProperties2.Append(fontSize4);
            runProperties2.Append(fontSizeComplexScript4);
            Text text2 = new Text();
            text2.Text = "Описание";

            run2.Append(runProperties2);
            run2.Append(text2);

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run2);

            tableCell2.Append(tableCellProperties2);
            tableCell2.Append(paragraph2);

            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);

            TableRow tableRow2 = new TableRow() { RsidTableRowMarkRevision = "00667990", RsidTableRowAddition = "00FF4227", RsidTableRowProperties = "00FF4227" };

            TableCell tableCell3 = new TableCell();

            TableCellProperties tableCellProperties3 = new TableCellProperties();
            TableCellWidth tableCellWidth3 = new TableCellWidth() { Width = "710", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders3 = new TableCellBorders();
            TopBorder topBorder4 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder4 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder4 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder4 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders3.Append(topBorder4);
            tableCellBorders3.Append(leftBorder4);
            tableCellBorders3.Append(bottomBorder4);
            tableCellBorders3.Append(rightBorder4);
            Shading shading3 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin3 = new TableCellMargin();
            LeftMargin leftMargin3 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin3.Append(leftMargin3);
            TableCellVerticalAlignment tableCellVerticalAlignment3 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties3.Append(tableCellWidth3);
            tableCellProperties3.Append(tableCellBorders3);
            tableCellProperties3.Append(shading3);
            tableCellProperties3.Append(tableCellMargin3);
            tableCellProperties3.Append(tableCellVerticalAlignment3);

            Paragraph paragraph3 = new Paragraph() { RsidParagraphMarkRevision = "0002594A", RsidParagraphAddition = "00FF4227", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "00FF4227" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
            RunFonts runFonts5 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize5 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties3.Append(runFonts5);
            paragraphMarkRunProperties3.Append(fontSize5);
            paragraphMarkRunProperties3.Append(fontSizeComplexScript5);

            paragraphProperties3.Append(paragraphMarkRunProperties3);

            Run run3 = new Run();

            RunProperties runProperties3 = new RunProperties();
            RunFonts runFonts6 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize6 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "16" };

            runProperties3.Append(runFonts6);
            runProperties3.Append(fontSize6);
            runProperties3.Append(fontSizeComplexScript6);
            Text text3 = new Text();
            text3.Text = "текст";

            run3.Append(runProperties3);
            run3.Append(text3);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "1" };
            BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "1" };

            paragraph3.Append(paragraphProperties3);
            paragraph3.Append(run3);
            paragraph3.Append(bookmarkStart1);
            paragraph3.Append(bookmarkEnd1);

            tableCell3.Append(tableCellProperties3);
            tableCell3.Append(paragraph3);

            TableCell tableCell4 = new TableCell();

            TableCellProperties tableCellProperties4 = new TableCellProperties();
            TableCellWidth tableCellWidth4 = new TableCellWidth() { Width = "4290", Type = TableWidthUnitValues.Pct };

            TableCellBorders tableCellBorders4 = new TableCellBorders();
            TopBorder topBorder5 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder5 = new LeftBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder5 = new BottomBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder5 = new RightBorder() { Val = BorderValues.Single, Color = "000001", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders4.Append(topBorder5);
            tableCellBorders4.Append(leftBorder5);
            tableCellBorders4.Append(bottomBorder5);
            tableCellBorders4.Append(rightBorder5);
            Shading shading4 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

            TableCellMargin tableCellMargin4 = new TableCellMargin();
            LeftMargin leftMargin4 = new LeftMargin() { Width = "103", Type = TableWidthUnitValues.Dxa };

            tableCellMargin4.Append(leftMargin4);
            TableCellVerticalAlignment tableCellVerticalAlignment4 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

            tableCellProperties4.Append(tableCellWidth4);
            tableCellProperties4.Append(tableCellBorders4);
            tableCellProperties4.Append(shading4);
            tableCellProperties4.Append(tableCellMargin4);
            tableCellProperties4.Append(tableCellVerticalAlignment4);

            Paragraph paragraph4 = new Paragraph() { RsidParagraphMarkRevision = "00667990", RsidParagraphAddition = "00FF4227", RsidParagraphProperties = "001F49E5", RsidRunAdditionDefault = "00FF4227" };

            ParagraphProperties paragraphProperties4 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
            RunFonts runFonts7 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize7 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties4.Append(runFonts7);
            paragraphMarkRunProperties4.Append(fontSize7);
            paragraphMarkRunProperties4.Append(fontSizeComplexScript7);

            paragraphProperties4.Append(paragraphMarkRunProperties4);

            Run run4 = new Run();

            RunProperties runProperties4 = new RunProperties();
            RunFonts runFonts8 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize8 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "16" };

            runProperties4.Append(runFonts8);
            runProperties4.Append(fontSize8);
            runProperties4.Append(fontSizeComplexScript8);
            Text text4 = new Text();
            text4.Text = "текст";

            run4.Append(runProperties4);
            run4.Append(text4);

            paragraph4.Append(paragraphProperties4);
            paragraph4.Append(run4);

            tableCell4.Append(tableCellProperties4);
            tableCell4.Append(paragraph4);

            tableRow2.Append(tableCell3);
            tableRow2.Append(tableCell4);
            BookmarkEnd bookmarkEnd2 = new BookmarkEnd() { Id = "0" };

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);
            table1.Append(tableRow2);
            table1.Append(bookmarkEnd2);
            return table1;
        }


        // Creates an Paragraph instance and adds its children.
        public static Paragraph GenerateFunctionResultParagraph()
        {
            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00FF4227", RsidParagraphAddition = "00A52419", RsidRunAdditionDefault = "00FF4227" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold1 = new Bold();
            FontSize fontSize1 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "20" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphMarkRunProperties1);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_Toc388858671", Id = "0" };

            Run run1 = new Run();

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold2 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "20" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(bold2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Text text1 = new Text();
            text1.Text = "Возвращаемое значение";

            run1.Append(runProperties1);
            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(bookmarkStart1);
            paragraph1.Append(run1);
            return paragraph1;
        }


        public static List<OpenXmlElement> ConvertToMultiLineText(Text template, string inputText, string[] delimeters)
        {
            List<OpenXmlElement> result = new List<OpenXmlElement>();

            try
            {
                var text = (string.IsNullOrWhiteSpace(inputText) ? string.Empty : inputText).Split(delimeters, new StringSplitOptions());

                for (int i = 0; i <= text.Count() - 1; i++)
                {
                    var tmpText = (template.Clone() as Text);
                    tmpText.Text = text[i];

                    result.Add(tmpText);

                    if (i != text.Count() - 1)
                    {
                        result.Add(new Break());
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Ошибка конвертации в мультилайн текст.", exception);
            }            

            return result;
        }

        // Creates an Paragraph instance and adds its children.
        public static Paragraph GenerateSummaryParagraph(string inputText)
        {
            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00FD0905", RsidParagraphAddition = "00FD0905", RsidParagraphProperties = "00820AEF", RsidRunAdditionDefault = "006B7D79" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "a4" };

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize1 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "16" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphStyleId1);
            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run();

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            FontSize fontSize2 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "16" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Text text1 = new Text();
            text1.Text = "";

            run1.Append(runProperties1);
            run1.Append(text1);

            OpenXmlElement insertAfter = text1;

            foreach (OpenXmlElement currentElement in DocxWorker.ConvertToMultiLineText(text1, inputText, DocxWorker.TextLinesDelimeters))
            {
                insertAfter.InsertAfterSelf(currentElement);
                insertAfter = currentElement;
            }

            text1.Remove();           

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);
            return paragraph1;
        }


        // Creates an Paragraph instance and adds its children.
        public static Paragraph GenerateProcNameParagraph(string procedureName)
        {
            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "006B7D79", RsidParagraphAddition = "00667990", RsidParagraphProperties = "00820AEF", RsidRunAdditionDefault = "006B7D79" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "a4" };

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold1 = new Bold();
            FontSize fontSize1 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "20" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphStyleId1);
            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run();

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
            Bold bold2 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "20" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(bold2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Text text1 = new Text();
            text1.Text = procedureName;

            run1.Append(runProperties1);
            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);
            return paragraph1;
        }

    }
}

using System;
using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Ds = DocumentFormat.OpenXml.CustomXmlDataProperties;
using A = DocumentFormat.OpenXml.Drawing;
using M = DocumentFormat.OpenXml.Math;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;

namespace Vitasoft.DocMaker.Core
{
    public class NewDocDocxTemplate : IDisposable
    {
        public WordprocessingDocument Document { get; private set; }

        public NewDocDocxTemplate(string filePath, bool autoSave)
        {
            this.CreatePackage(filePath, autoSave);
        }

        // Creates a WordprocessingDocument.
        private void CreatePackage(string filePath, bool autoSave = true)
        {
            Document =
            WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document, autoSave);

            CreateParts(Document);
        }


        // Adds child parts and generates content of the specified part.
        private void CreateParts(WordprocessingDocument document)
        {
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            MainDocumentPart mainDocumentPart1 = document.AddMainDocumentPart();
            GenerateMainDocumentPart1Content(mainDocumentPart1);

            EndnotesPart endnotesPart1 = mainDocumentPart1.AddNewPart<EndnotesPart>("rId8");
            GenerateEndnotesPart1Content(endnotesPart1);

            StyleDefinitionsPart styleDefinitionsPart1 = mainDocumentPart1.AddNewPart<StyleDefinitionsPart>("rId3");
            GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

            FootnotesPart footnotesPart1 = mainDocumentPart1.AddNewPart<FootnotesPart>("rId7");
            GenerateFootnotesPart1Content(footnotesPart1);

            NumberingDefinitionsPart numberingDefinitionsPart1 = mainDocumentPart1.AddNewPart<NumberingDefinitionsPart>("rId2");
            GenerateNumberingDefinitionsPart1Content(numberingDefinitionsPart1);

            CustomXmlPart customXmlPart1 = mainDocumentPart1.AddNewPart<CustomXmlPart>("application/xml", "rId1");
            GenerateCustomXmlPart1Content(customXmlPart1);

            CustomXmlPropertiesPart customXmlPropertiesPart1 = customXmlPart1.AddNewPart<CustomXmlPropertiesPart>("rId1");
            GenerateCustomXmlPropertiesPart1Content(customXmlPropertiesPart1);

            WebSettingsPart webSettingsPart1 = mainDocumentPart1.AddNewPart<WebSettingsPart>("rId6");
            GenerateWebSettingsPart1Content(webSettingsPart1);

            ThemePart themePart1 = mainDocumentPart1.AddNewPart<ThemePart>("rId11");
            GenerateThemePart1Content(themePart1);

            DocumentSettingsPart documentSettingsPart1 = mainDocumentPart1.AddNewPart<DocumentSettingsPart>("rId5");
            GenerateDocumentSettingsPart1Content(documentSettingsPart1);

            documentSettingsPart1.AddExternalRelationship("http://schemas.openxmlformats.org/officeDocument/2006/relationships/attachedTemplate", new System.Uri("file:///C:\\Temp\\Объекты%20ОРВД.dotx", System.UriKind.Absolute), "rId1");
            FontTablePart fontTablePart1 = mainDocumentPart1.AddNewPart<FontTablePart>("rId10");
            GenerateFontTablePart1Content(fontTablePart1);

            StylesWithEffectsPart stylesWithEffectsPart1 = mainDocumentPart1.AddNewPart<StylesWithEffectsPart>("rId4");
            GenerateStylesWithEffectsPart1Content(stylesWithEffectsPart1);

            FooterPart footerPart1 = mainDocumentPart1.AddNewPart<FooterPart>("rId9");
            GenerateFooterPart1Content(footerPart1);

            SetPackageProperties(document);
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.Template template1 = new Ap.Template();
            template1.Text = "Объекты ОРВД.dotx";
            Ap.TotalTime totalTime1 = new Ap.TotalTime();
            totalTime1.Text = "16";
            Ap.Pages pages1 = new Ap.Pages();
            pages1.Text = "2";
            Ap.Words words1 = new Ap.Words();
            words1.Text = "10";
            Ap.Characters characters1 = new Ap.Characters();
            characters1.Text = "59";
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Office Word";
            Ap.DocumentSecurity documentSecurity1 = new Ap.DocumentSecurity();
            documentSecurity1.Text = "0";
            Ap.Lines lines1 = new Ap.Lines();
            lines1.Text = "1";
            Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
            paragraphs1.Text = "1";
            Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
            scaleCrop1.Text = "false";

            Ap.HeadingPairs headingPairs1 = new Ap.HeadingPairs();

            Vt.VTVector vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)2U };

            Vt.Variant variant1 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR1 = new Vt.VTLPSTR();
            vTLPSTR1.Text = "Название";

            variant1.Append(vTLPSTR1);

            Vt.Variant variant2 = new Vt.Variant();
            Vt.VTInt32 vTInt321 = new Vt.VTInt32();
            vTInt321.Text = "1";

            variant2.Append(vTInt321);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);

            headingPairs1.Append(vTVector1);

            Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

            Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)1U };
            Vt.VTLPSTR vTLPSTR2 = new Vt.VTLPSTR();
            vTLPSTR2.Text = "";

            vTVector2.Append(vTLPSTR2);

            titlesOfParts1.Append(vTVector2);
            Ap.Company company1 = new Ap.Company();
            company1.Text = "";
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.CharactersWithSpaces charactersWithSpaces1 = new Ap.CharactersWithSpaces();
            charactersWithSpaces1.Text = "68";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
            applicationVersion1.Text = "14.0000";

            properties1.Append(template1);
            properties1.Append(totalTime1);
            properties1.Append(pages1);
            properties1.Append(words1);
            properties1.Append(characters1);
            properties1.Append(application1);
            properties1.Append(documentSecurity1);
            properties1.Append(lines1);
            properties1.Append(paragraphs1);
            properties1.Append(scaleCrop1);
            properties1.Append(headingPairs1);
            properties1.Append(titlesOfParts1);
            properties1.Append(company1);
            properties1.Append(linksUpToDate1);
            properties1.Append(charactersWithSpaces1);
            properties1.Append(sharedDocument1);
            properties1.Append(hyperlinksChanged1);
            properties1.Append(applicationVersion1);

            extendedFilePropertiesPart1.Properties = properties1;
        }

        // Generates content of mainDocumentPart1.
        private void GenerateMainDocumentPart1Content(MainDocumentPart mainDocumentPart1)
        {
            Document document1 = new Document() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            document1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            document1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            document1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            document1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            document1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            document1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            document1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            document1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            document1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            document1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            document1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            document1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            document1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Body body1 = new Body();

            Paragraph paragraph1 = new Paragraph() { RsidParagraphAddition = "008042CE", RsidParagraphProperties = "00A6561E", RsidRunAdditionDefault = "00E827F1" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            Bold bold1 = new Bold();
            BoldComplexScript boldComplexScript1 = new BoldComplexScript();
            NoProof noProof1 = new NoProof();

            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(boldComplexScript1);
            paragraphMarkRunProperties1.Append(noProof1);

            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run();
            FieldChar fieldChar1 = new FieldChar() { FieldCharType = FieldCharValues.Begin };

            run1.Append(fieldChar1);

            Run run2 = new Run();
            FieldCode fieldCode1 = new FieldCode() { Space = SpaceProcessingModeValues.Preserve };
            fieldCode1.Text = " TOC \\o \\h \\z \\u ";

            run2.Append(fieldCode1);

            Run run3 = new Run();
            FieldChar fieldChar2 = new FieldChar() { FieldCharType = FieldCharValues.Separate };

            run3.Append(fieldChar2);

            Run run4 = new Run() { RsidRunAddition = "00E174D4" };

            RunProperties runProperties1 = new RunProperties();
            Bold bold2 = new Bold();
            BoldComplexScript boldComplexScript2 = new BoldComplexScript();
            NoProof noProof2 = new NoProof();

            runProperties1.Append(bold2);
            runProperties1.Append(boldComplexScript2);
            runProperties1.Append(noProof2);
            Text text1 = new Text();
            text1.Text = "Для отображения оглавления обновите это поле.";

            run4.Append(runProperties1);
            run4.Append(text1);

            Run run5 = new Run();

            RunProperties runProperties2 = new RunProperties();
            Bold bold3 = new Bold();
            BoldComplexScript boldComplexScript3 = new BoldComplexScript();
            NoProof noProof3 = new NoProof();

            runProperties2.Append(bold3);
            runProperties2.Append(boldComplexScript3);
            runProperties2.Append(noProof3);
            FieldChar fieldChar3 = new FieldChar() { FieldCharType = FieldCharValues.End };

            run5.Append(runProperties2);
            run5.Append(fieldChar3);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);
            paragraph1.Append(run2);
            paragraph1.Append(run3);
            paragraph1.Append(run4);
            paragraph1.Append(run5);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphAddition = "008042CE", RsidRunAdditionDefault = "008042CE" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
            Bold bold4 = new Bold();
            BoldComplexScript boldComplexScript4 = new BoldComplexScript();
            NoProof noProof4 = new NoProof();

            paragraphMarkRunProperties2.Append(bold4);
            paragraphMarkRunProperties2.Append(boldComplexScript4);
            paragraphMarkRunProperties2.Append(noProof4);

            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run6 = new Run();

            RunProperties runProperties3 = new RunProperties();
            Bold bold5 = new Bold();
            BoldComplexScript boldComplexScript5 = new BoldComplexScript();
            NoProof noProof5 = new NoProof();

            runProperties3.Append(bold5);
            runProperties3.Append(boldComplexScript5);
            runProperties3.Append(noProof5);
            Break break1 = new Break() { Type = BreakValues.Page };

            run6.Append(runProperties3);
            run6.Append(break1);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "0" };
            BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "0" };

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run6);
            paragraph2.Append(bookmarkStart1);
            paragraph2.Append(bookmarkEnd1);
            Paragraph paragraph3 = new Paragraph() { RsidParagraphMarkRevision = "00A6561E", RsidParagraphAddition = "00DB5B7C", RsidParagraphProperties = "00A6561E", RsidRunAdditionDefault = "00DB5B7C" };

            SectionProperties sectionProperties1 = new SectionProperties() { RsidRPr = "00A6561E", RsidR = "00DB5B7C", RsidSect = "00820AEF" };
            FooterReference footerReference1 = new FooterReference() { Type = HeaderFooterValues.Default, Id = "rId9" };
            PageSize pageSize1 = new PageSize() { Width = (UInt32Value)11906U, Height = (UInt32Value)16838U };
            PageMargin pageMargin1 = new PageMargin() { Top = 720, Right = (UInt32Value)720U, Bottom = 720, Left = (UInt32Value)720U, Header = (UInt32Value)708U, Footer = (UInt32Value)708U, Gutter = (UInt32Value)0U };
            Columns columns1 = new Columns() { Space = "708" };
            DocGrid docGrid1 = new DocGrid() { LinePitch = 360 };

            sectionProperties1.Append(footerReference1);
            sectionProperties1.Append(pageSize1);
            sectionProperties1.Append(pageMargin1);
            sectionProperties1.Append(columns1);
            sectionProperties1.Append(docGrid1);

            body1.Append(paragraph1);
            body1.Append(paragraph2);
            body1.Append(paragraph3);
            body1.Append(sectionProperties1);

            document1.Append(body1);

            mainDocumentPart1.Document = document1;
        }

        // Generates content of endnotesPart1.
        private void GenerateEndnotesPart1Content(EndnotesPart endnotesPart1)
        {
            Endnotes endnotes1 = new Endnotes() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            endnotes1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            endnotes1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            endnotes1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            endnotes1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            endnotes1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            endnotes1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            endnotes1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            endnotes1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            endnotes1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            endnotes1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            endnotes1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            endnotes1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            endnotes1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            endnotes1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            endnotes1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Endnote endnote1 = new Endnote() { Type = FootnoteEndnoteValues.Separator, Id = -1 };

            Paragraph paragraph4 = new Paragraph() { RsidParagraphAddition = "00E827F1", RsidParagraphProperties = "00946533", RsidRunAdditionDefault = "00E827F1" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();
            SpacingBetweenLines spacingBetweenLines1 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            paragraphProperties3.Append(spacingBetweenLines1);

            Run run7 = new Run();
            SeparatorMark separatorMark1 = new SeparatorMark();

            run7.Append(separatorMark1);

            paragraph4.Append(paragraphProperties3);
            paragraph4.Append(run7);

            endnote1.Append(paragraph4);

            Endnote endnote2 = new Endnote() { Type = FootnoteEndnoteValues.ContinuationSeparator, Id = 0 };

            Paragraph paragraph5 = new Paragraph() { RsidParagraphAddition = "00E827F1", RsidParagraphProperties = "00946533", RsidRunAdditionDefault = "00E827F1" };

            ParagraphProperties paragraphProperties4 = new ParagraphProperties();
            SpacingBetweenLines spacingBetweenLines2 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            paragraphProperties4.Append(spacingBetweenLines2);

            Run run8 = new Run();
            ContinuationSeparatorMark continuationSeparatorMark1 = new ContinuationSeparatorMark();

            run8.Append(continuationSeparatorMark1);

            paragraph5.Append(paragraphProperties4);
            paragraph5.Append(run8);

            endnote2.Append(paragraph5);

            endnotes1.Append(endnote1);
            endnotes1.Append(endnote2);

            endnotesPart1.Endnotes = endnotes1;
        }

        // Generates content of styleDefinitionsPart1.
        private void GenerateStyleDefinitionsPart1Content(StyleDefinitionsPart styleDefinitionsPart1)
        {
            Styles styles1 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            styles1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

            DocDefaults docDefaults1 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault1 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle1 = new RunPropertiesBaseStyle();
            RunFonts runFonts1 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
            FontSize fontSize1 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "22" };
            Languages languages1 = new Languages() { Val = "ru-RU", EastAsia = "en-US", Bidi = "ar-SA" };

            runPropertiesBaseStyle1.Append(runFonts1);
            runPropertiesBaseStyle1.Append(fontSize1);
            runPropertiesBaseStyle1.Append(fontSizeComplexScript1);
            runPropertiesBaseStyle1.Append(languages1);

            runPropertiesDefault1.Append(runPropertiesBaseStyle1);

            ParagraphPropertiesDefault paragraphPropertiesDefault1 = new ParagraphPropertiesDefault();

            ParagraphPropertiesBaseStyle paragraphPropertiesBaseStyle1 = new ParagraphPropertiesBaseStyle();
            SpacingBetweenLines spacingBetweenLines3 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };

            paragraphPropertiesBaseStyle1.Append(spacingBetweenLines3);

            paragraphPropertiesDefault1.Append(paragraphPropertiesBaseStyle1);

            docDefaults1.Append(runPropertiesDefault1);
            docDefaults1.Append(paragraphPropertiesDefault1);

            LatentStyles latentStyles1 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = true, DefaultUnhideWhenUsed = true, DefaultPrimaryStyle = false, Count = 267 };
            LatentStyleExceptionInfo latentStyleExceptionInfo1 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo2 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo3 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 0, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo4 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 0, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo5 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo6 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo7 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo8 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo9 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo10 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo11 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo12 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo13 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo14 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo15 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo16 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo17 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo18 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo19 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo20 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo21 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo22 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1 };
            LatentStyleExceptionInfo latentStyleExceptionInfo23 = new LatentStyleExceptionInfo() { Name = "Body Text", UiPriority = 0 };
            LatentStyleExceptionInfo latentStyleExceptionInfo24 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo25 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo26 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo27 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo28 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo29 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo30 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo31 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo32 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo33 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo34 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo35 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo36 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo37 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo38 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo39 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo40 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo41 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo42 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo43 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo44 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo45 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo46 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo47 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo48 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo49 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo50 = new LatentStyleExceptionInfo() { Name = "Revision", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo51 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo52 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo53 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo54 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo55 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo56 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo57 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo58 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo59 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo60 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo61 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo62 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo63 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo64 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo65 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo66 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo67 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo68 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo69 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo70 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo71 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo72 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo73 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo74 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo75 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo76 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo77 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo78 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo79 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo80 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo81 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo82 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo83 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo84 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo85 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo86 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo87 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo88 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo89 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo90 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo91 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo92 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo93 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo94 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo95 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo96 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo97 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo98 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo99 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo100 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo101 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo102 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo103 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo104 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo105 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo106 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo107 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo108 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo109 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo110 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo111 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo112 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo113 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo114 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo115 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo116 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo117 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo118 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo119 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo120 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo121 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo122 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo123 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo124 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo125 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo126 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo127 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo128 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo129 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo130 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo131 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo132 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo133 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo134 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo135 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo136 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo137 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37 };
            LatentStyleExceptionInfo latentStyleExceptionInfo138 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, PrimaryStyle = true };

            latentStyles1.Append(latentStyleExceptionInfo1);
            latentStyles1.Append(latentStyleExceptionInfo2);
            latentStyles1.Append(latentStyleExceptionInfo3);
            latentStyles1.Append(latentStyleExceptionInfo4);
            latentStyles1.Append(latentStyleExceptionInfo5);
            latentStyles1.Append(latentStyleExceptionInfo6);
            latentStyles1.Append(latentStyleExceptionInfo7);
            latentStyles1.Append(latentStyleExceptionInfo8);
            latentStyles1.Append(latentStyleExceptionInfo9);
            latentStyles1.Append(latentStyleExceptionInfo10);
            latentStyles1.Append(latentStyleExceptionInfo11);
            latentStyles1.Append(latentStyleExceptionInfo12);
            latentStyles1.Append(latentStyleExceptionInfo13);
            latentStyles1.Append(latentStyleExceptionInfo14);
            latentStyles1.Append(latentStyleExceptionInfo15);
            latentStyles1.Append(latentStyleExceptionInfo16);
            latentStyles1.Append(latentStyleExceptionInfo17);
            latentStyles1.Append(latentStyleExceptionInfo18);
            latentStyles1.Append(latentStyleExceptionInfo19);
            latentStyles1.Append(latentStyleExceptionInfo20);
            latentStyles1.Append(latentStyleExceptionInfo21);
            latentStyles1.Append(latentStyleExceptionInfo22);
            latentStyles1.Append(latentStyleExceptionInfo23);
            latentStyles1.Append(latentStyleExceptionInfo24);
            latentStyles1.Append(latentStyleExceptionInfo25);
            latentStyles1.Append(latentStyleExceptionInfo26);
            latentStyles1.Append(latentStyleExceptionInfo27);
            latentStyles1.Append(latentStyleExceptionInfo28);
            latentStyles1.Append(latentStyleExceptionInfo29);
            latentStyles1.Append(latentStyleExceptionInfo30);
            latentStyles1.Append(latentStyleExceptionInfo31);
            latentStyles1.Append(latentStyleExceptionInfo32);
            latentStyles1.Append(latentStyleExceptionInfo33);
            latentStyles1.Append(latentStyleExceptionInfo34);
            latentStyles1.Append(latentStyleExceptionInfo35);
            latentStyles1.Append(latentStyleExceptionInfo36);
            latentStyles1.Append(latentStyleExceptionInfo37);
            latentStyles1.Append(latentStyleExceptionInfo38);
            latentStyles1.Append(latentStyleExceptionInfo39);
            latentStyles1.Append(latentStyleExceptionInfo40);
            latentStyles1.Append(latentStyleExceptionInfo41);
            latentStyles1.Append(latentStyleExceptionInfo42);
            latentStyles1.Append(latentStyleExceptionInfo43);
            latentStyles1.Append(latentStyleExceptionInfo44);
            latentStyles1.Append(latentStyleExceptionInfo45);
            latentStyles1.Append(latentStyleExceptionInfo46);
            latentStyles1.Append(latentStyleExceptionInfo47);
            latentStyles1.Append(latentStyleExceptionInfo48);
            latentStyles1.Append(latentStyleExceptionInfo49);
            latentStyles1.Append(latentStyleExceptionInfo50);
            latentStyles1.Append(latentStyleExceptionInfo51);
            latentStyles1.Append(latentStyleExceptionInfo52);
            latentStyles1.Append(latentStyleExceptionInfo53);
            latentStyles1.Append(latentStyleExceptionInfo54);
            latentStyles1.Append(latentStyleExceptionInfo55);
            latentStyles1.Append(latentStyleExceptionInfo56);
            latentStyles1.Append(latentStyleExceptionInfo57);
            latentStyles1.Append(latentStyleExceptionInfo58);
            latentStyles1.Append(latentStyleExceptionInfo59);
            latentStyles1.Append(latentStyleExceptionInfo60);
            latentStyles1.Append(latentStyleExceptionInfo61);
            latentStyles1.Append(latentStyleExceptionInfo62);
            latentStyles1.Append(latentStyleExceptionInfo63);
            latentStyles1.Append(latentStyleExceptionInfo64);
            latentStyles1.Append(latentStyleExceptionInfo65);
            latentStyles1.Append(latentStyleExceptionInfo66);
            latentStyles1.Append(latentStyleExceptionInfo67);
            latentStyles1.Append(latentStyleExceptionInfo68);
            latentStyles1.Append(latentStyleExceptionInfo69);
            latentStyles1.Append(latentStyleExceptionInfo70);
            latentStyles1.Append(latentStyleExceptionInfo71);
            latentStyles1.Append(latentStyleExceptionInfo72);
            latentStyles1.Append(latentStyleExceptionInfo73);
            latentStyles1.Append(latentStyleExceptionInfo74);
            latentStyles1.Append(latentStyleExceptionInfo75);
            latentStyles1.Append(latentStyleExceptionInfo76);
            latentStyles1.Append(latentStyleExceptionInfo77);
            latentStyles1.Append(latentStyleExceptionInfo78);
            latentStyles1.Append(latentStyleExceptionInfo79);
            latentStyles1.Append(latentStyleExceptionInfo80);
            latentStyles1.Append(latentStyleExceptionInfo81);
            latentStyles1.Append(latentStyleExceptionInfo82);
            latentStyles1.Append(latentStyleExceptionInfo83);
            latentStyles1.Append(latentStyleExceptionInfo84);
            latentStyles1.Append(latentStyleExceptionInfo85);
            latentStyles1.Append(latentStyleExceptionInfo86);
            latentStyles1.Append(latentStyleExceptionInfo87);
            latentStyles1.Append(latentStyleExceptionInfo88);
            latentStyles1.Append(latentStyleExceptionInfo89);
            latentStyles1.Append(latentStyleExceptionInfo90);
            latentStyles1.Append(latentStyleExceptionInfo91);
            latentStyles1.Append(latentStyleExceptionInfo92);
            latentStyles1.Append(latentStyleExceptionInfo93);
            latentStyles1.Append(latentStyleExceptionInfo94);
            latentStyles1.Append(latentStyleExceptionInfo95);
            latentStyles1.Append(latentStyleExceptionInfo96);
            latentStyles1.Append(latentStyleExceptionInfo97);
            latentStyles1.Append(latentStyleExceptionInfo98);
            latentStyles1.Append(latentStyleExceptionInfo99);
            latentStyles1.Append(latentStyleExceptionInfo100);
            latentStyles1.Append(latentStyleExceptionInfo101);
            latentStyles1.Append(latentStyleExceptionInfo102);
            latentStyles1.Append(latentStyleExceptionInfo103);
            latentStyles1.Append(latentStyleExceptionInfo104);
            latentStyles1.Append(latentStyleExceptionInfo105);
            latentStyles1.Append(latentStyleExceptionInfo106);
            latentStyles1.Append(latentStyleExceptionInfo107);
            latentStyles1.Append(latentStyleExceptionInfo108);
            latentStyles1.Append(latentStyleExceptionInfo109);
            latentStyles1.Append(latentStyleExceptionInfo110);
            latentStyles1.Append(latentStyleExceptionInfo111);
            latentStyles1.Append(latentStyleExceptionInfo112);
            latentStyles1.Append(latentStyleExceptionInfo113);
            latentStyles1.Append(latentStyleExceptionInfo114);
            latentStyles1.Append(latentStyleExceptionInfo115);
            latentStyles1.Append(latentStyleExceptionInfo116);
            latentStyles1.Append(latentStyleExceptionInfo117);
            latentStyles1.Append(latentStyleExceptionInfo118);
            latentStyles1.Append(latentStyleExceptionInfo119);
            latentStyles1.Append(latentStyleExceptionInfo120);
            latentStyles1.Append(latentStyleExceptionInfo121);
            latentStyles1.Append(latentStyleExceptionInfo122);
            latentStyles1.Append(latentStyleExceptionInfo123);
            latentStyles1.Append(latentStyleExceptionInfo124);
            latentStyles1.Append(latentStyleExceptionInfo125);
            latentStyles1.Append(latentStyleExceptionInfo126);
            latentStyles1.Append(latentStyleExceptionInfo127);
            latentStyles1.Append(latentStyleExceptionInfo128);
            latentStyles1.Append(latentStyleExceptionInfo129);
            latentStyles1.Append(latentStyleExceptionInfo130);
            latentStyles1.Append(latentStyleExceptionInfo131);
            latentStyles1.Append(latentStyleExceptionInfo132);
            latentStyles1.Append(latentStyleExceptionInfo133);
            latentStyles1.Append(latentStyleExceptionInfo134);
            latentStyles1.Append(latentStyleExceptionInfo135);
            latentStyles1.Append(latentStyleExceptionInfo136);
            latentStyles1.Append(latentStyleExceptionInfo137);
            latentStyles1.Append(latentStyleExceptionInfo138);

            Style style1 = new Style() { Type = StyleValues.Paragraph, StyleId = "a0", Default = true };
            StyleName styleName1 = new StyleName() { Val = "Normal" };
            PrimaryStyle primaryStyle1 = new PrimaryStyle();

            style1.Append(styleName1);
            style1.Append(primaryStyle1);

            Style style2 = new Style() { Type = StyleValues.Paragraph, StyleId = "1" };
            StyleName styleName2 = new StyleName() { Val = "heading 1" };
            BasedOn basedOn1 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle1 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle1 = new LinkedStyle() { Val = "10" };
            UIPriority uIPriority1 = new UIPriority() { Val = 9 };
            PrimaryStyle primaryStyle2 = new PrimaryStyle();
            Rsid rsid1 = new Rsid() { Val = "00056893" };

            StyleParagraphProperties styleParagraphProperties1 = new StyleParagraphProperties();
            KeepNext keepNext1 = new KeepNext();
            KeepLines keepLines1 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines4 = new SpacingBetweenLines() { Before = "480", After = "0" };
            OutlineLevel outlineLevel1 = new OutlineLevel() { Val = 0 };

            styleParagraphProperties1.Append(keepNext1);
            styleParagraphProperties1.Append(keepLines1);
            styleParagraphProperties1.Append(spacingBetweenLines4);
            styleParagraphProperties1.Append(outlineLevel1);

            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            RunFonts runFonts2 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold6 = new Bold();
            BoldComplexScript boldComplexScript6 = new BoldComplexScript();
            Color color1 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
            FontSize fontSize2 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties1.Append(runFonts2);
            styleRunProperties1.Append(bold6);
            styleRunProperties1.Append(boldComplexScript6);
            styleRunProperties1.Append(color1);
            styleRunProperties1.Append(fontSize2);
            styleRunProperties1.Append(fontSizeComplexScript2);

            style2.Append(styleName2);
            style2.Append(basedOn1);
            style2.Append(nextParagraphStyle1);
            style2.Append(linkedStyle1);
            style2.Append(uIPriority1);
            style2.Append(primaryStyle2);
            style2.Append(rsid1);
            style2.Append(styleParagraphProperties1);
            style2.Append(styleRunProperties1);

            Style style3 = new Style() { Type = StyleValues.Paragraph, StyleId = "2" };
            StyleName styleName3 = new StyleName() { Val = "heading 2" };
            BasedOn basedOn2 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle2 = new LinkedStyle() { Val = "20" };
            Rsid rsid2 = new Rsid() { Val = "00820AEF" };

            StyleParagraphProperties styleParagraphProperties2 = new StyleParagraphProperties();
            KeepNext keepNext2 = new KeepNext();

            Tabs tabs1 = new Tabs();
            TabStop tabStop1 = new TabStop() { Val = TabStopValues.Left, Position = 709 };

            tabs1.Append(tabStop1);
            SuppressAutoHyphens suppressAutoHyphens1 = new SuppressAutoHyphens();
            SpacingBetweenLines spacingBetweenLines5 = new SpacingBetweenLines() { Before = "200", After = "0", Line = "276", LineRule = LineSpacingRuleValues.AtLeast };
            OutlineLevel outlineLevel2 = new OutlineLevel() { Val = 1 };

            styleParagraphProperties2.Append(keepNext2);
            styleParagraphProperties2.Append(tabs1);
            styleParagraphProperties2.Append(suppressAutoHyphens1);
            styleParagraphProperties2.Append(spacingBetweenLines5);
            styleParagraphProperties2.Append(outlineLevel2);

            StyleRunProperties styleRunProperties2 = new StyleRunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "SimSun" };
            Bold bold7 = new Bold();
            BoldComplexScript boldComplexScript7 = new BoldComplexScript();
            Color color2 = new Color() { Val = "4F81BD" };
            FontSize fontSize3 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "26" };

            styleRunProperties2.Append(runFonts3);
            styleRunProperties2.Append(bold7);
            styleRunProperties2.Append(boldComplexScript7);
            styleRunProperties2.Append(color2);
            styleRunProperties2.Append(fontSize3);
            styleRunProperties2.Append(fontSizeComplexScript3);

            style3.Append(styleName3);
            style3.Append(basedOn2);
            style3.Append(linkedStyle2);
            style3.Append(rsid2);
            style3.Append(styleParagraphProperties2);
            style3.Append(styleRunProperties2);

            Style style4 = new Style() { Type = StyleValues.Paragraph, StyleId = "3" };
            StyleName styleName4 = new StyleName() { Val = "heading 3" };
            BasedOn basedOn3 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle3 = new LinkedStyle() { Val = "30" };
            Rsid rsid3 = new Rsid() { Val = "00820AEF" };

            StyleParagraphProperties styleParagraphProperties3 = new StyleParagraphProperties();
            KeepNext keepNext3 = new KeepNext();

            Tabs tabs2 = new Tabs();
            TabStop tabStop2 = new TabStop() { Val = TabStopValues.Left, Position = 709 };

            tabs2.Append(tabStop2);
            SuppressAutoHyphens suppressAutoHyphens2 = new SuppressAutoHyphens();
            SpacingBetweenLines spacingBetweenLines6 = new SpacingBetweenLines() { Before = "240", After = "120", Line = "276", LineRule = LineSpacingRuleValues.AtLeast };
            OutlineLevel outlineLevel3 = new OutlineLevel() { Val = 2 };

            styleParagraphProperties3.Append(keepNext3);
            styleParagraphProperties3.Append(tabs2);
            styleParagraphProperties3.Append(suppressAutoHyphens2);
            styleParagraphProperties3.Append(spacingBetweenLines6);
            styleParagraphProperties3.Append(outlineLevel3);

            StyleRunProperties styleRunProperties3 = new StyleRunProperties();
            RunFonts runFonts4 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", EastAsia = "SimSun", ComplexScript = "Mangal" };
            Bold bold8 = new Bold();
            BoldComplexScript boldComplexScript8 = new BoldComplexScript();
            Color color3 = new Color() { Val = "00000A" };
            FontSize fontSize4 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties3.Append(runFonts4);
            styleRunProperties3.Append(bold8);
            styleRunProperties3.Append(boldComplexScript8);
            styleRunProperties3.Append(color3);
            styleRunProperties3.Append(fontSize4);
            styleRunProperties3.Append(fontSizeComplexScript4);

            style4.Append(styleName4);
            style4.Append(basedOn3);
            style4.Append(linkedStyle3);
            style4.Append(rsid3);
            style4.Append(styleParagraphProperties3);
            style4.Append(styleRunProperties3);

            Style style5 = new Style() { Type = StyleValues.Paragraph, StyleId = "4" };
            StyleName styleName5 = new StyleName() { Val = "heading 4" };
            BasedOn basedOn4 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle2 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle4 = new LinkedStyle() { Val = "40" };
            UIPriority uIPriority2 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed1 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle3 = new PrimaryStyle();
            Rsid rsid4 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties4 = new StyleParagraphProperties();
            KeepNext keepNext4 = new KeepNext();
            KeepLines keepLines2 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines7 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel4 = new OutlineLevel() { Val = 3 };

            styleParagraphProperties4.Append(keepNext4);
            styleParagraphProperties4.Append(keepLines2);
            styleParagraphProperties4.Append(spacingBetweenLines7);
            styleParagraphProperties4.Append(outlineLevel4);

            StyleRunProperties styleRunProperties4 = new StyleRunProperties();
            RunFonts runFonts5 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold9 = new Bold();
            BoldComplexScript boldComplexScript9 = new BoldComplexScript();
            Italic italic1 = new Italic();
            ItalicComplexScript italicComplexScript1 = new ItalicComplexScript();
            Color color4 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties4.Append(runFonts5);
            styleRunProperties4.Append(bold9);
            styleRunProperties4.Append(boldComplexScript9);
            styleRunProperties4.Append(italic1);
            styleRunProperties4.Append(italicComplexScript1);
            styleRunProperties4.Append(color4);

            style5.Append(styleName5);
            style5.Append(basedOn4);
            style5.Append(nextParagraphStyle2);
            style5.Append(linkedStyle4);
            style5.Append(uIPriority2);
            style5.Append(unhideWhenUsed1);
            style5.Append(primaryStyle3);
            style5.Append(rsid4);
            style5.Append(styleParagraphProperties4);
            style5.Append(styleRunProperties4);

            Style style6 = new Style() { Type = StyleValues.Paragraph, StyleId = "5" };
            StyleName styleName6 = new StyleName() { Val = "heading 5" };
            BasedOn basedOn5 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle3 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle5 = new LinkedStyle() { Val = "50" };
            UIPriority uIPriority3 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed2 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle4 = new PrimaryStyle();
            Rsid rsid5 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties5 = new StyleParagraphProperties();
            KeepNext keepNext5 = new KeepNext();
            KeepLines keepLines3 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines8 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel5 = new OutlineLevel() { Val = 4 };

            styleParagraphProperties5.Append(keepNext5);
            styleParagraphProperties5.Append(keepLines3);
            styleParagraphProperties5.Append(spacingBetweenLines8);
            styleParagraphProperties5.Append(outlineLevel5);

            StyleRunProperties styleRunProperties5 = new StyleRunProperties();
            RunFonts runFonts6 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color5 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties5.Append(runFonts6);
            styleRunProperties5.Append(color5);

            style6.Append(styleName6);
            style6.Append(basedOn5);
            style6.Append(nextParagraphStyle3);
            style6.Append(linkedStyle5);
            style6.Append(uIPriority3);
            style6.Append(unhideWhenUsed2);
            style6.Append(primaryStyle4);
            style6.Append(rsid5);
            style6.Append(styleParagraphProperties5);
            style6.Append(styleRunProperties5);

            Style style7 = new Style() { Type = StyleValues.Paragraph, StyleId = "6" };
            StyleName styleName7 = new StyleName() { Val = "heading 6" };
            BasedOn basedOn6 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle4 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle6 = new LinkedStyle() { Val = "60" };
            UIPriority uIPriority4 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed3 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle5 = new PrimaryStyle();
            Rsid rsid6 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties6 = new StyleParagraphProperties();
            KeepNext keepNext6 = new KeepNext();
            KeepLines keepLines4 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines9 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel6 = new OutlineLevel() { Val = 5 };

            styleParagraphProperties6.Append(keepNext6);
            styleParagraphProperties6.Append(keepLines4);
            styleParagraphProperties6.Append(spacingBetweenLines9);
            styleParagraphProperties6.Append(outlineLevel6);

            StyleRunProperties styleRunProperties6 = new StyleRunProperties();
            RunFonts runFonts7 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic2 = new Italic();
            ItalicComplexScript italicComplexScript2 = new ItalicComplexScript();
            Color color6 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties6.Append(runFonts7);
            styleRunProperties6.Append(italic2);
            styleRunProperties6.Append(italicComplexScript2);
            styleRunProperties6.Append(color6);

            style7.Append(styleName7);
            style7.Append(basedOn6);
            style7.Append(nextParagraphStyle4);
            style7.Append(linkedStyle6);
            style7.Append(uIPriority4);
            style7.Append(unhideWhenUsed3);
            style7.Append(primaryStyle5);
            style7.Append(rsid6);
            style7.Append(styleParagraphProperties6);
            style7.Append(styleRunProperties6);

            Style style8 = new Style() { Type = StyleValues.Paragraph, StyleId = "7" };
            StyleName styleName8 = new StyleName() { Val = "heading 7" };
            BasedOn basedOn7 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle5 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle7 = new LinkedStyle() { Val = "70" };
            UIPriority uIPriority5 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed4 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle6 = new PrimaryStyle();
            Rsid rsid7 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties7 = new StyleParagraphProperties();
            KeepNext keepNext7 = new KeepNext();
            KeepLines keepLines5 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines10 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel7 = new OutlineLevel() { Val = 6 };

            styleParagraphProperties7.Append(keepNext7);
            styleParagraphProperties7.Append(keepLines5);
            styleParagraphProperties7.Append(spacingBetweenLines10);
            styleParagraphProperties7.Append(outlineLevel7);

            StyleRunProperties styleRunProperties7 = new StyleRunProperties();
            RunFonts runFonts8 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic3 = new Italic();
            ItalicComplexScript italicComplexScript3 = new ItalicComplexScript();
            Color color7 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };

            styleRunProperties7.Append(runFonts8);
            styleRunProperties7.Append(italic3);
            styleRunProperties7.Append(italicComplexScript3);
            styleRunProperties7.Append(color7);

            style8.Append(styleName8);
            style8.Append(basedOn7);
            style8.Append(nextParagraphStyle5);
            style8.Append(linkedStyle7);
            style8.Append(uIPriority5);
            style8.Append(unhideWhenUsed4);
            style8.Append(primaryStyle6);
            style8.Append(rsid7);
            style8.Append(styleParagraphProperties7);
            style8.Append(styleRunProperties7);

            Style style9 = new Style() { Type = StyleValues.Paragraph, StyleId = "8" };
            StyleName styleName9 = new StyleName() { Val = "heading 8" };
            BasedOn basedOn8 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle6 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle8 = new LinkedStyle() { Val = "80" };
            UIPriority uIPriority6 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed5 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle7 = new PrimaryStyle();
            Rsid rsid8 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties8 = new StyleParagraphProperties();
            KeepNext keepNext8 = new KeepNext();
            KeepLines keepLines6 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines11 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel8 = new OutlineLevel() { Val = 7 };

            styleParagraphProperties8.Append(keepNext8);
            styleParagraphProperties8.Append(keepLines6);
            styleParagraphProperties8.Append(spacingBetweenLines11);
            styleParagraphProperties8.Append(outlineLevel8);

            StyleRunProperties styleRunProperties8 = new StyleRunProperties();
            RunFonts runFonts9 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color8 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize5 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties8.Append(runFonts9);
            styleRunProperties8.Append(color8);
            styleRunProperties8.Append(fontSize5);
            styleRunProperties8.Append(fontSizeComplexScript5);

            style9.Append(styleName9);
            style9.Append(basedOn8);
            style9.Append(nextParagraphStyle6);
            style9.Append(linkedStyle8);
            style9.Append(uIPriority6);
            style9.Append(unhideWhenUsed5);
            style9.Append(primaryStyle7);
            style9.Append(rsid8);
            style9.Append(styleParagraphProperties8);
            style9.Append(styleRunProperties8);

            Style style10 = new Style() { Type = StyleValues.Paragraph, StyleId = "9" };
            StyleName styleName10 = new StyleName() { Val = "heading 9" };
            BasedOn basedOn9 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle7 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle9 = new LinkedStyle() { Val = "90" };
            UIPriority uIPriority7 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed6 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle8 = new PrimaryStyle();
            Rsid rsid9 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties9 = new StyleParagraphProperties();
            KeepNext keepNext9 = new KeepNext();
            KeepLines keepLines7 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines12 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel9 = new OutlineLevel() { Val = 8 };

            styleParagraphProperties9.Append(keepNext9);
            styleParagraphProperties9.Append(keepLines7);
            styleParagraphProperties9.Append(spacingBetweenLines12);
            styleParagraphProperties9.Append(outlineLevel9);

            StyleRunProperties styleRunProperties9 = new StyleRunProperties();
            RunFonts runFonts10 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic4 = new Italic();
            ItalicComplexScript italicComplexScript4 = new ItalicComplexScript();
            Color color9 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize6 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties9.Append(runFonts10);
            styleRunProperties9.Append(italic4);
            styleRunProperties9.Append(italicComplexScript4);
            styleRunProperties9.Append(color9);
            styleRunProperties9.Append(fontSize6);
            styleRunProperties9.Append(fontSizeComplexScript6);

            style10.Append(styleName10);
            style10.Append(basedOn9);
            style10.Append(nextParagraphStyle7);
            style10.Append(linkedStyle9);
            style10.Append(uIPriority7);
            style10.Append(unhideWhenUsed6);
            style10.Append(primaryStyle8);
            style10.Append(rsid9);
            style10.Append(styleParagraphProperties9);
            style10.Append(styleRunProperties9);

            Style style11 = new Style() { Type = StyleValues.Character, StyleId = "a1", Default = true };
            StyleName styleName11 = new StyleName() { Val = "Default Paragraph Font" };
            UIPriority uIPriority8 = new UIPriority() { Val = 1 };
            SemiHidden semiHidden1 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed7 = new UnhideWhenUsed();

            style11.Append(styleName11);
            style11.Append(uIPriority8);
            style11.Append(semiHidden1);
            style11.Append(unhideWhenUsed7);

            Style style12 = new Style() { Type = StyleValues.Table, StyleId = "a2", Default = true };
            StyleName styleName12 = new StyleName() { Val = "Normal Table" };
            UIPriority uIPriority9 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden2 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed8 = new UnhideWhenUsed();

            StyleTableProperties styleTableProperties1 = new StyleTableProperties();
            TableIndentation tableIndentation1 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TopMargin topMargin1 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin1 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(topMargin1);
            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(bottomMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);

            styleTableProperties1.Append(tableIndentation1);
            styleTableProperties1.Append(tableCellMarginDefault1);

            style12.Append(styleName12);
            style12.Append(uIPriority9);
            style12.Append(semiHidden2);
            style12.Append(unhideWhenUsed8);
            style12.Append(styleTableProperties1);

            Style style13 = new Style() { Type = StyleValues.Numbering, StyleId = "a3", Default = true };
            StyleName styleName13 = new StyleName() { Val = "No List" };
            UIPriority uIPriority10 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden3 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed9 = new UnhideWhenUsed();

            style13.Append(styleName13);
            style13.Append(uIPriority10);
            style13.Append(semiHidden3);
            style13.Append(unhideWhenUsed9);

            Style style14 = new Style() { Type = StyleValues.Character, StyleId = "20", CustomStyle = true };
            StyleName styleName14 = new StyleName() { Val = "Заголовок 2 Знак" };
            BasedOn basedOn10 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle10 = new LinkedStyle() { Val = "2" };
            Rsid rsid10 = new Rsid() { Val = "00820AEF" };

            StyleRunProperties styleRunProperties10 = new StyleRunProperties();
            RunFonts runFonts11 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "SimSun" };
            Bold bold10 = new Bold();
            BoldComplexScript boldComplexScript10 = new BoldComplexScript();
            Color color10 = new Color() { Val = "4F81BD" };
            FontSize fontSize7 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "26" };

            styleRunProperties10.Append(runFonts11);
            styleRunProperties10.Append(bold10);
            styleRunProperties10.Append(boldComplexScript10);
            styleRunProperties10.Append(color10);
            styleRunProperties10.Append(fontSize7);
            styleRunProperties10.Append(fontSizeComplexScript7);

            style14.Append(styleName14);
            style14.Append(basedOn10);
            style14.Append(linkedStyle10);
            style14.Append(rsid10);
            style14.Append(styleRunProperties10);

            Style style15 = new Style() { Type = StyleValues.Character, StyleId = "30", CustomStyle = true };
            StyleName styleName15 = new StyleName() { Val = "Заголовок 3 Знак" };
            BasedOn basedOn11 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle11 = new LinkedStyle() { Val = "3" };
            Rsid rsid11 = new Rsid() { Val = "00820AEF" };

            StyleRunProperties styleRunProperties11 = new StyleRunProperties();
            RunFonts runFonts12 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", EastAsia = "SimSun", ComplexScript = "Mangal" };
            Bold bold11 = new Bold();
            BoldComplexScript boldComplexScript11 = new BoldComplexScript();
            Color color11 = new Color() { Val = "00000A" };
            FontSize fontSize8 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties11.Append(runFonts12);
            styleRunProperties11.Append(bold11);
            styleRunProperties11.Append(boldComplexScript11);
            styleRunProperties11.Append(color11);
            styleRunProperties11.Append(fontSize8);
            styleRunProperties11.Append(fontSizeComplexScript8);

            style15.Append(styleName15);
            style15.Append(basedOn11);
            style15.Append(linkedStyle11);
            style15.Append(rsid11);
            style15.Append(styleRunProperties11);

            Style style16 = new Style() { Type = StyleValues.Paragraph, StyleId = "a4" };
            StyleName styleName16 = new StyleName() { Val = "Body Text" };
            BasedOn basedOn12 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle12 = new LinkedStyle() { Val = "a5" };
            Rsid rsid12 = new Rsid() { Val = "00820AEF" };

            StyleParagraphProperties styleParagraphProperties10 = new StyleParagraphProperties();

            Tabs tabs3 = new Tabs();
            TabStop tabStop3 = new TabStop() { Val = TabStopValues.Left, Position = 709 };

            tabs3.Append(tabStop3);
            SuppressAutoHyphens suppressAutoHyphens3 = new SuppressAutoHyphens();
            SpacingBetweenLines spacingBetweenLines13 = new SpacingBetweenLines() { After = "120", Line = "276", LineRule = LineSpacingRuleValues.AtLeast };

            styleParagraphProperties10.Append(tabs3);
            styleParagraphProperties10.Append(suppressAutoHyphens3);
            styleParagraphProperties10.Append(spacingBetweenLines13);

            StyleRunProperties styleRunProperties12 = new StyleRunProperties();
            RunFonts runFonts13 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "SimSun" };
            Color color12 = new Color() { Val = "00000A" };

            styleRunProperties12.Append(runFonts13);
            styleRunProperties12.Append(color12);

            style16.Append(styleName16);
            style16.Append(basedOn12);
            style16.Append(linkedStyle12);
            style16.Append(rsid12);
            style16.Append(styleParagraphProperties10);
            style16.Append(styleRunProperties12);

            Style style17 = new Style() { Type = StyleValues.Character, StyleId = "a5", CustomStyle = true };
            StyleName styleName17 = new StyleName() { Val = "Основной текст Знак" };
            BasedOn basedOn13 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle13 = new LinkedStyle() { Val = "a4" };
            Rsid rsid13 = new Rsid() { Val = "00820AEF" };

            StyleRunProperties styleRunProperties13 = new StyleRunProperties();
            RunFonts runFonts14 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "SimSun" };
            Color color13 = new Color() { Val = "00000A" };

            styleRunProperties13.Append(runFonts14);
            styleRunProperties13.Append(color13);

            style17.Append(styleName17);
            style17.Append(basedOn13);
            style17.Append(linkedStyle13);
            style17.Append(rsid13);
            style17.Append(styleRunProperties13);

            Style style18 = new Style() { Type = StyleValues.Paragraph, StyleId = "a", CustomStyle = true };
            StyleName styleName18 = new StyleName() { Val = "заголовок орвд" };
            BasedOn basedOn14 = new BasedOn() { Val = "3" };
            PrimaryStyle primaryStyle9 = new PrimaryStyle();
            Rsid rsid14 = new Rsid() { Val = "00820AEF" };

            StyleParagraphProperties styleParagraphProperties11 = new StyleParagraphProperties();

            NumberingProperties numberingProperties1 = new NumberingProperties();
            NumberingLevelReference numberingLevelReference1 = new NumberingLevelReference() { Val = 2 };
            NumberingId numberingId1 = new NumberingId() { Val = 1 };

            numberingProperties1.Append(numberingLevelReference1);
            numberingProperties1.Append(numberingId1);

            styleParagraphProperties11.Append(numberingProperties1);

            style18.Append(styleName18);
            style18.Append(basedOn14);
            style18.Append(primaryStyle9);
            style18.Append(rsid14);
            style18.Append(styleParagraphProperties11);

            Style style19 = new Style() { Type = StyleValues.Character, StyleId = "40", CustomStyle = true };
            StyleName styleName19 = new StyleName() { Val = "Заголовок 4 Знак" };
            BasedOn basedOn15 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle14 = new LinkedStyle() { Val = "4" };
            UIPriority uIPriority11 = new UIPriority() { Val = 9 };
            Rsid rsid15 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties14 = new StyleRunProperties();
            RunFonts runFonts15 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold12 = new Bold();
            BoldComplexScript boldComplexScript12 = new BoldComplexScript();
            Italic italic5 = new Italic();
            ItalicComplexScript italicComplexScript5 = new ItalicComplexScript();
            Color color14 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties14.Append(runFonts15);
            styleRunProperties14.Append(bold12);
            styleRunProperties14.Append(boldComplexScript12);
            styleRunProperties14.Append(italic5);
            styleRunProperties14.Append(italicComplexScript5);
            styleRunProperties14.Append(color14);

            style19.Append(styleName19);
            style19.Append(basedOn15);
            style19.Append(linkedStyle14);
            style19.Append(uIPriority11);
            style19.Append(rsid15);
            style19.Append(styleRunProperties14);

            Style style20 = new Style() { Type = StyleValues.Character, StyleId = "50", CustomStyle = true };
            StyleName styleName20 = new StyleName() { Val = "Заголовок 5 Знак" };
            BasedOn basedOn16 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle15 = new LinkedStyle() { Val = "5" };
            UIPriority uIPriority12 = new UIPriority() { Val = 9 };
            Rsid rsid16 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties15 = new StyleRunProperties();
            RunFonts runFonts16 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color15 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties15.Append(runFonts16);
            styleRunProperties15.Append(color15);

            style20.Append(styleName20);
            style20.Append(basedOn16);
            style20.Append(linkedStyle15);
            style20.Append(uIPriority12);
            style20.Append(rsid16);
            style20.Append(styleRunProperties15);

            Style style21 = new Style() { Type = StyleValues.Character, StyleId = "60", CustomStyle = true };
            StyleName styleName21 = new StyleName() { Val = "Заголовок 6 Знак" };
            BasedOn basedOn17 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle16 = new LinkedStyle() { Val = "6" };
            UIPriority uIPriority13 = new UIPriority() { Val = 9 };
            Rsid rsid17 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties16 = new StyleRunProperties();
            RunFonts runFonts17 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic6 = new Italic();
            ItalicComplexScript italicComplexScript6 = new ItalicComplexScript();
            Color color16 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties16.Append(runFonts17);
            styleRunProperties16.Append(italic6);
            styleRunProperties16.Append(italicComplexScript6);
            styleRunProperties16.Append(color16);

            style21.Append(styleName21);
            style21.Append(basedOn17);
            style21.Append(linkedStyle16);
            style21.Append(uIPriority13);
            style21.Append(rsid17);
            style21.Append(styleRunProperties16);

            Style style22 = new Style() { Type = StyleValues.Character, StyleId = "70", CustomStyle = true };
            StyleName styleName22 = new StyleName() { Val = "Заголовок 7 Знак" };
            BasedOn basedOn18 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle17 = new LinkedStyle() { Val = "7" };
            UIPriority uIPriority14 = new UIPriority() { Val = 9 };
            Rsid rsid18 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties17 = new StyleRunProperties();
            RunFonts runFonts18 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic7 = new Italic();
            ItalicComplexScript italicComplexScript7 = new ItalicComplexScript();
            Color color17 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };

            styleRunProperties17.Append(runFonts18);
            styleRunProperties17.Append(italic7);
            styleRunProperties17.Append(italicComplexScript7);
            styleRunProperties17.Append(color17);

            style22.Append(styleName22);
            style22.Append(basedOn18);
            style22.Append(linkedStyle17);
            style22.Append(uIPriority14);
            style22.Append(rsid18);
            style22.Append(styleRunProperties17);

            Style style23 = new Style() { Type = StyleValues.Character, StyleId = "80", CustomStyle = true };
            StyleName styleName23 = new StyleName() { Val = "Заголовок 8 Знак" };
            BasedOn basedOn19 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle18 = new LinkedStyle() { Val = "8" };
            UIPriority uIPriority15 = new UIPriority() { Val = 9 };
            Rsid rsid19 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties18 = new StyleRunProperties();
            RunFonts runFonts19 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color18 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize9 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties18.Append(runFonts19);
            styleRunProperties18.Append(color18);
            styleRunProperties18.Append(fontSize9);
            styleRunProperties18.Append(fontSizeComplexScript9);

            style23.Append(styleName23);
            style23.Append(basedOn19);
            style23.Append(linkedStyle18);
            style23.Append(uIPriority15);
            style23.Append(rsid19);
            style23.Append(styleRunProperties18);

            Style style24 = new Style() { Type = StyleValues.Character, StyleId = "90", CustomStyle = true };
            StyleName styleName24 = new StyleName() { Val = "Заголовок 9 Знак" };
            BasedOn basedOn20 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle19 = new LinkedStyle() { Val = "9" };
            UIPriority uIPriority16 = new UIPriority() { Val = 9 };
            Rsid rsid20 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties19 = new StyleRunProperties();
            RunFonts runFonts20 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic8 = new Italic();
            ItalicComplexScript italicComplexScript8 = new ItalicComplexScript();
            Color color19 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize10 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties19.Append(runFonts20);
            styleRunProperties19.Append(italic8);
            styleRunProperties19.Append(italicComplexScript8);
            styleRunProperties19.Append(color19);
            styleRunProperties19.Append(fontSize10);
            styleRunProperties19.Append(fontSizeComplexScript10);

            style24.Append(styleName24);
            style24.Append(basedOn20);
            style24.Append(linkedStyle19);
            style24.Append(uIPriority16);
            style24.Append(rsid20);
            style24.Append(styleRunProperties19);

            Style style25 = new Style() { Type = StyleValues.Paragraph, StyleId = "a6" };
            StyleName styleName25 = new StyleName() { Val = "header" };
            BasedOn basedOn21 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle20 = new LinkedStyle() { Val = "a7" };
            UIPriority uIPriority17 = new UIPriority() { Val = 99 };
            UnhideWhenUsed unhideWhenUsed10 = new UnhideWhenUsed();
            Rsid rsid21 = new Rsid() { Val = "00946533" };

            StyleParagraphProperties styleParagraphProperties12 = new StyleParagraphProperties();

            Tabs tabs4 = new Tabs();
            TabStop tabStop4 = new TabStop() { Val = TabStopValues.Center, Position = 4677 };
            TabStop tabStop5 = new TabStop() { Val = TabStopValues.Right, Position = 9355 };

            tabs4.Append(tabStop4);
            tabs4.Append(tabStop5);
            SpacingBetweenLines spacingBetweenLines14 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties12.Append(tabs4);
            styleParagraphProperties12.Append(spacingBetweenLines14);

            style25.Append(styleName25);
            style25.Append(basedOn21);
            style25.Append(linkedStyle20);
            style25.Append(uIPriority17);
            style25.Append(unhideWhenUsed10);
            style25.Append(rsid21);
            style25.Append(styleParagraphProperties12);

            Style style26 = new Style() { Type = StyleValues.Character, StyleId = "a7", CustomStyle = true };
            StyleName styleName26 = new StyleName() { Val = "Верхний колонтитул Знак" };
            BasedOn basedOn22 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle21 = new LinkedStyle() { Val = "a6" };
            UIPriority uIPriority18 = new UIPriority() { Val = 99 };
            Rsid rsid22 = new Rsid() { Val = "00946533" };

            style26.Append(styleName26);
            style26.Append(basedOn22);
            style26.Append(linkedStyle21);
            style26.Append(uIPriority18);
            style26.Append(rsid22);

            Style style27 = new Style() { Type = StyleValues.Paragraph, StyleId = "a8" };
            StyleName styleName27 = new StyleName() { Val = "footer" };
            BasedOn basedOn23 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle22 = new LinkedStyle() { Val = "a9" };
            UIPriority uIPriority19 = new UIPriority() { Val = 99 };
            UnhideWhenUsed unhideWhenUsed11 = new UnhideWhenUsed();
            Rsid rsid23 = new Rsid() { Val = "00946533" };

            StyleParagraphProperties styleParagraphProperties13 = new StyleParagraphProperties();

            Tabs tabs5 = new Tabs();
            TabStop tabStop6 = new TabStop() { Val = TabStopValues.Center, Position = 4677 };
            TabStop tabStop7 = new TabStop() { Val = TabStopValues.Right, Position = 9355 };

            tabs5.Append(tabStop6);
            tabs5.Append(tabStop7);
            SpacingBetweenLines spacingBetweenLines15 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties13.Append(tabs5);
            styleParagraphProperties13.Append(spacingBetweenLines15);

            style27.Append(styleName27);
            style27.Append(basedOn23);
            style27.Append(linkedStyle22);
            style27.Append(uIPriority19);
            style27.Append(unhideWhenUsed11);
            style27.Append(rsid23);
            style27.Append(styleParagraphProperties13);

            Style style28 = new Style() { Type = StyleValues.Character, StyleId = "a9", CustomStyle = true };
            StyleName styleName28 = new StyleName() { Val = "Нижний колонтитул Знак" };
            BasedOn basedOn24 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle23 = new LinkedStyle() { Val = "a8" };
            UIPriority uIPriority20 = new UIPriority() { Val = 99 };
            Rsid rsid24 = new Rsid() { Val = "00946533" };

            style28.Append(styleName28);
            style28.Append(basedOn24);
            style28.Append(linkedStyle23);
            style28.Append(uIPriority20);
            style28.Append(rsid24);

            Style style29 = new Style() { Type = StyleValues.Character, StyleId = "10", CustomStyle = true };
            StyleName styleName29 = new StyleName() { Val = "Заголовок 1 Знак" };
            BasedOn basedOn25 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle24 = new LinkedStyle() { Val = "1" };
            UIPriority uIPriority21 = new UIPriority() { Val = 9 };
            Rsid rsid25 = new Rsid() { Val = "00056893" };

            StyleRunProperties styleRunProperties20 = new StyleRunProperties();
            RunFonts runFonts21 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold13 = new Bold();
            BoldComplexScript boldComplexScript13 = new BoldComplexScript();
            Color color20 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
            FontSize fontSize11 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties20.Append(runFonts21);
            styleRunProperties20.Append(bold13);
            styleRunProperties20.Append(boldComplexScript13);
            styleRunProperties20.Append(color20);
            styleRunProperties20.Append(fontSize11);
            styleRunProperties20.Append(fontSizeComplexScript11);

            style29.Append(styleName29);
            style29.Append(basedOn25);
            style29.Append(linkedStyle24);
            style29.Append(uIPriority21);
            style29.Append(rsid25);
            style29.Append(styleRunProperties20);

            styles1.Append(docDefaults1);
            styles1.Append(latentStyles1);
            styles1.Append(style1);
            styles1.Append(style2);
            styles1.Append(style3);
            styles1.Append(style4);
            styles1.Append(style5);
            styles1.Append(style6);
            styles1.Append(style7);
            styles1.Append(style8);
            styles1.Append(style9);
            styles1.Append(style10);
            styles1.Append(style11);
            styles1.Append(style12);
            styles1.Append(style13);
            styles1.Append(style14);
            styles1.Append(style15);
            styles1.Append(style16);
            styles1.Append(style17);
            styles1.Append(style18);
            styles1.Append(style19);
            styles1.Append(style20);
            styles1.Append(style21);
            styles1.Append(style22);
            styles1.Append(style23);
            styles1.Append(style24);
            styles1.Append(style25);
            styles1.Append(style26);
            styles1.Append(style27);
            styles1.Append(style28);
            styles1.Append(style29);

            styleDefinitionsPart1.Styles = styles1;
        }

        // Generates content of footnotesPart1.
        private void GenerateFootnotesPart1Content(FootnotesPart footnotesPart1)
        {
            Footnotes footnotes1 = new Footnotes() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            footnotes1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            footnotes1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            footnotes1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            footnotes1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            footnotes1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            footnotes1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            footnotes1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            footnotes1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            footnotes1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            footnotes1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            footnotes1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            footnotes1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            footnotes1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            footnotes1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            footnotes1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Footnote footnote1 = new Footnote() { Type = FootnoteEndnoteValues.Separator, Id = -1 };

            Paragraph paragraph6 = new Paragraph() { RsidParagraphAddition = "00E827F1", RsidParagraphProperties = "00946533", RsidRunAdditionDefault = "00E827F1" };

            ParagraphProperties paragraphProperties5 = new ParagraphProperties();
            SpacingBetweenLines spacingBetweenLines16 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            paragraphProperties5.Append(spacingBetweenLines16);

            Run run9 = new Run();
            SeparatorMark separatorMark2 = new SeparatorMark();

            run9.Append(separatorMark2);

            paragraph6.Append(paragraphProperties5);
            paragraph6.Append(run9);

            footnote1.Append(paragraph6);

            Footnote footnote2 = new Footnote() { Type = FootnoteEndnoteValues.ContinuationSeparator, Id = 0 };

            Paragraph paragraph7 = new Paragraph() { RsidParagraphAddition = "00E827F1", RsidParagraphProperties = "00946533", RsidRunAdditionDefault = "00E827F1" };

            ParagraphProperties paragraphProperties6 = new ParagraphProperties();
            SpacingBetweenLines spacingBetweenLines17 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            paragraphProperties6.Append(spacingBetweenLines17);

            Run run10 = new Run();
            ContinuationSeparatorMark continuationSeparatorMark2 = new ContinuationSeparatorMark();

            run10.Append(continuationSeparatorMark2);

            paragraph7.Append(paragraphProperties6);
            paragraph7.Append(run10);

            footnote2.Append(paragraph7);

            footnotes1.Append(footnote1);
            footnotes1.Append(footnote2);

            footnotesPart1.Footnotes = footnotes1;
        }

        // Generates content of numberingDefinitionsPart1.
        private void GenerateNumberingDefinitionsPart1Content(NumberingDefinitionsPart numberingDefinitionsPart1)
        {
            Numbering numbering1 = new Numbering() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            numbering1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            numbering1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            numbering1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            numbering1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            numbering1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            numbering1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            numbering1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            numbering1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            numbering1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            numbering1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            numbering1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            numbering1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            numbering1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            numbering1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            numbering1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            AbstractNum abstractNum1 = new AbstractNum() { AbstractNumberId = 0 };
            Nsid nsid1 = new Nsid() { Val = "7EF43DAE" };
            MultiLevelType multiLevelType1 = new MultiLevelType() { Val = MultiLevelValues.Multilevel };
            TemplateCode templateCode1 = new TemplateCode() { Val = "822E992E" };

            Level level1 = new Level() { LevelIndex = 0 };
            StartNumberingValue startNumberingValue1 = new StartNumberingValue() { Val = 1 };
            NumberingFormat numberingFormat1 = new NumberingFormat() { Val = NumberFormatValues.None };
            LevelSuffix levelSuffix1 = new LevelSuffix() { Val = LevelSuffixValues.Nothing };
            LevelText levelText1 = new LevelText() { Val = "" };
            LevelJustification levelJustification1 = new LevelJustification() { Val = LevelJustificationValues.Left };

            PreviousParagraphProperties previousParagraphProperties1 = new PreviousParagraphProperties();
            Indentation indentation1 = new Indentation() { Left = "432", Hanging = "432" };

            previousParagraphProperties1.Append(indentation1);

            level1.Append(startNumberingValue1);
            level1.Append(numberingFormat1);
            level1.Append(levelSuffix1);
            level1.Append(levelText1);
            level1.Append(levelJustification1);
            level1.Append(previousParagraphProperties1);

            Level level2 = new Level() { LevelIndex = 1 };
            StartNumberingValue startNumberingValue2 = new StartNumberingValue() { Val = 1 };
            NumberingFormat numberingFormat2 = new NumberingFormat() { Val = NumberFormatValues.None };
            LevelSuffix levelSuffix2 = new LevelSuffix() { Val = LevelSuffixValues.Nothing };
            LevelText levelText2 = new LevelText() { Val = "" };
            LevelJustification levelJustification2 = new LevelJustification() { Val = LevelJustificationValues.Left };

            PreviousParagraphProperties previousParagraphProperties2 = new PreviousParagraphProperties();
            Indentation indentation2 = new Indentation() { Left = "576", Hanging = "576" };

            previousParagraphProperties2.Append(indentation2);

            level2.Append(startNumberingValue2);
            level2.Append(numberingFormat2);
            level2.Append(levelSuffix2);
            level2.Append(levelText2);
            level2.Append(levelJustification2);
            level2.Append(previousParagraphProperties2);

            Level level3 = new Level() { LevelIndex = 2 };
            StartNumberingValue startNumberingValue3 = new StartNumberingValue() { Val = 1 };
            NumberingFormat numberingFormat3 = new NumberingFormat() { Val = NumberFormatValues.None };
            ParagraphStyleIdInLevel paragraphStyleIdInLevel1 = new ParagraphStyleIdInLevel() { Val = "a" };
            LevelSuffix levelSuffix3 = new LevelSuffix() { Val = LevelSuffixValues.Nothing };
            LevelText levelText3 = new LevelText() { Val = "" };
            LevelJustification levelJustification3 = new LevelJustification() { Val = LevelJustificationValues.Left };

            PreviousParagraphProperties previousParagraphProperties3 = new PreviousParagraphProperties();
            Indentation indentation3 = new Indentation() { Left = "720", Hanging = "720" };

            previousParagraphProperties3.Append(indentation3);

            level3.Append(startNumberingValue3);
            level3.Append(numberingFormat3);
            level3.Append(paragraphStyleIdInLevel1);
            level3.Append(levelSuffix3);
            level3.Append(levelText3);
            level3.Append(levelJustification3);
            level3.Append(previousParagraphProperties3);

            Level level4 = new Level() { LevelIndex = 3 };
            StartNumberingValue startNumberingValue4 = new StartNumberingValue() { Val = 1 };
            NumberingFormat numberingFormat4 = new NumberingFormat() { Val = NumberFormatValues.None };
            LevelSuffix levelSuffix4 = new LevelSuffix() { Val = LevelSuffixValues.Nothing };
            LevelText levelText4 = new LevelText() { Val = "" };
            LevelJustification levelJustification4 = new LevelJustification() { Val = LevelJustificationValues.Left };

            PreviousParagraphProperties previousParagraphProperties4 = new PreviousParagraphProperties();
            Indentation indentation4 = new Indentation() { Left = "864", Hanging = "864" };

            previousParagraphProperties4.Append(indentation4);

            level4.Append(startNumberingValue4);
            level4.Append(numberingFormat4);
            level4.Append(levelSuffix4);
            level4.Append(levelText4);
            level4.Append(levelJustification4);
            level4.Append(previousParagraphProperties4);

            Level level5 = new Level() { LevelIndex = 4 };
            StartNumberingValue startNumberingValue5 = new StartNumberingValue() { Val = 1 };
            NumberingFormat numberingFormat5 = new NumberingFormat() { Val = NumberFormatValues.None };
            LevelSuffix levelSuffix5 = new LevelSuffix() { Val = LevelSuffixValues.Nothing };
            LevelText levelText5 = new LevelText() { Val = "" };
            LevelJustification levelJustification5 = new LevelJustification() { Val = LevelJustificationValues.Left };

            PreviousParagraphProperties previousParagraphProperties5 = new PreviousParagraphProperties();
            Indentation indentation5 = new Indentation() { Left = "1008", Hanging = "1008" };

            previousParagraphProperties5.Append(indentation5);

            level5.Append(startNumberingValue5);
            level5.Append(numberingFormat5);
            level5.Append(levelSuffix5);
            level5.Append(levelText5);
            level5.Append(levelJustification5);
            level5.Append(previousParagraphProperties5);

            Level level6 = new Level() { LevelIndex = 5 };
            StartNumberingValue startNumberingValue6 = new StartNumberingValue() { Val = 1 };
            NumberingFormat numberingFormat6 = new NumberingFormat() { Val = NumberFormatValues.None };
            LevelSuffix levelSuffix6 = new LevelSuffix() { Val = LevelSuffixValues.Nothing };
            LevelText levelText6 = new LevelText() { Val = "" };
            LevelJustification levelJustification6 = new LevelJustification() { Val = LevelJustificationValues.Left };

            PreviousParagraphProperties previousParagraphProperties6 = new PreviousParagraphProperties();
            Indentation indentation6 = new Indentation() { Left = "1152", Hanging = "1152" };

            previousParagraphProperties6.Append(indentation6);

            level6.Append(startNumberingValue6);
            level6.Append(numberingFormat6);
            level6.Append(levelSuffix6);
            level6.Append(levelText6);
            level6.Append(levelJustification6);
            level6.Append(previousParagraphProperties6);

            Level level7 = new Level() { LevelIndex = 6 };
            StartNumberingValue startNumberingValue7 = new StartNumberingValue() { Val = 1 };
            NumberingFormat numberingFormat7 = new NumberingFormat() { Val = NumberFormatValues.None };
            LevelSuffix levelSuffix7 = new LevelSuffix() { Val = LevelSuffixValues.Nothing };
            LevelText levelText7 = new LevelText() { Val = "" };
            LevelJustification levelJustification7 = new LevelJustification() { Val = LevelJustificationValues.Left };

            PreviousParagraphProperties previousParagraphProperties7 = new PreviousParagraphProperties();
            Indentation indentation7 = new Indentation() { Left = "1296", Hanging = "1296" };

            previousParagraphProperties7.Append(indentation7);

            level7.Append(startNumberingValue7);
            level7.Append(numberingFormat7);
            level7.Append(levelSuffix7);
            level7.Append(levelText7);
            level7.Append(levelJustification7);
            level7.Append(previousParagraphProperties7);

            Level level8 = new Level() { LevelIndex = 7 };
            StartNumberingValue startNumberingValue8 = new StartNumberingValue() { Val = 1 };
            NumberingFormat numberingFormat8 = new NumberingFormat() { Val = NumberFormatValues.None };
            LevelSuffix levelSuffix8 = new LevelSuffix() { Val = LevelSuffixValues.Nothing };
            LevelText levelText8 = new LevelText() { Val = "" };
            LevelJustification levelJustification8 = new LevelJustification() { Val = LevelJustificationValues.Left };

            PreviousParagraphProperties previousParagraphProperties8 = new PreviousParagraphProperties();
            Indentation indentation8 = new Indentation() { Left = "1440", Hanging = "1440" };

            previousParagraphProperties8.Append(indentation8);

            level8.Append(startNumberingValue8);
            level8.Append(numberingFormat8);
            level8.Append(levelSuffix8);
            level8.Append(levelText8);
            level8.Append(levelJustification8);
            level8.Append(previousParagraphProperties8);

            Level level9 = new Level() { LevelIndex = 8 };
            StartNumberingValue startNumberingValue9 = new StartNumberingValue() { Val = 1 };
            NumberingFormat numberingFormat9 = new NumberingFormat() { Val = NumberFormatValues.None };
            LevelSuffix levelSuffix9 = new LevelSuffix() { Val = LevelSuffixValues.Nothing };
            LevelText levelText9 = new LevelText() { Val = "" };
            LevelJustification levelJustification9 = new LevelJustification() { Val = LevelJustificationValues.Left };

            PreviousParagraphProperties previousParagraphProperties9 = new PreviousParagraphProperties();
            Indentation indentation9 = new Indentation() { Left = "1584", Hanging = "1584" };

            previousParagraphProperties9.Append(indentation9);

            level9.Append(startNumberingValue9);
            level9.Append(numberingFormat9);
            level9.Append(levelSuffix9);
            level9.Append(levelText9);
            level9.Append(levelJustification9);
            level9.Append(previousParagraphProperties9);

            abstractNum1.Append(nsid1);
            abstractNum1.Append(multiLevelType1);
            abstractNum1.Append(templateCode1);
            abstractNum1.Append(level1);
            abstractNum1.Append(level2);
            abstractNum1.Append(level3);
            abstractNum1.Append(level4);
            abstractNum1.Append(level5);
            abstractNum1.Append(level6);
            abstractNum1.Append(level7);
            abstractNum1.Append(level8);
            abstractNum1.Append(level9);

            NumberingInstance numberingInstance1 = new NumberingInstance() { NumberID = 1 };
            AbstractNumId abstractNumId1 = new AbstractNumId() { Val = 0 };

            numberingInstance1.Append(abstractNumId1);

            numbering1.Append(abstractNum1);
            numbering1.Append(numberingInstance1);

            numberingDefinitionsPart1.Numbering = numbering1;
        }

        // Generates content of customXmlPart1.
        private void GenerateCustomXmlPart1Content(CustomXmlPart customXmlPart1)
        {
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(customXmlPart1.GetStream(System.IO.FileMode.Create), System.Text.Encoding.UTF8);
            writer.WriteRaw("<b:Sources SelectedStyle=\"\\APA.XSL\" StyleName=\"APA\" xmlns:b=\"http://schemas.openxmlformats.org/officeDocument/2006/bibliography\" xmlns=\"http://schemas.openxmlformats.org/officeDocument/2006/bibliography\"></b:Sources>\r\n");
            writer.Flush();
            writer.Close();
        }

        // Generates content of customXmlPropertiesPart1.
        private void GenerateCustomXmlPropertiesPart1Content(CustomXmlPropertiesPart customXmlPropertiesPart1)
        {
            Ds.DataStoreItem dataStoreItem1 = new Ds.DataStoreItem() { ItemId = "{3F693424-6F8C-4678-AE1B-3B1387FF0E0D}" };
            dataStoreItem1.AddNamespaceDeclaration("ds", "http://schemas.openxmlformats.org/officeDocument/2006/customXml");

            Ds.SchemaReferences schemaReferences1 = new Ds.SchemaReferences();
            Ds.SchemaReference schemaReference1 = new Ds.SchemaReference() { Uri = "http://schemas.openxmlformats.org/officeDocument/2006/bibliography" };

            schemaReferences1.Append(schemaReference1);

            dataStoreItem1.Append(schemaReferences1);

            customXmlPropertiesPart1.DataStoreItem = dataStoreItem1;
        }

        // Generates content of webSettingsPart1.
        private void GenerateWebSettingsPart1Content(WebSettingsPart webSettingsPart1)
        {
            WebSettings webSettings1 = new WebSettings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            webSettings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            webSettings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            webSettings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            webSettings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            OptimizeForBrowser optimizeForBrowser1 = new OptimizeForBrowser();
            AllowPNG allowPNG1 = new AllowPNG();

            webSettings1.Append(optimizeForBrowser1);
            webSettings1.Append(allowPNG1);

            webSettingsPart1.WebSettings = webSettings1;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Тема Office" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Стандартная" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "1F497D" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "EEECE1" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "4F81BD" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "C0504D" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "9BBB59" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "8064A2" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4BACC6" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "F79646" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0000FF" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "800080" };

            followedHyperlinkColor1.Append(rgbColorModelHex10);

            colorScheme1.Append(dark1Color1);
            colorScheme1.Append(light1Color1);
            colorScheme1.Append(dark2Color1);
            colorScheme1.Append(light2Color1);
            colorScheme1.Append(accent1Color1);
            colorScheme1.Append(accent2Color1);
            colorScheme1.Append(accent3Color1);
            colorScheme1.Append(accent4Color1);
            colorScheme1.Append(accent5Color1);
            colorScheme1.Append(accent6Color1);
            colorScheme1.Append(hyperlink1);
            colorScheme1.Append(followedHyperlinkColor1);

            A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Стандартная" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "Cambria" };
            A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ ゴシック" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
            A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
            A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            majorFont1.Append(latinFont1);
            majorFont1.Append(eastAsianFont1);
            majorFont1.Append(complexScriptFont1);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);
            majorFont1.Append(supplementalFont4);
            majorFont1.Append(supplementalFont5);
            majorFont1.Append(supplementalFont6);
            majorFont1.Append(supplementalFont7);
            majorFont1.Append(supplementalFont8);
            majorFont1.Append(supplementalFont9);
            majorFont1.Append(supplementalFont10);
            majorFont1.Append(supplementalFont11);
            majorFont1.Append(supplementalFont12);
            majorFont1.Append(supplementalFont13);
            majorFont1.Append(supplementalFont14);
            majorFont1.Append(supplementalFont15);
            majorFont1.Append(supplementalFont16);
            majorFont1.Append(supplementalFont17);
            majorFont1.Append(supplementalFont18);
            majorFont1.Append(supplementalFont19);
            majorFont1.Append(supplementalFont20);
            majorFont1.Append(supplementalFont21);
            majorFont1.Append(supplementalFont22);
            majorFont1.Append(supplementalFont23);
            majorFont1.Append(supplementalFont24);
            majorFont1.Append(supplementalFont25);
            majorFont1.Append(supplementalFont26);
            majorFont1.Append(supplementalFont27);
            majorFont1.Append(supplementalFont28);
            majorFont1.Append(supplementalFont29);
            majorFont1.Append(supplementalFont30);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "Calibri" };
            A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ 明朝" };
            A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
            A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
            A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
            A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
            A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
            A.SupplementalFont supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            minorFont1.Append(latinFont2);
            minorFont1.Append(eastAsianFont2);
            minorFont1.Append(complexScriptFont2);
            minorFont1.Append(supplementalFont31);
            minorFont1.Append(supplementalFont32);
            minorFont1.Append(supplementalFont33);
            minorFont1.Append(supplementalFont34);
            minorFont1.Append(supplementalFont35);
            minorFont1.Append(supplementalFont36);
            minorFont1.Append(supplementalFont37);
            minorFont1.Append(supplementalFont38);
            minorFont1.Append(supplementalFont39);
            minorFont1.Append(supplementalFont40);
            minorFont1.Append(supplementalFont41);
            minorFont1.Append(supplementalFont42);
            minorFont1.Append(supplementalFont43);
            minorFont1.Append(supplementalFont44);
            minorFont1.Append(supplementalFont45);
            minorFont1.Append(supplementalFont46);
            minorFont1.Append(supplementalFont47);
            minorFont1.Append(supplementalFont48);
            minorFont1.Append(supplementalFont49);
            minorFont1.Append(supplementalFont50);
            minorFont1.Append(supplementalFont51);
            minorFont1.Append(supplementalFont52);
            minorFont1.Append(supplementalFont53);
            minorFont1.Append(supplementalFont54);
            minorFont1.Append(supplementalFont55);
            minorFont1.Append(supplementalFont56);
            minorFont1.Append(supplementalFont57);
            minorFont1.Append(supplementalFont58);
            minorFont1.Append(supplementalFont59);
            minorFont1.Append(supplementalFont60);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Стандартная" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill1.Append(schemeColor1);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint1 = new A.Tint() { Val = 50000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 300000 };

            schemeColor2.Append(tint1);
            schemeColor2.Append(saturationModulation1);

            gradientStop1.Append(schemeColor2);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 35000 };

            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint2 = new A.Tint() { Val = 37000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 300000 };

            schemeColor3.Append(tint2);
            schemeColor3.Append(saturationModulation2);

            gradientStop2.Append(schemeColor3);

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint3 = new A.Tint() { Val = 15000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 350000 };

            schemeColor4.Append(tint3);
            schemeColor4.Append(saturationModulation3);

            gradientStop3.Append(schemeColor4);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            gradientStopList1.Append(gradientStop3);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 16200000, Scaled = true };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade1 = new A.Shade() { Val = 51000 };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 130000 };

            schemeColor5.Append(shade1);
            schemeColor5.Append(saturationModulation4);

            gradientStop4.Append(schemeColor5);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 80000 };

            A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade2 = new A.Shade() { Val = 93000 };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 130000 };

            schemeColor6.Append(shade2);
            schemeColor6.Append(saturationModulation5);

            gradientStop5.Append(schemeColor6);

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade3 = new A.Shade() { Val = 94000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 135000 };

            schemeColor7.Append(shade3);
            schemeColor7.Append(saturationModulation6);

            gradientStop6.Append(schemeColor7);

            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);
            gradientStopList2.Append(gradientStop6);
            A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 16200000, Scaled = false };

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(linearGradientFill2);

            fillStyleList1.Append(solidFill1);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline1 = new A.Outline() { Width = 9525, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill2 = new A.SolidFill();

            A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade4 = new A.Shade() { Val = 95000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 105000 };

            schemeColor8.Append(shade4);
            schemeColor8.Append(saturationModulation7);

            solidFill2.Append(schemeColor8);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline1.Append(solidFill2);
            outline1.Append(presetDash1);

            A.Outline outline2 = new A.Outline() { Width = 25400, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill3.Append(schemeColor9);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline2.Append(solidFill3);
            outline2.Append(presetDash2);

            A.Outline outline3 = new A.Outline() { Width = 38100, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill4 = new A.SolidFill();
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill4.Append(schemeColor10);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline3.Append(solidFill4);
            outline3.Append(presetDash3);

            lineStyleList1.Append(outline1);
            lineStyleList1.Append(outline2);
            lineStyleList1.Append(outline3);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();

            A.EffectList effectList1 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 38000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList1.Append(outerShadow1);

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();

            A.EffectList effectList2 = new A.EffectList();

            A.OuterShadow outerShadow2 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex12 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha2 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex12.Append(alpha2);

            outerShadow2.Append(rgbColorModelHex12);

            effectList2.Append(outerShadow2);

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.OuterShadow outerShadow3 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex13 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha3 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex13.Append(alpha3);

            outerShadow3.Append(rgbColorModelHex13);

            effectList3.Append(outerShadow3);

            A.Scene3DType scene3DType1 = new A.Scene3DType();

            A.Camera camera1 = new A.Camera() { Preset = A.PresetCameraValues.OrthographicFront };
            A.Rotation rotation1 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 0 };

            camera1.Append(rotation1);

            A.LightRig lightRig1 = new A.LightRig() { Rig = A.LightRigValues.ThreePoints, Direction = A.LightRigDirectionValues.Top };
            A.Rotation rotation2 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 1200000 };

            lightRig1.Append(rotation2);

            scene3DType1.Append(camera1);
            scene3DType1.Append(lightRig1);

            A.Shape3DType shape3DType1 = new A.Shape3DType();
            A.BevelTop bevelTop1 = new A.BevelTop() { Width = 63500L, Height = 25400L };

            shape3DType1.Append(bevelTop1);

            effectStyle3.Append(effectList3);
            effectStyle3.Append(scene3DType1);
            effectStyle3.Append(shape3DType1);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill5 = new A.SolidFill();
            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill5.Append(schemeColor11);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint4 = new A.Tint() { Val = 40000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 350000 };

            schemeColor12.Append(tint4);
            schemeColor12.Append(saturationModulation8);

            gradientStop7.Append(schemeColor12);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 40000 };

            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint5 = new A.Tint() { Val = 45000 };
            A.Shade shade5 = new A.Shade() { Val = 99000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 350000 };

            schemeColor13.Append(tint5);
            schemeColor13.Append(shade5);
            schemeColor13.Append(saturationModulation9);

            gradientStop8.Append(schemeColor13);

            A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade6 = new A.Shade() { Val = 20000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 255000 };

            schemeColor14.Append(shade6);
            schemeColor14.Append(saturationModulation10);

            gradientStop9.Append(schemeColor14);

            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);
            gradientStopList3.Append(gradientStop9);

            A.PathGradientFill pathGradientFill1 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle1 = new A.FillToRectangle() { Left = 50000, Top = -80000, Right = 50000, Bottom = 180000 };

            pathGradientFill1.Append(fillToRectangle1);

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(pathGradientFill1);

            A.GradientFill gradientFill4 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList4 = new A.GradientStopList();

            A.GradientStop gradientStop10 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint6 = new A.Tint() { Val = 80000 };
            A.SaturationModulation saturationModulation11 = new A.SaturationModulation() { Val = 300000 };

            schemeColor15.Append(tint6);
            schemeColor15.Append(saturationModulation11);

            gradientStop10.Append(schemeColor15);

            A.GradientStop gradientStop11 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade7 = new A.Shade() { Val = 30000 };
            A.SaturationModulation saturationModulation12 = new A.SaturationModulation() { Val = 200000 };

            schemeColor16.Append(shade7);
            schemeColor16.Append(saturationModulation12);

            gradientStop11.Append(schemeColor16);

            gradientStopList4.Append(gradientStop10);
            gradientStopList4.Append(gradientStop11);

            A.PathGradientFill pathGradientFill2 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle2 = new A.FillToRectangle() { Left = 50000, Top = 50000, Right = 50000, Bottom = 50000 };

            pathGradientFill2.Append(fillToRectangle2);

            gradientFill4.Append(gradientStopList4);
            gradientFill4.Append(pathGradientFill2);

            backgroundFillStyleList1.Append(solidFill5);
            backgroundFillStyleList1.Append(gradientFill3);
            backgroundFillStyleList1.Append(gradientFill4);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme1);
            themeElements1.Append(formatScheme1);
            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);

            themePart1.Theme = theme1;
        }

        // Generates content of documentSettingsPart1.
        private void GenerateDocumentSettingsPart1Content(DocumentSettingsPart documentSettingsPart1)
        {
            Settings settings1 = new Settings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            settings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            settings1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            settings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            settings1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            settings1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            settings1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            settings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            settings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            settings1.AddNamespaceDeclaration("sl", "http://schemas.openxmlformats.org/schemaLibrary/2006/main");
            Zoom zoom1 = new Zoom() { Percent = "110" };
            ProofState proofState1 = new ProofState() { Spelling = ProofingStateValues.Clean, Grammar = ProofingStateValues.Clean };
            AttachedTemplate attachedTemplate1 = new AttachedTemplate() { Id = "rId1" };
            DefaultTabStop defaultTabStop1 = new DefaultTabStop() { Val = 708 };
            CharacterSpacingControl characterSpacingControl1 = new CharacterSpacingControl() { Val = CharacterSpacingValues.DoNotCompress };

            FootnoteDocumentWideProperties footnoteDocumentWideProperties1 = new FootnoteDocumentWideProperties();
            FootnoteSpecialReference footnoteSpecialReference1 = new FootnoteSpecialReference() { Id = -1 };
            FootnoteSpecialReference footnoteSpecialReference2 = new FootnoteSpecialReference() { Id = 0 };

            footnoteDocumentWideProperties1.Append(footnoteSpecialReference1);
            footnoteDocumentWideProperties1.Append(footnoteSpecialReference2);

            EndnoteDocumentWideProperties endnoteDocumentWideProperties1 = new EndnoteDocumentWideProperties();
            EndnoteSpecialReference endnoteSpecialReference1 = new EndnoteSpecialReference() { Id = -1 };
            EndnoteSpecialReference endnoteSpecialReference2 = new EndnoteSpecialReference() { Id = 0 };

            endnoteDocumentWideProperties1.Append(endnoteSpecialReference1);
            endnoteDocumentWideProperties1.Append(endnoteSpecialReference2);

            Compatibility compatibility1 = new Compatibility();
            CompatibilitySetting compatibilitySetting1 = new CompatibilitySetting() { Name = CompatSettingNameValues.CompatibilityMode, Uri = "http://schemas.microsoft.com/office/word", Val = "14" };
            CompatibilitySetting compatibilitySetting2 = new CompatibilitySetting() { Name = CompatSettingNameValues.OverrideTableStyleFontSizeAndJustification, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting3 = new CompatibilitySetting() { Name = CompatSettingNameValues.EnableOpenTypeFeatures, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting4 = new CompatibilitySetting() { Name = CompatSettingNameValues.DoNotFlipMirrorIndents, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };

            compatibility1.Append(compatibilitySetting1);
            compatibility1.Append(compatibilitySetting2);
            compatibility1.Append(compatibilitySetting3);
            compatibility1.Append(compatibilitySetting4);

            Rsids rsids1 = new Rsids();
            RsidRoot rsidRoot1 = new RsidRoot() { Val = "00072E72" };
            Rsid rsid26 = new Rsid() { Val = "0002594A" };
            Rsid rsid27 = new Rsid() { Val = "00056893" };
            Rsid rsid28 = new Rsid() { Val = "00072E72" };
            Rsid rsid29 = new Rsid() { Val = "002961E3" };
            Rsid rsid30 = new Rsid() { Val = "002A11B0" };
            Rsid rsid31 = new Rsid() { Val = "002C1D12" };
            Rsid rsid32 = new Rsid() { Val = "002D7FEF" };
            Rsid rsid33 = new Rsid() { Val = "00312650" };
            Rsid rsid34 = new Rsid() { Val = "00400957" };
            Rsid rsid35 = new Rsid() { Val = "004C21EC" };
            Rsid rsid36 = new Rsid() { Val = "00667990" };
            Rsid rsid37 = new Rsid() { Val = "006B7D79" };
            Rsid rsid38 = new Rsid() { Val = "008042CE" };
            Rsid rsid39 = new Rsid() { Val = "00820AEF" };
            Rsid rsid40 = new Rsid() { Val = "008553AD" };
            Rsid rsid41 = new Rsid() { Val = "00946533" };
            Rsid rsid42 = new Rsid() { Val = "0095027B" };
            Rsid rsid43 = new Rsid() { Val = "00A52419" };
            Rsid rsid44 = new Rsid() { Val = "00A6561E" };
            Rsid rsid45 = new Rsid() { Val = "00BD3EB9" };
            Rsid rsid46 = new Rsid() { Val = "00C00F62" };
            Rsid rsid47 = new Rsid() { Val = "00DA1452" };
            Rsid rsid48 = new Rsid() { Val = "00DB5B7C" };
            Rsid rsid49 = new Rsid() { Val = "00E174D4" };
            Rsid rsid50 = new Rsid() { Val = "00E6681D" };
            Rsid rsid51 = new Rsid() { Val = "00E827F1" };
            Rsid rsid52 = new Rsid() { Val = "00ED372D" };
            Rsid rsid53 = new Rsid() { Val = "00FD0905" };

            rsids1.Append(rsidRoot1);
            rsids1.Append(rsid26);
            rsids1.Append(rsid27);
            rsids1.Append(rsid28);
            rsids1.Append(rsid29);
            rsids1.Append(rsid30);
            rsids1.Append(rsid31);
            rsids1.Append(rsid32);
            rsids1.Append(rsid33);
            rsids1.Append(rsid34);
            rsids1.Append(rsid35);
            rsids1.Append(rsid36);
            rsids1.Append(rsid37);
            rsids1.Append(rsid38);
            rsids1.Append(rsid39);
            rsids1.Append(rsid40);
            rsids1.Append(rsid41);
            rsids1.Append(rsid42);
            rsids1.Append(rsid43);
            rsids1.Append(rsid44);
            rsids1.Append(rsid45);
            rsids1.Append(rsid46);
            rsids1.Append(rsid47);
            rsids1.Append(rsid48);
            rsids1.Append(rsid49);
            rsids1.Append(rsid50);
            rsids1.Append(rsid51);
            rsids1.Append(rsid52);
            rsids1.Append(rsid53);

            M.MathProperties mathProperties1 = new M.MathProperties();
            M.MathFont mathFont1 = new M.MathFont() { Val = "Cambria Math" };
            M.BreakBinary breakBinary1 = new M.BreakBinary() { Val = M.BreakBinaryOperatorValues.Before };
            M.BreakBinarySubtraction breakBinarySubtraction1 = new M.BreakBinarySubtraction() { Val = M.BreakBinarySubtractionValues.MinusMinus };
            M.SmallFraction smallFraction1 = new M.SmallFraction() { Val = M.BooleanValues.Zero };
            M.DisplayDefaults displayDefaults1 = new M.DisplayDefaults();
            M.LeftMargin leftMargin1 = new M.LeftMargin() { Val = (UInt32Value)0U };
            M.RightMargin rightMargin1 = new M.RightMargin() { Val = (UInt32Value)0U };
            M.DefaultJustification defaultJustification1 = new M.DefaultJustification() { Val = M.JustificationValues.CenterGroup };
            M.WrapIndent wrapIndent1 = new M.WrapIndent() { Val = (UInt32Value)1440U };
            M.IntegralLimitLocation integralLimitLocation1 = new M.IntegralLimitLocation() { Val = M.LimitLocationValues.SubscriptSuperscript };
            M.NaryLimitLocation naryLimitLocation1 = new M.NaryLimitLocation() { Val = M.LimitLocationValues.UnderOver };

            mathProperties1.Append(mathFont1);
            mathProperties1.Append(breakBinary1);
            mathProperties1.Append(breakBinarySubtraction1);
            mathProperties1.Append(smallFraction1);
            mathProperties1.Append(displayDefaults1);
            mathProperties1.Append(leftMargin1);
            mathProperties1.Append(rightMargin1);
            mathProperties1.Append(defaultJustification1);
            mathProperties1.Append(wrapIndent1);
            mathProperties1.Append(integralLimitLocation1);
            mathProperties1.Append(naryLimitLocation1);
            ThemeFontLanguages themeFontLanguages1 = new ThemeFontLanguages() { Val = "ru-RU" };
            ColorSchemeMapping colorSchemeMapping1 = new ColorSchemeMapping() { Background1 = ColorSchemeIndexValues.Light1, Text1 = ColorSchemeIndexValues.Dark1, Background2 = ColorSchemeIndexValues.Light2, Text2 = ColorSchemeIndexValues.Dark2, Accent1 = ColorSchemeIndexValues.Accent1, Accent2 = ColorSchemeIndexValues.Accent2, Accent3 = ColorSchemeIndexValues.Accent3, Accent4 = ColorSchemeIndexValues.Accent4, Accent5 = ColorSchemeIndexValues.Accent5, Accent6 = ColorSchemeIndexValues.Accent6, Hyperlink = ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink };

            ShapeDefaults shapeDefaults1 = new ShapeDefaults();
            Ovml.ShapeDefaults shapeDefaults2 = new Ovml.ShapeDefaults() { Extension = V.ExtensionHandlingBehaviorValues.Edit, MaxShapeId = 1026 };

            Ovml.ShapeLayout shapeLayout1 = new Ovml.ShapeLayout() { Extension = V.ExtensionHandlingBehaviorValues.Edit };
            Ovml.ShapeIdMap shapeIdMap1 = new Ovml.ShapeIdMap() { Extension = V.ExtensionHandlingBehaviorValues.Edit, Data = "1" };

            shapeLayout1.Append(shapeIdMap1);

            shapeDefaults1.Append(shapeDefaults2);
            shapeDefaults1.Append(shapeLayout1);
            DecimalSymbol decimalSymbol1 = new DecimalSymbol() { Val = "," };
            ListSeparator listSeparator1 = new ListSeparator() { Val = ";" };

            settings1.Append(zoom1);
            settings1.Append(proofState1);
            settings1.Append(attachedTemplate1);
            settings1.Append(defaultTabStop1);
            settings1.Append(characterSpacingControl1);
            settings1.Append(footnoteDocumentWideProperties1);
            settings1.Append(endnoteDocumentWideProperties1);
            settings1.Append(compatibility1);
            settings1.Append(rsids1);
            settings1.Append(mathProperties1);
            settings1.Append(themeFontLanguages1);
            settings1.Append(colorSchemeMapping1);
            settings1.Append(shapeDefaults1);
            settings1.Append(decimalSymbol1);
            settings1.Append(listSeparator1);

            documentSettingsPart1.Settings = settings1;
        }

        // Generates content of fontTablePart1.
        private void GenerateFontTablePart1Content(FontTablePart fontTablePart1)
        {
            Fonts fonts1 = new Fonts() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            fonts1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            fonts1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            fonts1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            fonts1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

            Font font1 = new Font() { Name = "Calibri" };
            Panose1Number panose1Number1 = new Panose1Number() { Val = "020F0502020204030204" };
            FontCharSet fontCharSet1 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily1 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch1 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature1 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "4000ACFF", UnicodeSignature2 = "00000001", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font1.Append(panose1Number1);
            font1.Append(fontCharSet1);
            font1.Append(fontFamily1);
            font1.Append(pitch1);
            font1.Append(fontSignature1);

            Font font2 = new Font() { Name = "Times New Roman" };
            Panose1Number panose1Number2 = new Panose1Number() { Val = "02020603050405020304" };
            FontCharSet fontCharSet2 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily2 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch2 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature2 = new FontSignature() { UnicodeSignature0 = "E0002AFF", UnicodeSignature1 = "C0007841", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

            font2.Append(panose1Number2);
            font2.Append(fontCharSet2);
            font2.Append(fontFamily2);
            font2.Append(pitch2);
            font2.Append(fontSignature2);

            Font font3 = new Font() { Name = "Cambria" };
            Panose1Number panose1Number3 = new Panose1Number() { Val = "02040503050406030204" };
            FontCharSet fontCharSet3 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily3 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch3 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature3 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "400004FF", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font3.Append(panose1Number3);
            font3.Append(fontCharSet3);
            font3.Append(fontFamily3);
            font3.Append(pitch3);
            font3.Append(fontSignature3);

            Font font4 = new Font() { Name = "SimSun" };
            AltName altName1 = new AltName() { Val = "宋体" };
            Panose1Number panose1Number4 = new Panose1Number() { Val = "02010600030101010101" };
            FontCharSet fontCharSet4 = new FontCharSet() { Val = "86" };
            FontFamily fontFamily4 = new FontFamily() { Val = FontFamilyValues.Auto };
            NotTrueType notTrueType1 = new NotTrueType();
            Pitch pitch4 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature4 = new FontSignature() { UnicodeSignature0 = "00000001", UnicodeSignature1 = "080E0000", UnicodeSignature2 = "00000010", UnicodeSignature3 = "00000000", CodePageSignature0 = "00040000", CodePageSignature1 = "00000000" };

            font4.Append(altName1);
            font4.Append(panose1Number4);
            font4.Append(fontCharSet4);
            font4.Append(fontFamily4);
            font4.Append(notTrueType1);
            font4.Append(pitch4);
            font4.Append(fontSignature4);

            Font font5 = new Font() { Name = "Arial" };
            Panose1Number panose1Number5 = new Panose1Number() { Val = "020B0604020202020204" };
            FontCharSet fontCharSet5 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily5 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch5 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature5 = new FontSignature() { UnicodeSignature0 = "E0002AFF", UnicodeSignature1 = "C0007843", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

            font5.Append(panose1Number5);
            font5.Append(fontCharSet5);
            font5.Append(fontFamily5);
            font5.Append(pitch5);
            font5.Append(fontSignature5);

            Font font6 = new Font() { Name = "Mangal" };
            Panose1Number panose1Number6 = new Panose1Number() { Val = "02040503050203030202" };
            FontCharSet fontCharSet6 = new FontCharSet() { Val = "00" };
            FontFamily fontFamily6 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch6 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature6 = new FontSignature() { UnicodeSignature0 = "00008003", UnicodeSignature1 = "00000000", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "00000001", CodePageSignature1 = "00000000" };

            font6.Append(panose1Number6);
            font6.Append(fontCharSet6);
            font6.Append(fontFamily6);
            font6.Append(pitch6);
            font6.Append(fontSignature6);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);
            fonts1.Append(font4);
            fonts1.Append(font5);
            fonts1.Append(font6);

            fontTablePart1.Fonts = fonts1;
        }

        // Generates content of stylesWithEffectsPart1.
        private void GenerateStylesWithEffectsPart1Content(StylesWithEffectsPart stylesWithEffectsPart1)
        {
            Styles styles2 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            styles2.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            styles2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles2.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            styles2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles2.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            styles2.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            styles2.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            styles2.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            styles2.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            styles2.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles2.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            styles2.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            styles2.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            styles2.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            styles2.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            DocDefaults docDefaults2 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault2 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle2 = new RunPropertiesBaseStyle();
            RunFonts runFonts22 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
            FontSize fontSize12 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "22" };
            Languages languages2 = new Languages() { Val = "ru-RU", EastAsia = "en-US", Bidi = "ar-SA" };

            runPropertiesBaseStyle2.Append(runFonts22);
            runPropertiesBaseStyle2.Append(fontSize12);
            runPropertiesBaseStyle2.Append(fontSizeComplexScript12);
            runPropertiesBaseStyle2.Append(languages2);

            runPropertiesDefault2.Append(runPropertiesBaseStyle2);

            ParagraphPropertiesDefault paragraphPropertiesDefault2 = new ParagraphPropertiesDefault();

            ParagraphPropertiesBaseStyle paragraphPropertiesBaseStyle2 = new ParagraphPropertiesBaseStyle();
            SpacingBetweenLines spacingBetweenLines18 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };

            paragraphPropertiesBaseStyle2.Append(spacingBetweenLines18);

            paragraphPropertiesDefault2.Append(paragraphPropertiesBaseStyle2);

            docDefaults2.Append(runPropertiesDefault2);
            docDefaults2.Append(paragraphPropertiesDefault2);

            LatentStyles latentStyles2 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = true, DefaultUnhideWhenUsed = true, DefaultPrimaryStyle = false, Count = 267 };
            LatentStyleExceptionInfo latentStyleExceptionInfo139 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo140 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo141 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 0, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo142 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 0, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo143 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo144 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo145 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo146 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo147 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo148 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo149 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo150 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo151 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo152 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo153 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo154 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo155 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo156 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo157 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo158 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo159 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo160 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1 };
            LatentStyleExceptionInfo latentStyleExceptionInfo161 = new LatentStyleExceptionInfo() { Name = "Body Text", UiPriority = 0 };
            LatentStyleExceptionInfo latentStyleExceptionInfo162 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo163 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo164 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo165 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo166 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo167 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo168 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo169 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo170 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo171 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo172 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo173 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo174 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo175 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo176 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo177 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo178 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo179 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo180 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo181 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo182 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo183 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo184 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo185 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo186 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo187 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo188 = new LatentStyleExceptionInfo() { Name = "Revision", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo189 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo190 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo191 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo192 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo193 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo194 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo195 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo196 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo197 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo198 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo199 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo200 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo201 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo202 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo203 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo204 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo205 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo206 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo207 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo208 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo209 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo210 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo211 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo212 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo213 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo214 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo215 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo216 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo217 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo218 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo219 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo220 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo221 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo222 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo223 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo224 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo225 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo226 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo227 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo228 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo229 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo230 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo231 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo232 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo233 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo234 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo235 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo236 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo237 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo238 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo239 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo240 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo241 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo242 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo243 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo244 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo245 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo246 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo247 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo248 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo249 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo250 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo251 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo252 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo253 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo254 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo255 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo256 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo257 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo258 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo259 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo260 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo261 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo262 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo263 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo264 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo265 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo266 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo267 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo268 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo269 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo270 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo271 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo272 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo273 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo274 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo275 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37 };
            LatentStyleExceptionInfo latentStyleExceptionInfo276 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, PrimaryStyle = true };

            latentStyles2.Append(latentStyleExceptionInfo139);
            latentStyles2.Append(latentStyleExceptionInfo140);
            latentStyles2.Append(latentStyleExceptionInfo141);
            latentStyles2.Append(latentStyleExceptionInfo142);
            latentStyles2.Append(latentStyleExceptionInfo143);
            latentStyles2.Append(latentStyleExceptionInfo144);
            latentStyles2.Append(latentStyleExceptionInfo145);
            latentStyles2.Append(latentStyleExceptionInfo146);
            latentStyles2.Append(latentStyleExceptionInfo147);
            latentStyles2.Append(latentStyleExceptionInfo148);
            latentStyles2.Append(latentStyleExceptionInfo149);
            latentStyles2.Append(latentStyleExceptionInfo150);
            latentStyles2.Append(latentStyleExceptionInfo151);
            latentStyles2.Append(latentStyleExceptionInfo152);
            latentStyles2.Append(latentStyleExceptionInfo153);
            latentStyles2.Append(latentStyleExceptionInfo154);
            latentStyles2.Append(latentStyleExceptionInfo155);
            latentStyles2.Append(latentStyleExceptionInfo156);
            latentStyles2.Append(latentStyleExceptionInfo157);
            latentStyles2.Append(latentStyleExceptionInfo158);
            latentStyles2.Append(latentStyleExceptionInfo159);
            latentStyles2.Append(latentStyleExceptionInfo160);
            latentStyles2.Append(latentStyleExceptionInfo161);
            latentStyles2.Append(latentStyleExceptionInfo162);
            latentStyles2.Append(latentStyleExceptionInfo163);
            latentStyles2.Append(latentStyleExceptionInfo164);
            latentStyles2.Append(latentStyleExceptionInfo165);
            latentStyles2.Append(latentStyleExceptionInfo166);
            latentStyles2.Append(latentStyleExceptionInfo167);
            latentStyles2.Append(latentStyleExceptionInfo168);
            latentStyles2.Append(latentStyleExceptionInfo169);
            latentStyles2.Append(latentStyleExceptionInfo170);
            latentStyles2.Append(latentStyleExceptionInfo171);
            latentStyles2.Append(latentStyleExceptionInfo172);
            latentStyles2.Append(latentStyleExceptionInfo173);
            latentStyles2.Append(latentStyleExceptionInfo174);
            latentStyles2.Append(latentStyleExceptionInfo175);
            latentStyles2.Append(latentStyleExceptionInfo176);
            latentStyles2.Append(latentStyleExceptionInfo177);
            latentStyles2.Append(latentStyleExceptionInfo178);
            latentStyles2.Append(latentStyleExceptionInfo179);
            latentStyles2.Append(latentStyleExceptionInfo180);
            latentStyles2.Append(latentStyleExceptionInfo181);
            latentStyles2.Append(latentStyleExceptionInfo182);
            latentStyles2.Append(latentStyleExceptionInfo183);
            latentStyles2.Append(latentStyleExceptionInfo184);
            latentStyles2.Append(latentStyleExceptionInfo185);
            latentStyles2.Append(latentStyleExceptionInfo186);
            latentStyles2.Append(latentStyleExceptionInfo187);
            latentStyles2.Append(latentStyleExceptionInfo188);
            latentStyles2.Append(latentStyleExceptionInfo189);
            latentStyles2.Append(latentStyleExceptionInfo190);
            latentStyles2.Append(latentStyleExceptionInfo191);
            latentStyles2.Append(latentStyleExceptionInfo192);
            latentStyles2.Append(latentStyleExceptionInfo193);
            latentStyles2.Append(latentStyleExceptionInfo194);
            latentStyles2.Append(latentStyleExceptionInfo195);
            latentStyles2.Append(latentStyleExceptionInfo196);
            latentStyles2.Append(latentStyleExceptionInfo197);
            latentStyles2.Append(latentStyleExceptionInfo198);
            latentStyles2.Append(latentStyleExceptionInfo199);
            latentStyles2.Append(latentStyleExceptionInfo200);
            latentStyles2.Append(latentStyleExceptionInfo201);
            latentStyles2.Append(latentStyleExceptionInfo202);
            latentStyles2.Append(latentStyleExceptionInfo203);
            latentStyles2.Append(latentStyleExceptionInfo204);
            latentStyles2.Append(latentStyleExceptionInfo205);
            latentStyles2.Append(latentStyleExceptionInfo206);
            latentStyles2.Append(latentStyleExceptionInfo207);
            latentStyles2.Append(latentStyleExceptionInfo208);
            latentStyles2.Append(latentStyleExceptionInfo209);
            latentStyles2.Append(latentStyleExceptionInfo210);
            latentStyles2.Append(latentStyleExceptionInfo211);
            latentStyles2.Append(latentStyleExceptionInfo212);
            latentStyles2.Append(latentStyleExceptionInfo213);
            latentStyles2.Append(latentStyleExceptionInfo214);
            latentStyles2.Append(latentStyleExceptionInfo215);
            latentStyles2.Append(latentStyleExceptionInfo216);
            latentStyles2.Append(latentStyleExceptionInfo217);
            latentStyles2.Append(latentStyleExceptionInfo218);
            latentStyles2.Append(latentStyleExceptionInfo219);
            latentStyles2.Append(latentStyleExceptionInfo220);
            latentStyles2.Append(latentStyleExceptionInfo221);
            latentStyles2.Append(latentStyleExceptionInfo222);
            latentStyles2.Append(latentStyleExceptionInfo223);
            latentStyles2.Append(latentStyleExceptionInfo224);
            latentStyles2.Append(latentStyleExceptionInfo225);
            latentStyles2.Append(latentStyleExceptionInfo226);
            latentStyles2.Append(latentStyleExceptionInfo227);
            latentStyles2.Append(latentStyleExceptionInfo228);
            latentStyles2.Append(latentStyleExceptionInfo229);
            latentStyles2.Append(latentStyleExceptionInfo230);
            latentStyles2.Append(latentStyleExceptionInfo231);
            latentStyles2.Append(latentStyleExceptionInfo232);
            latentStyles2.Append(latentStyleExceptionInfo233);
            latentStyles2.Append(latentStyleExceptionInfo234);
            latentStyles2.Append(latentStyleExceptionInfo235);
            latentStyles2.Append(latentStyleExceptionInfo236);
            latentStyles2.Append(latentStyleExceptionInfo237);
            latentStyles2.Append(latentStyleExceptionInfo238);
            latentStyles2.Append(latentStyleExceptionInfo239);
            latentStyles2.Append(latentStyleExceptionInfo240);
            latentStyles2.Append(latentStyleExceptionInfo241);
            latentStyles2.Append(latentStyleExceptionInfo242);
            latentStyles2.Append(latentStyleExceptionInfo243);
            latentStyles2.Append(latentStyleExceptionInfo244);
            latentStyles2.Append(latentStyleExceptionInfo245);
            latentStyles2.Append(latentStyleExceptionInfo246);
            latentStyles2.Append(latentStyleExceptionInfo247);
            latentStyles2.Append(latentStyleExceptionInfo248);
            latentStyles2.Append(latentStyleExceptionInfo249);
            latentStyles2.Append(latentStyleExceptionInfo250);
            latentStyles2.Append(latentStyleExceptionInfo251);
            latentStyles2.Append(latentStyleExceptionInfo252);
            latentStyles2.Append(latentStyleExceptionInfo253);
            latentStyles2.Append(latentStyleExceptionInfo254);
            latentStyles2.Append(latentStyleExceptionInfo255);
            latentStyles2.Append(latentStyleExceptionInfo256);
            latentStyles2.Append(latentStyleExceptionInfo257);
            latentStyles2.Append(latentStyleExceptionInfo258);
            latentStyles2.Append(latentStyleExceptionInfo259);
            latentStyles2.Append(latentStyleExceptionInfo260);
            latentStyles2.Append(latentStyleExceptionInfo261);
            latentStyles2.Append(latentStyleExceptionInfo262);
            latentStyles2.Append(latentStyleExceptionInfo263);
            latentStyles2.Append(latentStyleExceptionInfo264);
            latentStyles2.Append(latentStyleExceptionInfo265);
            latentStyles2.Append(latentStyleExceptionInfo266);
            latentStyles2.Append(latentStyleExceptionInfo267);
            latentStyles2.Append(latentStyleExceptionInfo268);
            latentStyles2.Append(latentStyleExceptionInfo269);
            latentStyles2.Append(latentStyleExceptionInfo270);
            latentStyles2.Append(latentStyleExceptionInfo271);
            latentStyles2.Append(latentStyleExceptionInfo272);
            latentStyles2.Append(latentStyleExceptionInfo273);
            latentStyles2.Append(latentStyleExceptionInfo274);
            latentStyles2.Append(latentStyleExceptionInfo275);
            latentStyles2.Append(latentStyleExceptionInfo276);

            Style style30 = new Style() { Type = StyleValues.Paragraph, StyleId = "a0", Default = true };
            StyleName styleName30 = new StyleName() { Val = "Normal" };
            PrimaryStyle primaryStyle10 = new PrimaryStyle();

            style30.Append(styleName30);
            style30.Append(primaryStyle10);

            Style style31 = new Style() { Type = StyleValues.Paragraph, StyleId = "1" };
            StyleName styleName31 = new StyleName() { Val = "heading 1" };
            BasedOn basedOn26 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle8 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle25 = new LinkedStyle() { Val = "10" };
            UIPriority uIPriority22 = new UIPriority() { Val = 9 };
            PrimaryStyle primaryStyle11 = new PrimaryStyle();
            Rsid rsid54 = new Rsid() { Val = "00056893" };

            StyleParagraphProperties styleParagraphProperties14 = new StyleParagraphProperties();
            KeepNext keepNext10 = new KeepNext();
            KeepLines keepLines8 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines19 = new SpacingBetweenLines() { Before = "480", After = "0" };
            OutlineLevel outlineLevel10 = new OutlineLevel() { Val = 0 };

            styleParagraphProperties14.Append(keepNext10);
            styleParagraphProperties14.Append(keepLines8);
            styleParagraphProperties14.Append(spacingBetweenLines19);
            styleParagraphProperties14.Append(outlineLevel10);

            StyleRunProperties styleRunProperties21 = new StyleRunProperties();
            RunFonts runFonts23 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold14 = new Bold();
            BoldComplexScript boldComplexScript14 = new BoldComplexScript();
            Color color21 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
            FontSize fontSize13 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties21.Append(runFonts23);
            styleRunProperties21.Append(bold14);
            styleRunProperties21.Append(boldComplexScript14);
            styleRunProperties21.Append(color21);
            styleRunProperties21.Append(fontSize13);
            styleRunProperties21.Append(fontSizeComplexScript13);

            style31.Append(styleName31);
            style31.Append(basedOn26);
            style31.Append(nextParagraphStyle8);
            style31.Append(linkedStyle25);
            style31.Append(uIPriority22);
            style31.Append(primaryStyle11);
            style31.Append(rsid54);
            style31.Append(styleParagraphProperties14);
            style31.Append(styleRunProperties21);

            Style style32 = new Style() { Type = StyleValues.Paragraph, StyleId = "2" };
            StyleName styleName32 = new StyleName() { Val = "heading 2" };
            BasedOn basedOn27 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle26 = new LinkedStyle() { Val = "20" };
            Rsid rsid55 = new Rsid() { Val = "00820AEF" };

            StyleParagraphProperties styleParagraphProperties15 = new StyleParagraphProperties();
            KeepNext keepNext11 = new KeepNext();

            Tabs tabs6 = new Tabs();
            TabStop tabStop8 = new TabStop() { Val = TabStopValues.Left, Position = 709 };

            tabs6.Append(tabStop8);
            SuppressAutoHyphens suppressAutoHyphens4 = new SuppressAutoHyphens();
            SpacingBetweenLines spacingBetweenLines20 = new SpacingBetweenLines() { Before = "200", After = "0", Line = "276", LineRule = LineSpacingRuleValues.AtLeast };
            OutlineLevel outlineLevel11 = new OutlineLevel() { Val = 1 };

            styleParagraphProperties15.Append(keepNext11);
            styleParagraphProperties15.Append(tabs6);
            styleParagraphProperties15.Append(suppressAutoHyphens4);
            styleParagraphProperties15.Append(spacingBetweenLines20);
            styleParagraphProperties15.Append(outlineLevel11);

            StyleRunProperties styleRunProperties22 = new StyleRunProperties();
            RunFonts runFonts24 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "SimSun" };
            Bold bold15 = new Bold();
            BoldComplexScript boldComplexScript15 = new BoldComplexScript();
            Color color22 = new Color() { Val = "4F81BD" };
            FontSize fontSize14 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript14 = new FontSizeComplexScript() { Val = "26" };

            styleRunProperties22.Append(runFonts24);
            styleRunProperties22.Append(bold15);
            styleRunProperties22.Append(boldComplexScript15);
            styleRunProperties22.Append(color22);
            styleRunProperties22.Append(fontSize14);
            styleRunProperties22.Append(fontSizeComplexScript14);

            style32.Append(styleName32);
            style32.Append(basedOn27);
            style32.Append(linkedStyle26);
            style32.Append(rsid55);
            style32.Append(styleParagraphProperties15);
            style32.Append(styleRunProperties22);

            Style style33 = new Style() { Type = StyleValues.Paragraph, StyleId = "3" };
            StyleName styleName33 = new StyleName() { Val = "heading 3" };
            BasedOn basedOn28 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle27 = new LinkedStyle() { Val = "30" };
            Rsid rsid56 = new Rsid() { Val = "00820AEF" };

            StyleParagraphProperties styleParagraphProperties16 = new StyleParagraphProperties();
            KeepNext keepNext12 = new KeepNext();

            Tabs tabs7 = new Tabs();
            TabStop tabStop9 = new TabStop() { Val = TabStopValues.Left, Position = 709 };

            tabs7.Append(tabStop9);
            SuppressAutoHyphens suppressAutoHyphens5 = new SuppressAutoHyphens();
            SpacingBetweenLines spacingBetweenLines21 = new SpacingBetweenLines() { Before = "240", After = "120", Line = "276", LineRule = LineSpacingRuleValues.AtLeast };
            OutlineLevel outlineLevel12 = new OutlineLevel() { Val = 2 };

            styleParagraphProperties16.Append(keepNext12);
            styleParagraphProperties16.Append(tabs7);
            styleParagraphProperties16.Append(suppressAutoHyphens5);
            styleParagraphProperties16.Append(spacingBetweenLines21);
            styleParagraphProperties16.Append(outlineLevel12);

            StyleRunProperties styleRunProperties23 = new StyleRunProperties();
            RunFonts runFonts25 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", EastAsia = "SimSun", ComplexScript = "Mangal" };
            Bold bold16 = new Bold();
            BoldComplexScript boldComplexScript16 = new BoldComplexScript();
            Color color23 = new Color() { Val = "00000A" };
            FontSize fontSize15 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript15 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties23.Append(runFonts25);
            styleRunProperties23.Append(bold16);
            styleRunProperties23.Append(boldComplexScript16);
            styleRunProperties23.Append(color23);
            styleRunProperties23.Append(fontSize15);
            styleRunProperties23.Append(fontSizeComplexScript15);

            style33.Append(styleName33);
            style33.Append(basedOn28);
            style33.Append(linkedStyle27);
            style33.Append(rsid56);
            style33.Append(styleParagraphProperties16);
            style33.Append(styleRunProperties23);

            Style style34 = new Style() { Type = StyleValues.Paragraph, StyleId = "4" };
            StyleName styleName34 = new StyleName() { Val = "heading 4" };
            BasedOn basedOn29 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle9 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle28 = new LinkedStyle() { Val = "40" };
            UIPriority uIPriority23 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed12 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle12 = new PrimaryStyle();
            Rsid rsid57 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties17 = new StyleParagraphProperties();
            KeepNext keepNext13 = new KeepNext();
            KeepLines keepLines9 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines22 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel13 = new OutlineLevel() { Val = 3 };

            styleParagraphProperties17.Append(keepNext13);
            styleParagraphProperties17.Append(keepLines9);
            styleParagraphProperties17.Append(spacingBetweenLines22);
            styleParagraphProperties17.Append(outlineLevel13);

            StyleRunProperties styleRunProperties24 = new StyleRunProperties();
            RunFonts runFonts26 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold17 = new Bold();
            BoldComplexScript boldComplexScript17 = new BoldComplexScript();
            Italic italic9 = new Italic();
            ItalicComplexScript italicComplexScript9 = new ItalicComplexScript();
            Color color24 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties24.Append(runFonts26);
            styleRunProperties24.Append(bold17);
            styleRunProperties24.Append(boldComplexScript17);
            styleRunProperties24.Append(italic9);
            styleRunProperties24.Append(italicComplexScript9);
            styleRunProperties24.Append(color24);

            style34.Append(styleName34);
            style34.Append(basedOn29);
            style34.Append(nextParagraphStyle9);
            style34.Append(linkedStyle28);
            style34.Append(uIPriority23);
            style34.Append(unhideWhenUsed12);
            style34.Append(primaryStyle12);
            style34.Append(rsid57);
            style34.Append(styleParagraphProperties17);
            style34.Append(styleRunProperties24);

            Style style35 = new Style() { Type = StyleValues.Paragraph, StyleId = "5" };
            StyleName styleName35 = new StyleName() { Val = "heading 5" };
            BasedOn basedOn30 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle10 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle29 = new LinkedStyle() { Val = "50" };
            UIPriority uIPriority24 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed13 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle13 = new PrimaryStyle();
            Rsid rsid58 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties18 = new StyleParagraphProperties();
            KeepNext keepNext14 = new KeepNext();
            KeepLines keepLines10 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines23 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel14 = new OutlineLevel() { Val = 4 };

            styleParagraphProperties18.Append(keepNext14);
            styleParagraphProperties18.Append(keepLines10);
            styleParagraphProperties18.Append(spacingBetweenLines23);
            styleParagraphProperties18.Append(outlineLevel14);

            StyleRunProperties styleRunProperties25 = new StyleRunProperties();
            RunFonts runFonts27 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color25 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties25.Append(runFonts27);
            styleRunProperties25.Append(color25);

            style35.Append(styleName35);
            style35.Append(basedOn30);
            style35.Append(nextParagraphStyle10);
            style35.Append(linkedStyle29);
            style35.Append(uIPriority24);
            style35.Append(unhideWhenUsed13);
            style35.Append(primaryStyle13);
            style35.Append(rsid58);
            style35.Append(styleParagraphProperties18);
            style35.Append(styleRunProperties25);

            Style style36 = new Style() { Type = StyleValues.Paragraph, StyleId = "6" };
            StyleName styleName36 = new StyleName() { Val = "heading 6" };
            BasedOn basedOn31 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle11 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle30 = new LinkedStyle() { Val = "60" };
            UIPriority uIPriority25 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed14 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle14 = new PrimaryStyle();
            Rsid rsid59 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties19 = new StyleParagraphProperties();
            KeepNext keepNext15 = new KeepNext();
            KeepLines keepLines11 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines24 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel15 = new OutlineLevel() { Val = 5 };

            styleParagraphProperties19.Append(keepNext15);
            styleParagraphProperties19.Append(keepLines11);
            styleParagraphProperties19.Append(spacingBetweenLines24);
            styleParagraphProperties19.Append(outlineLevel15);

            StyleRunProperties styleRunProperties26 = new StyleRunProperties();
            RunFonts runFonts28 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic10 = new Italic();
            ItalicComplexScript italicComplexScript10 = new ItalicComplexScript();
            Color color26 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties26.Append(runFonts28);
            styleRunProperties26.Append(italic10);
            styleRunProperties26.Append(italicComplexScript10);
            styleRunProperties26.Append(color26);

            style36.Append(styleName36);
            style36.Append(basedOn31);
            style36.Append(nextParagraphStyle11);
            style36.Append(linkedStyle30);
            style36.Append(uIPriority25);
            style36.Append(unhideWhenUsed14);
            style36.Append(primaryStyle14);
            style36.Append(rsid59);
            style36.Append(styleParagraphProperties19);
            style36.Append(styleRunProperties26);

            Style style37 = new Style() { Type = StyleValues.Paragraph, StyleId = "7" };
            StyleName styleName37 = new StyleName() { Val = "heading 7" };
            BasedOn basedOn32 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle12 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle31 = new LinkedStyle() { Val = "70" };
            UIPriority uIPriority26 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed15 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle15 = new PrimaryStyle();
            Rsid rsid60 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties20 = new StyleParagraphProperties();
            KeepNext keepNext16 = new KeepNext();
            KeepLines keepLines12 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines25 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel16 = new OutlineLevel() { Val = 6 };

            styleParagraphProperties20.Append(keepNext16);
            styleParagraphProperties20.Append(keepLines12);
            styleParagraphProperties20.Append(spacingBetweenLines25);
            styleParagraphProperties20.Append(outlineLevel16);

            StyleRunProperties styleRunProperties27 = new StyleRunProperties();
            RunFonts runFonts29 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic11 = new Italic();
            ItalicComplexScript italicComplexScript11 = new ItalicComplexScript();
            Color color27 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };

            styleRunProperties27.Append(runFonts29);
            styleRunProperties27.Append(italic11);
            styleRunProperties27.Append(italicComplexScript11);
            styleRunProperties27.Append(color27);

            style37.Append(styleName37);
            style37.Append(basedOn32);
            style37.Append(nextParagraphStyle12);
            style37.Append(linkedStyle31);
            style37.Append(uIPriority26);
            style37.Append(unhideWhenUsed15);
            style37.Append(primaryStyle15);
            style37.Append(rsid60);
            style37.Append(styleParagraphProperties20);
            style37.Append(styleRunProperties27);

            Style style38 = new Style() { Type = StyleValues.Paragraph, StyleId = "8" };
            StyleName styleName38 = new StyleName() { Val = "heading 8" };
            BasedOn basedOn33 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle13 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle32 = new LinkedStyle() { Val = "80" };
            UIPriority uIPriority27 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed16 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle16 = new PrimaryStyle();
            Rsid rsid61 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties21 = new StyleParagraphProperties();
            KeepNext keepNext17 = new KeepNext();
            KeepLines keepLines13 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines26 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel17 = new OutlineLevel() { Val = 7 };

            styleParagraphProperties21.Append(keepNext17);
            styleParagraphProperties21.Append(keepLines13);
            styleParagraphProperties21.Append(spacingBetweenLines26);
            styleParagraphProperties21.Append(outlineLevel17);

            StyleRunProperties styleRunProperties28 = new StyleRunProperties();
            RunFonts runFonts30 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color28 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize16 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript16 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties28.Append(runFonts30);
            styleRunProperties28.Append(color28);
            styleRunProperties28.Append(fontSize16);
            styleRunProperties28.Append(fontSizeComplexScript16);

            style38.Append(styleName38);
            style38.Append(basedOn33);
            style38.Append(nextParagraphStyle13);
            style38.Append(linkedStyle32);
            style38.Append(uIPriority27);
            style38.Append(unhideWhenUsed16);
            style38.Append(primaryStyle16);
            style38.Append(rsid61);
            style38.Append(styleParagraphProperties21);
            style38.Append(styleRunProperties28);

            Style style39 = new Style() { Type = StyleValues.Paragraph, StyleId = "9" };
            StyleName styleName39 = new StyleName() { Val = "heading 9" };
            BasedOn basedOn34 = new BasedOn() { Val = "a0" };
            NextParagraphStyle nextParagraphStyle14 = new NextParagraphStyle() { Val = "a0" };
            LinkedStyle linkedStyle33 = new LinkedStyle() { Val = "90" };
            UIPriority uIPriority28 = new UIPriority() { Val = 9 };
            UnhideWhenUsed unhideWhenUsed17 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle17 = new PrimaryStyle();
            Rsid rsid62 = new Rsid() { Val = "00DB5B7C" };

            StyleParagraphProperties styleParagraphProperties22 = new StyleParagraphProperties();
            KeepNext keepNext18 = new KeepNext();
            KeepLines keepLines14 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines27 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel18 = new OutlineLevel() { Val = 8 };

            styleParagraphProperties22.Append(keepNext18);
            styleParagraphProperties22.Append(keepLines14);
            styleParagraphProperties22.Append(spacingBetweenLines27);
            styleParagraphProperties22.Append(outlineLevel18);

            StyleRunProperties styleRunProperties29 = new StyleRunProperties();
            RunFonts runFonts31 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic12 = new Italic();
            ItalicComplexScript italicComplexScript12 = new ItalicComplexScript();
            Color color29 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize17 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript17 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties29.Append(runFonts31);
            styleRunProperties29.Append(italic12);
            styleRunProperties29.Append(italicComplexScript12);
            styleRunProperties29.Append(color29);
            styleRunProperties29.Append(fontSize17);
            styleRunProperties29.Append(fontSizeComplexScript17);

            style39.Append(styleName39);
            style39.Append(basedOn34);
            style39.Append(nextParagraphStyle14);
            style39.Append(linkedStyle33);
            style39.Append(uIPriority28);
            style39.Append(unhideWhenUsed17);
            style39.Append(primaryStyle17);
            style39.Append(rsid62);
            style39.Append(styleParagraphProperties22);
            style39.Append(styleRunProperties29);

            Style style40 = new Style() { Type = StyleValues.Character, StyleId = "a1", Default = true };
            StyleName styleName40 = new StyleName() { Val = "Default Paragraph Font" };
            UIPriority uIPriority29 = new UIPriority() { Val = 1 };
            SemiHidden semiHidden4 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed18 = new UnhideWhenUsed();

            style40.Append(styleName40);
            style40.Append(uIPriority29);
            style40.Append(semiHidden4);
            style40.Append(unhideWhenUsed18);

            Style style41 = new Style() { Type = StyleValues.Table, StyleId = "a2", Default = true };
            StyleName styleName41 = new StyleName() { Val = "Normal Table" };
            UIPriority uIPriority30 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden5 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed19 = new UnhideWhenUsed();

            StyleTableProperties styleTableProperties2 = new StyleTableProperties();
            TableIndentation tableIndentation2 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault2 = new TableCellMarginDefault();
            TopMargin topMargin2 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin2 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin2 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin2 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault2.Append(topMargin2);
            tableCellMarginDefault2.Append(tableCellLeftMargin2);
            tableCellMarginDefault2.Append(bottomMargin2);
            tableCellMarginDefault2.Append(tableCellRightMargin2);

            styleTableProperties2.Append(tableIndentation2);
            styleTableProperties2.Append(tableCellMarginDefault2);

            style41.Append(styleName41);
            style41.Append(uIPriority30);
            style41.Append(semiHidden5);
            style41.Append(unhideWhenUsed19);
            style41.Append(styleTableProperties2);

            Style style42 = new Style() { Type = StyleValues.Numbering, StyleId = "a3", Default = true };
            StyleName styleName42 = new StyleName() { Val = "No List" };
            UIPriority uIPriority31 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden6 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed20 = new UnhideWhenUsed();

            style42.Append(styleName42);
            style42.Append(uIPriority31);
            style42.Append(semiHidden6);
            style42.Append(unhideWhenUsed20);

            Style style43 = new Style() { Type = StyleValues.Character, StyleId = "20", CustomStyle = true };
            StyleName styleName43 = new StyleName() { Val = "Заголовок 2 Знак" };
            BasedOn basedOn35 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle34 = new LinkedStyle() { Val = "2" };
            Rsid rsid63 = new Rsid() { Val = "00820AEF" };

            StyleRunProperties styleRunProperties30 = new StyleRunProperties();
            RunFonts runFonts32 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "SimSun" };
            Bold bold18 = new Bold();
            BoldComplexScript boldComplexScript18 = new BoldComplexScript();
            Color color30 = new Color() { Val = "4F81BD" };
            FontSize fontSize18 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript18 = new FontSizeComplexScript() { Val = "26" };

            styleRunProperties30.Append(runFonts32);
            styleRunProperties30.Append(bold18);
            styleRunProperties30.Append(boldComplexScript18);
            styleRunProperties30.Append(color30);
            styleRunProperties30.Append(fontSize18);
            styleRunProperties30.Append(fontSizeComplexScript18);

            style43.Append(styleName43);
            style43.Append(basedOn35);
            style43.Append(linkedStyle34);
            style43.Append(rsid63);
            style43.Append(styleRunProperties30);

            Style style44 = new Style() { Type = StyleValues.Character, StyleId = "30", CustomStyle = true };
            StyleName styleName44 = new StyleName() { Val = "Заголовок 3 Знак" };
            BasedOn basedOn36 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle35 = new LinkedStyle() { Val = "3" };
            Rsid rsid64 = new Rsid() { Val = "00820AEF" };

            StyleRunProperties styleRunProperties31 = new StyleRunProperties();
            RunFonts runFonts33 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", EastAsia = "SimSun", ComplexScript = "Mangal" };
            Bold bold19 = new Bold();
            BoldComplexScript boldComplexScript19 = new BoldComplexScript();
            Color color31 = new Color() { Val = "00000A" };
            FontSize fontSize19 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript19 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties31.Append(runFonts33);
            styleRunProperties31.Append(bold19);
            styleRunProperties31.Append(boldComplexScript19);
            styleRunProperties31.Append(color31);
            styleRunProperties31.Append(fontSize19);
            styleRunProperties31.Append(fontSizeComplexScript19);

            style44.Append(styleName44);
            style44.Append(basedOn36);
            style44.Append(linkedStyle35);
            style44.Append(rsid64);
            style44.Append(styleRunProperties31);

            Style style45 = new Style() { Type = StyleValues.Paragraph, StyleId = "a4" };
            StyleName styleName45 = new StyleName() { Val = "Body Text" };
            BasedOn basedOn37 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle36 = new LinkedStyle() { Val = "a5" };
            Rsid rsid65 = new Rsid() { Val = "00820AEF" };

            StyleParagraphProperties styleParagraphProperties23 = new StyleParagraphProperties();

            Tabs tabs8 = new Tabs();
            TabStop tabStop10 = new TabStop() { Val = TabStopValues.Left, Position = 709 };

            tabs8.Append(tabStop10);
            SuppressAutoHyphens suppressAutoHyphens6 = new SuppressAutoHyphens();
            SpacingBetweenLines spacingBetweenLines28 = new SpacingBetweenLines() { After = "120", Line = "276", LineRule = LineSpacingRuleValues.AtLeast };

            styleParagraphProperties23.Append(tabs8);
            styleParagraphProperties23.Append(suppressAutoHyphens6);
            styleParagraphProperties23.Append(spacingBetweenLines28);

            StyleRunProperties styleRunProperties32 = new StyleRunProperties();
            RunFonts runFonts34 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "SimSun" };
            Color color32 = new Color() { Val = "00000A" };

            styleRunProperties32.Append(runFonts34);
            styleRunProperties32.Append(color32);

            style45.Append(styleName45);
            style45.Append(basedOn37);
            style45.Append(linkedStyle36);
            style45.Append(rsid65);
            style45.Append(styleParagraphProperties23);
            style45.Append(styleRunProperties32);

            Style style46 = new Style() { Type = StyleValues.Character, StyleId = "a5", CustomStyle = true };
            StyleName styleName46 = new StyleName() { Val = "Основной текст Знак" };
            BasedOn basedOn38 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle37 = new LinkedStyle() { Val = "a4" };
            Rsid rsid66 = new Rsid() { Val = "00820AEF" };

            StyleRunProperties styleRunProperties33 = new StyleRunProperties();
            RunFonts runFonts35 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "SimSun" };
            Color color33 = new Color() { Val = "00000A" };

            styleRunProperties33.Append(runFonts35);
            styleRunProperties33.Append(color33);

            style46.Append(styleName46);
            style46.Append(basedOn38);
            style46.Append(linkedStyle37);
            style46.Append(rsid66);
            style46.Append(styleRunProperties33);

            Style style47 = new Style() { Type = StyleValues.Paragraph, StyleId = "a", CustomStyle = true };
            StyleName styleName47 = new StyleName() { Val = "заголовок орвд" };
            BasedOn basedOn39 = new BasedOn() { Val = "3" };
            PrimaryStyle primaryStyle18 = new PrimaryStyle();
            Rsid rsid67 = new Rsid() { Val = "00820AEF" };

            StyleParagraphProperties styleParagraphProperties24 = new StyleParagraphProperties();

            NumberingProperties numberingProperties2 = new NumberingProperties();
            NumberingLevelReference numberingLevelReference2 = new NumberingLevelReference() { Val = 2 };
            NumberingId numberingId2 = new NumberingId() { Val = 1 };

            numberingProperties2.Append(numberingLevelReference2);
            numberingProperties2.Append(numberingId2);

            styleParagraphProperties24.Append(numberingProperties2);

            style47.Append(styleName47);
            style47.Append(basedOn39);
            style47.Append(primaryStyle18);
            style47.Append(rsid67);
            style47.Append(styleParagraphProperties24);

            Style style48 = new Style() { Type = StyleValues.Character, StyleId = "40", CustomStyle = true };
            StyleName styleName48 = new StyleName() { Val = "Заголовок 4 Знак" };
            BasedOn basedOn40 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle38 = new LinkedStyle() { Val = "4" };
            UIPriority uIPriority32 = new UIPriority() { Val = 9 };
            Rsid rsid68 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties34 = new StyleRunProperties();
            RunFonts runFonts36 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold20 = new Bold();
            BoldComplexScript boldComplexScript20 = new BoldComplexScript();
            Italic italic13 = new Italic();
            ItalicComplexScript italicComplexScript13 = new ItalicComplexScript();
            Color color34 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties34.Append(runFonts36);
            styleRunProperties34.Append(bold20);
            styleRunProperties34.Append(boldComplexScript20);
            styleRunProperties34.Append(italic13);
            styleRunProperties34.Append(italicComplexScript13);
            styleRunProperties34.Append(color34);

            style48.Append(styleName48);
            style48.Append(basedOn40);
            style48.Append(linkedStyle38);
            style48.Append(uIPriority32);
            style48.Append(rsid68);
            style48.Append(styleRunProperties34);

            Style style49 = new Style() { Type = StyleValues.Character, StyleId = "50", CustomStyle = true };
            StyleName styleName49 = new StyleName() { Val = "Заголовок 5 Знак" };
            BasedOn basedOn41 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle39 = new LinkedStyle() { Val = "5" };
            UIPriority uIPriority33 = new UIPriority() { Val = 9 };
            Rsid rsid69 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties35 = new StyleRunProperties();
            RunFonts runFonts37 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color35 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties35.Append(runFonts37);
            styleRunProperties35.Append(color35);

            style49.Append(styleName49);
            style49.Append(basedOn41);
            style49.Append(linkedStyle39);
            style49.Append(uIPriority33);
            style49.Append(rsid69);
            style49.Append(styleRunProperties35);

            Style style50 = new Style() { Type = StyleValues.Character, StyleId = "60", CustomStyle = true };
            StyleName styleName50 = new StyleName() { Val = "Заголовок 6 Знак" };
            BasedOn basedOn42 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle40 = new LinkedStyle() { Val = "6" };
            UIPriority uIPriority34 = new UIPriority() { Val = 9 };
            Rsid rsid70 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties36 = new StyleRunProperties();
            RunFonts runFonts38 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic14 = new Italic();
            ItalicComplexScript italicComplexScript14 = new ItalicComplexScript();
            Color color36 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties36.Append(runFonts38);
            styleRunProperties36.Append(italic14);
            styleRunProperties36.Append(italicComplexScript14);
            styleRunProperties36.Append(color36);

            style50.Append(styleName50);
            style50.Append(basedOn42);
            style50.Append(linkedStyle40);
            style50.Append(uIPriority34);
            style50.Append(rsid70);
            style50.Append(styleRunProperties36);

            Style style51 = new Style() { Type = StyleValues.Character, StyleId = "70", CustomStyle = true };
            StyleName styleName51 = new StyleName() { Val = "Заголовок 7 Знак" };
            BasedOn basedOn43 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle41 = new LinkedStyle() { Val = "7" };
            UIPriority uIPriority35 = new UIPriority() { Val = 9 };
            Rsid rsid71 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties37 = new StyleRunProperties();
            RunFonts runFonts39 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic15 = new Italic();
            ItalicComplexScript italicComplexScript15 = new ItalicComplexScript();
            Color color37 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };

            styleRunProperties37.Append(runFonts39);
            styleRunProperties37.Append(italic15);
            styleRunProperties37.Append(italicComplexScript15);
            styleRunProperties37.Append(color37);

            style51.Append(styleName51);
            style51.Append(basedOn43);
            style51.Append(linkedStyle41);
            style51.Append(uIPriority35);
            style51.Append(rsid71);
            style51.Append(styleRunProperties37);

            Style style52 = new Style() { Type = StyleValues.Character, StyleId = "80", CustomStyle = true };
            StyleName styleName52 = new StyleName() { Val = "Заголовок 8 Знак" };
            BasedOn basedOn44 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle42 = new LinkedStyle() { Val = "8" };
            UIPriority uIPriority36 = new UIPriority() { Val = 9 };
            Rsid rsid72 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties38 = new StyleRunProperties();
            RunFonts runFonts40 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color38 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize20 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript20 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties38.Append(runFonts40);
            styleRunProperties38.Append(color38);
            styleRunProperties38.Append(fontSize20);
            styleRunProperties38.Append(fontSizeComplexScript20);

            style52.Append(styleName52);
            style52.Append(basedOn44);
            style52.Append(linkedStyle42);
            style52.Append(uIPriority36);
            style52.Append(rsid72);
            style52.Append(styleRunProperties38);

            Style style53 = new Style() { Type = StyleValues.Character, StyleId = "90", CustomStyle = true };
            StyleName styleName53 = new StyleName() { Val = "Заголовок 9 Знак" };
            BasedOn basedOn45 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle43 = new LinkedStyle() { Val = "9" };
            UIPriority uIPriority37 = new UIPriority() { Val = 9 };
            Rsid rsid73 = new Rsid() { Val = "00DB5B7C" };

            StyleRunProperties styleRunProperties39 = new StyleRunProperties();
            RunFonts runFonts41 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic16 = new Italic();
            ItalicComplexScript italicComplexScript16 = new ItalicComplexScript();
            Color color39 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize21 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript21 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties39.Append(runFonts41);
            styleRunProperties39.Append(italic16);
            styleRunProperties39.Append(italicComplexScript16);
            styleRunProperties39.Append(color39);
            styleRunProperties39.Append(fontSize21);
            styleRunProperties39.Append(fontSizeComplexScript21);

            style53.Append(styleName53);
            style53.Append(basedOn45);
            style53.Append(linkedStyle43);
            style53.Append(uIPriority37);
            style53.Append(rsid73);
            style53.Append(styleRunProperties39);

            Style style54 = new Style() { Type = StyleValues.Paragraph, StyleId = "a6" };
            StyleName styleName54 = new StyleName() { Val = "header" };
            BasedOn basedOn46 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle44 = new LinkedStyle() { Val = "a7" };
            UIPriority uIPriority38 = new UIPriority() { Val = 99 };
            UnhideWhenUsed unhideWhenUsed21 = new UnhideWhenUsed();
            Rsid rsid74 = new Rsid() { Val = "00946533" };

            StyleParagraphProperties styleParagraphProperties25 = new StyleParagraphProperties();

            Tabs tabs9 = new Tabs();
            TabStop tabStop11 = new TabStop() { Val = TabStopValues.Center, Position = 4677 };
            TabStop tabStop12 = new TabStop() { Val = TabStopValues.Right, Position = 9355 };

            tabs9.Append(tabStop11);
            tabs9.Append(tabStop12);
            SpacingBetweenLines spacingBetweenLines29 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties25.Append(tabs9);
            styleParagraphProperties25.Append(spacingBetweenLines29);

            style54.Append(styleName54);
            style54.Append(basedOn46);
            style54.Append(linkedStyle44);
            style54.Append(uIPriority38);
            style54.Append(unhideWhenUsed21);
            style54.Append(rsid74);
            style54.Append(styleParagraphProperties25);

            Style style55 = new Style() { Type = StyleValues.Character, StyleId = "a7", CustomStyle = true };
            StyleName styleName55 = new StyleName() { Val = "Верхний колонтитул Знак" };
            BasedOn basedOn47 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle45 = new LinkedStyle() { Val = "a6" };
            UIPriority uIPriority39 = new UIPriority() { Val = 99 };
            Rsid rsid75 = new Rsid() { Val = "00946533" };

            style55.Append(styleName55);
            style55.Append(basedOn47);
            style55.Append(linkedStyle45);
            style55.Append(uIPriority39);
            style55.Append(rsid75);

            Style style56 = new Style() { Type = StyleValues.Paragraph, StyleId = "a8" };
            StyleName styleName56 = new StyleName() { Val = "footer" };
            BasedOn basedOn48 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle46 = new LinkedStyle() { Val = "a9" };
            UIPriority uIPriority40 = new UIPriority() { Val = 99 };
            UnhideWhenUsed unhideWhenUsed22 = new UnhideWhenUsed();
            Rsid rsid76 = new Rsid() { Val = "00946533" };

            StyleParagraphProperties styleParagraphProperties26 = new StyleParagraphProperties();

            Tabs tabs10 = new Tabs();
            TabStop tabStop13 = new TabStop() { Val = TabStopValues.Center, Position = 4677 };
            TabStop tabStop14 = new TabStop() { Val = TabStopValues.Right, Position = 9355 };

            tabs10.Append(tabStop13);
            tabs10.Append(tabStop14);
            SpacingBetweenLines spacingBetweenLines30 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties26.Append(tabs10);
            styleParagraphProperties26.Append(spacingBetweenLines30);

            style56.Append(styleName56);
            style56.Append(basedOn48);
            style56.Append(linkedStyle46);
            style56.Append(uIPriority40);
            style56.Append(unhideWhenUsed22);
            style56.Append(rsid76);
            style56.Append(styleParagraphProperties26);

            Style style57 = new Style() { Type = StyleValues.Character, StyleId = "a9", CustomStyle = true };
            StyleName styleName57 = new StyleName() { Val = "Нижний колонтитул Знак" };
            BasedOn basedOn49 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle47 = new LinkedStyle() { Val = "a8" };
            UIPriority uIPriority41 = new UIPriority() { Val = 99 };
            Rsid rsid77 = new Rsid() { Val = "00946533" };

            style57.Append(styleName57);
            style57.Append(basedOn49);
            style57.Append(linkedStyle47);
            style57.Append(uIPriority41);
            style57.Append(rsid77);

            Style style58 = new Style() { Type = StyleValues.Character, StyleId = "10", CustomStyle = true };
            StyleName styleName58 = new StyleName() { Val = "Заголовок 1 Знак" };
            BasedOn basedOn50 = new BasedOn() { Val = "a1" };
            LinkedStyle linkedStyle48 = new LinkedStyle() { Val = "1" };
            UIPriority uIPriority42 = new UIPriority() { Val = 9 };
            Rsid rsid78 = new Rsid() { Val = "00056893" };

            StyleRunProperties styleRunProperties40 = new StyleRunProperties();
            RunFonts runFonts42 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold21 = new Bold();
            BoldComplexScript boldComplexScript21 = new BoldComplexScript();
            Color color40 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
            FontSize fontSize22 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript22 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties40.Append(runFonts42);
            styleRunProperties40.Append(bold21);
            styleRunProperties40.Append(boldComplexScript21);
            styleRunProperties40.Append(color40);
            styleRunProperties40.Append(fontSize22);
            styleRunProperties40.Append(fontSizeComplexScript22);

            style58.Append(styleName58);
            style58.Append(basedOn50);
            style58.Append(linkedStyle48);
            style58.Append(uIPriority42);
            style58.Append(rsid78);
            style58.Append(styleRunProperties40);

            styles2.Append(docDefaults2);
            styles2.Append(latentStyles2);
            styles2.Append(style30);
            styles2.Append(style31);
            styles2.Append(style32);
            styles2.Append(style33);
            styles2.Append(style34);
            styles2.Append(style35);
            styles2.Append(style36);
            styles2.Append(style37);
            styles2.Append(style38);
            styles2.Append(style39);
            styles2.Append(style40);
            styles2.Append(style41);
            styles2.Append(style42);
            styles2.Append(style43);
            styles2.Append(style44);
            styles2.Append(style45);
            styles2.Append(style46);
            styles2.Append(style47);
            styles2.Append(style48);
            styles2.Append(style49);
            styles2.Append(style50);
            styles2.Append(style51);
            styles2.Append(style52);
            styles2.Append(style53);
            styles2.Append(style54);
            styles2.Append(style55);
            styles2.Append(style56);
            styles2.Append(style57);
            styles2.Append(style58);

            stylesWithEffectsPart1.Styles = styles2;
        }

        // Generates content of footerPart1.
        private void GenerateFooterPart1Content(FooterPart footerPart1)
        {
            Footer footer1 = new Footer() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            footer1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            footer1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            footer1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            footer1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            footer1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            footer1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            footer1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            footer1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            footer1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            footer1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            footer1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            footer1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            footer1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            footer1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            footer1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            SdtBlock sdtBlock1 = new SdtBlock();

            SdtProperties sdtProperties1 = new SdtProperties();
            SdtId sdtId1 = new SdtId() { Val = -469369432 };

            SdtContentDocPartObject sdtContentDocPartObject1 = new SdtContentDocPartObject();
            DocPartGallery docPartGallery1 = new DocPartGallery() { Val = "Page Numbers (Bottom of Page)" };
            DocPartUnique docPartUnique1 = new DocPartUnique();

            sdtContentDocPartObject1.Append(docPartGallery1);
            sdtContentDocPartObject1.Append(docPartUnique1);

            sdtProperties1.Append(sdtId1);
            sdtProperties1.Append(sdtContentDocPartObject1);
            SdtEndCharProperties sdtEndCharProperties1 = new SdtEndCharProperties();

            SdtContentBlock sdtContentBlock1 = new SdtContentBlock();

            Paragraph paragraph8 = new Paragraph() { RsidParagraphAddition = "00946533", RsidRunAdditionDefault = "00946533" };

            ParagraphProperties paragraphProperties7 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "a8" };
            Justification justification1 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties7.Append(paragraphStyleId1);
            paragraphProperties7.Append(justification1);

            Run run11 = new Run();
            FieldChar fieldChar4 = new FieldChar() { FieldCharType = FieldCharValues.Begin };

            run11.Append(fieldChar4);

            Run run12 = new Run();
            FieldCode fieldCode2 = new FieldCode();
            fieldCode2.Text = "PAGE   \\* MERGEFORMAT";

            run12.Append(fieldCode2);

            Run run13 = new Run();
            FieldChar fieldChar5 = new FieldChar() { FieldCharType = FieldCharValues.Separate };

            run13.Append(fieldChar5);

            Run run14 = new Run() { RsidRunAddition = "008042CE" };

            RunProperties runProperties4 = new RunProperties();
            NoProof noProof6 = new NoProof();

            runProperties4.Append(noProof6);
            Text text2 = new Text();
            text2.Text = "2";

            run14.Append(runProperties4);
            run14.Append(text2);

            Run run15 = new Run();
            FieldChar fieldChar6 = new FieldChar() { FieldCharType = FieldCharValues.End };

            run15.Append(fieldChar6);

            paragraph8.Append(paragraphProperties7);
            paragraph8.Append(run11);
            paragraph8.Append(run12);
            paragraph8.Append(run13);
            paragraph8.Append(run14);
            paragraph8.Append(run15);

            sdtContentBlock1.Append(paragraph8);

            sdtBlock1.Append(sdtProperties1);
            sdtBlock1.Append(sdtEndCharProperties1);
            sdtBlock1.Append(sdtContentBlock1);

            Paragraph paragraph9 = new Paragraph() { RsidParagraphAddition = "00946533", RsidRunAdditionDefault = "00946533" };

            ParagraphProperties paragraphProperties8 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "a8" };

            paragraphProperties8.Append(paragraphStyleId2);

            paragraph9.Append(paragraphProperties8);

            footer1.Append(sdtBlock1);
            footer1.Append(paragraph9);

            footerPart1.Footer = footer1;
        }


        private void SetPackageProperties(OpenXmlPackage document)
        {
        }



        public void Dispose()
        {
            if (this.Document != null)
            {
                this.Document.Dispose();
            }
        }
    }

}

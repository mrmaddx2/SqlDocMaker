using System;
using System.Drawing;

namespace Vitasoft.DocMaker.Core
{
    public interface IDocUploader : IDisposable
    {
        /*
        object AddNewPage(string headerText = null);
        object AddNewTableCell(object table, string content, Color color, CustomFont customFont = null);
        bool AddParagraphToDoc(object paragraph);
        
        bool AddTableToDoc(object table);
        object CreateDatasetTable(float[] widths);
        object CreateParagraph(string Text = null, CustomFont customFont = null);
        object CreateParamTable(float[] widths);
        object CreateTable(float[] widths);
        object CreateTable(int columnsCount);
         */
        object AddSummaryInfo(object insertAfter, DocObject docObject, Color backgroundColor);
        object ForceSection(string headerText = null);
        object AddParametersInfo(object insertAfter, DocObject docObject, Color headerColor, Color elseColor);
        object AddReturnDatasetInfo(object insertAfter, DocProcedure docProcedure, Color headerColor, Color elseColor);
        object AddReturnValueInfo(object insertAfter, DocFunction docFunction, Color backgrouColor);
    }
}

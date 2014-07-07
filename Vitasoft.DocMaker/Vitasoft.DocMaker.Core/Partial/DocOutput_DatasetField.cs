using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public partial class DocOutput_DatasetField
    {
        public static DocOutput_DatasetField CreateNew(string name, string dataTypeName, string comment)
        {
            DocOutput_DatasetField result = new DocOutput_DatasetField();

            result.Name = name;
            result.DataTypeName = dataTypeName;
            result.Comment = comment;

            return result;
        }
    }
}

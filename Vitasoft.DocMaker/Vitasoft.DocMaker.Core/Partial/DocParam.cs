using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public partial class DocParam
    {
        public static DocParam CreateNew(string name, string dataTypeName, string comment)
        {
            DocParam result = new DocParam();

            result.Name = name;
            result.DataTypeName = dataTypeName;
            result.Comment = comment;

            return result;
        }
    }
}

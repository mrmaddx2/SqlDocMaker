using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public class OutputField
    {
        public string Name { get; private set; }
        public string DataTypeName { get; private set; }
        public string SourceObjectName { get; private set; }
        public string SourceFieldName { get; private set; }
        public string Comment { get; set; }

        public OutputField(string name, string dataTypeName, string sourceObjectName = null, string sourceFieldName = null)
        {
            Name = name;
            DataTypeName = dataTypeName;
            SourceObjectName = string.IsNullOrWhiteSpace(sourceObjectName) ? string.Empty : sourceObjectName;
            SourceFieldName = string.IsNullOrWhiteSpace(sourceFieldName) ? string.Empty : sourceFieldName;
        }
    }
}

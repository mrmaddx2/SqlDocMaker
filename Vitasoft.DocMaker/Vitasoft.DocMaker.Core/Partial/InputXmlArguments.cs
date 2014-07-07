using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public partial class InputXmlArguments
    {
        public string OutputFolderOrDefault
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.OutputFolder) ? Path.GetTempPath() : this.OutputFolder;
            }
        }
    }
}

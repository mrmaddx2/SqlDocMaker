using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public interface ILogWriter
    {
        void WriteLine(string message);
    }
}

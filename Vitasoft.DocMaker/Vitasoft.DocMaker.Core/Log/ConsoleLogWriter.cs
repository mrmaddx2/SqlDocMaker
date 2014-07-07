using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public class ConsoleLogWriter : ILogWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}

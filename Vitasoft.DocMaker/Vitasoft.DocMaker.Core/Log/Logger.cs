using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public class Logger
    {
        ILogWriter Output;
        ILogWriter Error = null;
        ILogWriter Warning = null;
        public Logger(string type)
        {
            if (type == "Console" || type == "" || type == null)
                Output = new ConsoleLogWriter();
            else
            {
                Output = new FileLogWriter(type);
                Error = new FileLogWriter(type.Substring(0, type.IndexOf('.')) + "_Errors.log", true);
                Warning = new FileLogWriter(type.Substring(0, type.IndexOf('.')) + "_Warnings.log", true);
            }
        }
        public void LogError(string message, bool withDateTime = false)
        {
            if (withDateTime)
            {
                message = DateTime.Now.ToString() + "  " + message;
            }

            string msg = " !!!ERROR!!! " + message;
            WriteError(msg);
        }

        public void WriteWarning(string message, bool withDateTime = false)
        {
            if (withDateTime)
            {
                message = DateTime.Now.ToString() + "  " + message;
            }

            string msg = " !!!Warning!!! " + message;
            WriteWarning(msg);
        }

        //public void LogError(Exception e, MyReader owner = null, int i = -1)
        //{
        //    string msg = e.Message + (owner == null ? "" : owner.GetInfo(i));
        //    LogError(msg, owner);
        //}

        private void WriteError(string message)
        {
            Output.WriteLine(message);
            if (Error != null)
            {
                Error.WriteLine(message);
            }
        }

        private void WriteWarning(string message)
        {
            Output.WriteLine(message);
            if (Warning != null)
            {
                Warning.WriteLine(message);
            }
        }
        public void WriteLine(string message, bool withDateTime = false)
        {
            if (withDateTime)
            {
                message = DateTime.Now.ToString() + "  " + message;
            }

            Output.WriteLine(message);
        }
    }
}

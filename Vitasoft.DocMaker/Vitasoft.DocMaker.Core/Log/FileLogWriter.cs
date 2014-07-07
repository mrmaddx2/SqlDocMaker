using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public class FileLogWriter : ILogWriter
    {
        StreamWriter writer = null;
        bool ErrorMode;
        string FilePath;
        void Initialize(string path)
        {
            writer = new StreamWriter(path, true, Encoding.GetEncoding(1251));
            writer.AutoFlush = true;
        }
        public FileLogWriter(string path, bool error = false)
        {
            ErrorMode = error;
            FilePath = path;
            if (!error)
            {
                Initialize(path);
            }
        }
        public void WriteLine(string message)
        {
            if (ErrorMode && writer == null)
                Initialize(FilePath);

            writer.WriteLine(message);
        }
    }
}

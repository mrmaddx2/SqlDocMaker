using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public static class DocFactory
    {
        public static IDocUploader CreateDocUploader(string fullFileName)
        {
            switch (Path.GetExtension(fullFileName).ToLower())
            {
                case ".pdf":
                    return new PdfUploader(fullFileName);
                case ".docx":
                    return new DocxUploader(fullFileName);
                default: throw new Exception("Неизвестное расширение файла");
            }
        }
    }
}

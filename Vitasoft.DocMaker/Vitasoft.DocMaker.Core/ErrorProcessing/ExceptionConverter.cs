using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core.ErrorProcessing
{
    public class ExceptionConverter
    {
        public static string GetMessage(Exception exception)
        {
            string result = string.Empty;

            if (exception != null)
            {
                result += exception.Message;

                if (exception.InnerException != null)
                {
                    result += Environment.NewLine + ExceptionConverter.GetMessage(exception.InnerException);
                }
            }

            

            return result;
        }
    }
}

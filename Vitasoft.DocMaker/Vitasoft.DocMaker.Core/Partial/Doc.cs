using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    
    public partial class Doc
    {
        public static string DefaultSection = "Секция по умолчанию";

        
        public static Doc CreateNew(string docName = "", string docSection = "", string summary = "")
        {
            
            Doc result = new Doc();

            result.DocName = docName;
            result.DocSection = docSection;
            result.Summary = summary;

            result.Params = new DocParam[0];
            result.Output_Dataset = new DocOutput_Dataset();

            return result;
        }
        


    }
    
}

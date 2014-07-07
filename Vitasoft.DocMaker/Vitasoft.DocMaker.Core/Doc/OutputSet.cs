using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public class OutputSet
    {
        public List<OutputField> OutputFields { get; private set; }

        public OutputSet()
        {
            this.OutputFields = new List<OutputField>();
        }
    }
}

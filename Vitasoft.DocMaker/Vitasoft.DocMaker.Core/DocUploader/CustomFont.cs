using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public class CustomFont
    {
        public string Name { get; private set; }
        public float Size { get; private set; }
        public bool Bold { get; private set; }
        public int Alignment { get; private set; }

        public CustomFont(string fontName = "arial", float fontSize = 8, bool bold = false, int alignment = 0)
        {
            this.Name = fontName;
            this.Size = fontSize;
            this.Bold = bold;
            this.Alignment = alignment;
        }
    }
}

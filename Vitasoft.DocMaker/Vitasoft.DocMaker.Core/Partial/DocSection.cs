using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public class DocSection
    {
        public string Name { get; private set; }
        public int? Position { get; set; }

        public DocSection(string name, int? position = null)
        {
            Name = name;
            Position = position;
        }
    }

    public class DocSections : List<DocSection>, IComparable
    {
        public int CompareTo(object obj)
        {
            int result = 0;

            if (obj != null && obj is DocSections)
            {
                DocSections inputDocSections = obj as DocSections;

                int maxIndex = this.Count < inputDocSections.Count ? this.Count : inputDocSections.Count;

                for (int i = 0; i <= maxIndex - 1; i++)
                {
                    int thisIndex = this[i].Position == null || this[i].Position == 0 ? int.MaxValue : (int)this[i].Position;
                    int inputIndex = inputDocSections[i].Position == null || inputDocSections[i].Position == 0 ? int.MaxValue : (int)inputDocSections[i].Position;

                    if (thisIndex > inputIndex)
                    {
                        return thisIndex < 0 ? thisIndex * -1 : thisIndex;
                    }
                    else if (thisIndex < inputIndex)
                    {
                        return thisIndex > 0 ? thisIndex * -1 : thisIndex;
                    }
                }

                if (result == 0)
                {
                    result = string.Compare(string.Join(@"\", this.Select(x => x.Name)), string.Join(@"\", inputDocSections.Select(x => x.Name)), StringComparison.InvariantCultureIgnoreCase);
                }
            }
            else
            {
                throw new Exception("Невозможно сравнить тип " + obj.GetType().ToString() + " c DocSections");
            }         

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public class DocSection
    {
        private int _position;

        public string Name { get; private set; }
        public bool IsEmpty { get; private set; }

        public int Position
        {
            get { return this._position; }
            set { this._position = value == null || value == 0 ? int.MaxValue : (int) value; }
        }

        public DocSection(string name, int? position = null)
        {
            this.Name = name;
            this._position = position == null || position == 0 ? int.MaxValue : (int)position;
            this.IsEmpty = position == null ? true : false;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is DocSection)
            {
                DocSection tmpObj = obj as DocSection;

                if (tmpObj.Name == this.Name && tmpObj.Position == this.Position)
                {
                    return true;
                }
            }

            return false;
        }

        public DocSection CopySection()
        {
            return new DocSection(this.Name, this.Position);
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
                    int thisIndex = this[i].Position;
                    int inputIndex = inputDocSections[i].Position;

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

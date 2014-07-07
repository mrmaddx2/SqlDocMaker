using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core.SQLWorker
{
    public partial class SqlObjectParameter
    {
        public string FullDataType
        {
            get
            {
                string tmpDataType = (this.CHARACTER_MAXIMUM_LENGTH != null
                        ? (this.CHARACTER_MAXIMUM_LENGTH == -1
                            ? "MAX"
                            : this.CHARACTER_MAXIMUM_LENGTH.ToString())
                        : string.Empty) +
                                         (!this.DATA_TYPE.Contains("int")
                                             ? this.NUMERIC_PRECISION +
                                               (this.NUMERIC_SCALE > 0
                                                   ? ", " + this.NUMERIC_SCALE.ToString()
                                                   : string.Empty)
                                             : string.Empty);

                return this.DATA_TYPE +
                       (string.IsNullOrWhiteSpace(tmpDataType) ? string.Empty : "(" + tmpDataType + ")");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasoft.DocMaker.Core
{
    public partial class InputXmlArgumentsSqlConnectionProperties
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source="+this.ServerName+";Initial Catalog="+this.DatabaseName+";Integrated Security=" +
                       this.IntegratedSecurity.ToString() +
                       (!string.IsNullOrWhiteSpace(this.Login)
                           ? ";Persist Security Info=True;User ID="+this.Login+";Password=" + this.Password
                           : string.Empty);
            }
        }

        public bool IntegratedSecurity
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Login) ? true : false;
            }
        }
    }
}

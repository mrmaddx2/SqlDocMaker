using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Math;
using Vitasoft.DocMaker.Core.SQLWorker;

namespace Vitasoft.DocMaker.Core
{
    public class DocScalarFunction : DocFunction
    {
        public override OutputSet OutputDataSet
        {
            get { return null; }
            set { throw new NotImplementedException("Класс не поддерживает исходящие датасеты"); }
        }

        public SqlObjectParameter Result { get; private set; }

        public override string ReturnValueDataType
        {
            get { return this.Result!= null ? this.Result.FullDataType : string.Empty; }
        }

        public DocScalarFunction(SqlObject sqlObject, DbSchemaReader dbSchemaReader, Logger logger = null,
            Generated.SpdModelClasses.Model1 model = null)
            : base(sqlObject, dbSchemaReader, logger, model)
        {
            Result = this.Parameters.FirstOrDefault(x => x.IS_RESULT == "YES");

            if (Result != null)
            {
                this.Parameters.Remove(Result);
            }
        }

        public override object UploadToDoc(IDocUploader docUploader, string sectionName)
        {
            try
            {
                return base.UploadToDoc(docUploader, sectionName);
            }
            catch (Exception exception)
            {
                throw new Exception("Выгрузка в документ функции " + this.SqlObject.name, exception);
            }
        }
    }
}

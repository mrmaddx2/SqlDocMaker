using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitasoft.DocMaker.Core.SQLWorker;

namespace Vitasoft.DocMaker.Core
{
    public class DocTableValueFunction : DocFunction
    {
        public override OutputSet OutputDataSet { get; set; }

        public override string ReturnValueDataType
        {
            get { return this.OutputDataSet != null ? "table" : string.Empty; }
        }

        public DocTableValueFunction(SqlObject sqlObject, DbSchemaReader dbSchemaReader, Logger logger = null,
            Generated.SpdModelClasses.Model1 model = null)
            : base(sqlObject, dbSchemaReader, logger, model)
        {
            this.OutputDataSet = dbSchemaReader.GetOutputDataSetsByMetadata(this);

            if (this.OutputDataSet == null)
            {
                this.OutputDataSet = new OutputSet();
            }
            else
            {
                this.FillDocDataSets(model);
            }
        }

        public override object UploadToDoc(IDocUploader docUploader, string sectionName)
        {
            try
            {
                var insertAfter = base.UploadToDoc(docUploader, sectionName);

                object datasetObject = null;

                if (this.OutputDataSet.OutputFields.Count > 0)
                {
                    datasetObject = docUploader.AddReturnDatasetInfo(insertAfter, this, Color.Gainsboro, Color.Transparent);
                }

                if (datasetObject != null)
                {
                    return datasetObject;
                }
                else
                {
                    return insertAfter;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Выгрузка в документ функции " + this.SqlObject.name, exception);
            }
        }
    }
}

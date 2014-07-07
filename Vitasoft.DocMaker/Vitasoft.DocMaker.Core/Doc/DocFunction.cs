using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitasoft.DocMaker.Core.SQLWorker;
using Spd = Vitasoft.DocMaker.Core.Generated.SpdModelClasses;

namespace Vitasoft.DocMaker.Core
{
    public class DocFunction : DocObject
    {
        public SqlObjectParameter Result { get; private set; }

        public DocFunction(SqlObject sqlObject, DbSchemaReader dbSchemaReader, Logger logger = null,
            Spd.Model1 model = null)
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
                var insertAfter = base.UploadToDoc(docUploader, sectionName);

                var resultObject = insertAfter;

                if (this.Result != null)
                {
                    resultObject = docUploader.AddReturnValueInfo(insertAfter, this, Color.Transparent);
                }

                if (resultObject != null)
                {
                    return resultObject;
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

        public override List<DocSections> SectionsList
        {
            get
            {
                var result = base.SectionsList;
                /*
                foreach (var currentList in result)
                {
                    currentList.Insert(0, new DocSection("Функции", 2));
                }
                */
                return result;
            }
        }

        public string ResultComment
        {
            get
            {
                return this.Doc != null
                    ? (string.IsNullOrWhiteSpace(this.Doc.FunctionResultComment)
                        ? string.Empty
                        : this.Doc.FunctionResultComment)
                    : string.Empty;
            }
        }
    }
}

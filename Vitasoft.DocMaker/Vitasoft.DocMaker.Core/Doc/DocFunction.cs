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
    public abstract class DocFunction : DocObject
    {
        public abstract string ReturnValueDataType {get;}

        public DocFunction(SqlObject sqlObject, DbSchemaReader dbSchemaReader, Logger logger = null,
            Spd.Model1 model = null)
            : base(sqlObject, dbSchemaReader, logger, model)
        {

        }

        public override object UploadToDoc(IDocUploader docUploader, string sectionName)
        {
            try
            {
                var insertAfter = base.UploadToDoc(docUploader, sectionName);

                var resultObject = insertAfter;

                resultObject = docUploader.AddReturnValueInfo(insertAfter, this, Color.Transparent);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.Excel;
using Vitasoft.DocMaker.Core.ErrorProcessing;
using Vitasoft.DocMaker.Core.SQLWorker;
using Color = System.Drawing.Color;
using Spd = Vitasoft.DocMaker.Core.Generated.SpdModelClasses;

namespace Vitasoft.DocMaker.Core
{
    public class DocProcedure : DocObject
    {
        public override OutputSet OutputDataSet { get; set; }

        public DocProcedure(SqlObject sqlObject, DbSchemaReader dbSchemaReader, Logger logger = null, Spd.Model1 model = null, bool getOutputDataSetsByExec = false)
            : base(sqlObject, dbSchemaReader, logger, model)
        {

            var searchArea = (this.Doc != null && this.Doc.Output_Dataset != null) ? this.Doc.Output_Dataset.SearcArea : SearcAreaEnum.AUTO;

            if (searchArea == SearcAreaEnum.AUTO)
            {
                try
                {
                    this.OutputDataSet = dbSchemaReader.GetOutputDataSetsByMetadata(this);
                }
                catch (Exception exception)
                {
                    try
                    {
                        if (getOutputDataSetsByExec)
                        {
                            this.OutputDataSet = dbSchemaReader.GetOutputDataSetsByExec(this);
                        }
                        else
                        {
                            throw new Exception("Получение исходящего датасета выполнением процедуры запрещено параметрами!");
                        }
                    }
                    catch (Exception execException)
                    {
                        if (GetOutputDatasetInfoFromDoc())
                        {
                            if (this._logger != null)
                            {
                                this._logger.WriteWarning(ExceptionConverter.GetMessage(execException), true);
                                this._logger.WriteWarning(ExceptionConverter.GetMessage(new Exception("Описание датасета взято из документации", exception)), true);
                            }
                        }
                        else
                        {
                            Exception tmpException = new Exception("Невозможно изъять откуда либо информацию об исходящих датасетах объекта.", exception);

                            if (this._logger == null)
                            {
                                throw tmpException;
                            }
                            else
                            {
                                this._logger.LogError(ExceptionConverter.GetMessage(execException), true);
                                this._logger.LogError(ExceptionConverter.GetMessage(tmpException), true);
                            }
                        }
                    }


                }
            }
            else if (searchArea == SearcAreaEnum.DOCONLY)
            {
                if (!GetOutputDatasetInfoFromDoc())
                {
                    if (this._logger != null)
                    {
                        this._logger.WriteWarning("Указано получение информации о датасете из документации, но извлечь ее оттуда не удалось.", true);
                    }
                }
            }
            else if (searchArea == SearcAreaEnum.NONE)
            {
                if (this._logger != null)
                {
                    this._logger.WriteLine("Получение информации об исходящем датасете отключено настройками.", true);
                }
            }


            if (this.OutputDataSet == null)
            {
                this.OutputDataSet = new OutputSet();
            }
            else
            {
                this.FillDocDataSets(model);
            }


            if (this._logger != null)
            {
                string nonComments = string.Join(Environment.NewLine,
                    this.Doc.Output_Dataset.Fields.Where(x => string.IsNullOrWhiteSpace(x.Comment)).Select(x => x.Name));

                if (!string.IsNullOrWhiteSpace(nonComments))
                {
                    this._logger.WriteWarning(this.SqlObject.name + ": Не найдены комментарии для исходящих полей " + nonComments);
                }
            }
        }


        public bool GetOutputDatasetInfoFromDoc()
        {
            bool result = false;

            if (this.Doc != null && this.Doc.Output_Dataset != null && this.Doc.Output_Dataset.Fields.Count() > 0)
            {
                this.OutputDataSet = new OutputSet();

                OutputDataSet.OutputFields.AddRange(this.Doc.Output_Dataset.Fields.Select(x => new OutputField(x.Name, x.DataTypeName)));

                result = true;
            }

            return result;
        }

        public override List<DocSections> SectionsList
        {
            get
            {
                var result = base.SectionsList;
                /*
                foreach (var currentList in result)
                {
                    currentList.Insert(0, new DocSection("Процедуры", 1));
                }
                */
                return result;
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
                throw new Exception("Выгрузка в документ процедуры " + this.SqlObject.name, exception);
            }
        }
    }
}

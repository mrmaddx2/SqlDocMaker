using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Vitasoft.DocMaker.Core;
using Vitasoft.DocMaker.Core.ErrorProcessing;
using Vitasoft.DocMaker.Core.SQLWorker;
using Spd = Vitasoft.DocMaker.Core.Generated.SpdModelClasses;

namespace Vitasoft.DocMaker.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InputXmlArguments xmlArguments = null;
            Logger logger = null;

            #region Получение значений аргументов

            //дессериализуем аргументы программы из xml
            try
            {
                if (File.Exists("InputXmlArguments.xml"))
                {
                    using (FileStream reader = new FileStream("InputXmlArguments.xml", FileMode.Open))
                    {
                        XmlSerializer _xmlSerializer = new XmlSerializer(typeof(InputXmlArguments));

                        xmlArguments = (InputXmlArguments)_xmlSerializer.Deserialize(reader);
                    }
                }
                else
                {
                    throw new Exception("Не найден файл со значениями аргументов");
                }

                logger = new Logger(xmlArguments.LogFileName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadLine();
                return;
            }

            #endregion

            try
            {
                #region Подключение модели
                //Для получения комментариев подключаем модель Sybase PowerDesigner
                //Классы получены через программу xsd.exe и используются без каких либо изменений

                Spd.Model1 model = null;

                if (!string.IsNullOrWhiteSpace(xmlArguments.SpdModelPath))
                {
                    if (File.Exists(xmlArguments.SpdModelPath))
                    {
                        logger.WriteLine("Подключаем модель для получения комментариев", true);

                        using (FileStream reader = File.OpenRead(xmlArguments.SpdModelPath))
                        {
                            XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Spd.Model));

                            Spd.Model mainModel = (Spd.Model)_xmlSerializer.Deserialize(reader);

                            model = mainModel.RootObject.Children.Model;
                        }
                    }
                    else
                    {
                        throw new Exception("По указанному пути модель не найдена! Путь: " + Environment.NewLine + Path.GetFullPath(xmlArguments.SpdModelPath));
                    }
                }
                #endregion

                #region Получение коллекции экземпляров всех документируемых объектов

                //Коллекция документируемых процедур
                List<DocProcedure> procedures = null;
                //Коллекция документируемых функций
                List<DocFunction> functions = null;

                using (SqlConnection connection = new SqlConnection(xmlArguments.SqlConnectionProperties.ConnectionString))
                {
                    connection.Open();
                    
                    using (DbSchemaReader dbSchemaReader = new DbSchemaReader(connection))
                    {
                        #region Составление списка имен документируемых объектов
                        
                        List<string> sqlObjectsList = null;

                        //Если файл по указанному в аргументах пути существует, то загружаем список документируемых объектов из него.
                        if (File.Exists(xmlArguments.SqlObjectsList))
                        {
                            sqlObjectsList = File.ReadAllLines(xmlArguments.SqlObjectsList).ToList();
                        }
                        else
                        {
                            //Если же файла не существует - расцениваем строку как шаблон регулярного выражения. 
                            //Составляем список из существующих в базе объектов. имена которых подходят под шаблон.
                            sqlObjectsList =
                                dbSchemaReader.GetObjects()
                                    .ToList()
                                    .Where(
                                        x => Regex.IsMatch(x.name, xmlArguments.SqlObjectsList, RegexOptions.IgnoreCase))
                                    .Select(x => x.name)
                                    .ToList();
                        }
                        #endregion

                        #region Составление списка имен ислючаемых из документирования объектов
                        List<string> ExcludedSqlObjectsList = null;

                        //Если файл по указанному в аргументах пути существует, то загружаем список исключаемых объектов из него.
                        if (File.Exists(xmlArguments.ExcludedSqlObjectsList))
                        {
                            ExcludedSqlObjectsList = File.ReadAllLines(xmlArguments.ExcludedSqlObjectsList).ToList();
                        }
                        else if (!string.IsNullOrWhiteSpace(xmlArguments.ExcludedSqlObjectsList))
                        {
                            //Если же файла не существует - расцениваем строку как шаблон регулярного выражения. 
                            //Составляем список из существующих в базе объектов. имена которых подходят под шаблон.
                            ExcludedSqlObjectsList =
                                dbSchemaReader.GetObjects()
                                    .ToList()
                                    .Where(
                                        x => Regex.IsMatch(x.name, xmlArguments.ExcludedSqlObjectsList, RegexOptions.IgnoreCase))
                                    .Select(x => x.name)
                                    .ToList();
                        }
                        else
                        {
                            ExcludedSqlObjectsList = new List<string>();
                        }
                        #endregion

                        #region Составление окончательного списка имен документируемых объектов
                        //Удаляем объекты, имена которых указаны в списке исключеинй из списка документируемых объектов.
                        sqlObjectsList =
                            sqlObjectsList.Where(
                                x =>
                                    !ExcludedSqlObjectsList.Any(
                                        y => string.Equals(x, y, StringComparison.InvariantCultureIgnoreCase))).ToList();
                        #endregion

                        #region Получение экземпляров документируемых объектов

                        logger.WriteLine("Начинаем анализ процедур", true);

                        procedures =
                            dbSchemaReader.GetProcedures(proceduresList: sqlObjectsList, logger: logger, model: model,
                                getOutputDatasetsByExec: xmlArguments.GetOutputDatasetsByExec);                        

                        logger.WriteLine("Анализ процедур завершен", true);

                        logger.WriteLine("Начинаем анализ функций", true);

                        functions =
                            dbSchemaReader.GetFunctions(functionsList: sqlObjectsList, logger: logger, model: model);

                        logger.WriteLine("Анализ функций завершен", true);

                        #endregion
                    }
                }

                //Коллекция всех документируемых объектов
                List<DocObject> sqlObjects = new List<DocObject>();
                sqlObjects.AddRange(procedures);
                sqlObjects.AddRange(functions);

                #endregion


                #region Формирование документов
                if (sqlObjects.Count > 0)
                {
                    logger.WriteLine("Формирование документов", true);
                    
                    //Список без повторений имен файлов
                    List<string> distinctDocNames =
                        sqlObjects.Select(
                            x =>
                                x.GetFileName(xmlArguments)).Distinct().ToList();

                    foreach (string docName in distinctDocNames)
                    {
                        logger.WriteLine("Сортировка заголовков файла " + docName, true);
                        #region Сортировка списка SQL объектов

                        #region Наполнение списков

                        //Затычка для создания пустого списка экземпляров анонимного класса
                        //Используется для хранения в отсортированном виде sql объектов
                        var sortSqlObjects =
                               sqlObjects.Where(x => false)
                                   .Select(x => new { docObject = x, sections = new DocSections() }).ToList();

                        //Затычка для создания пустого списка экземпляров анонимного класса
                        //Используется для замены и расстановки приоритетов следования заголовков.
                        var minRankSections =
                            sqlObjects.Where(x => false)
                                .Select(x => new { section = new DocSection(string.Empty), sectionIndex = (int)0 }).ToList();

                        List<DocObject> ObjectsInCurrentDoc = sqlObjects.Where(x => x.GetFileName(xmlArguments) == docName).ToList();

                        //Все SQL располагаемые в текущем файле
                        foreach (DocObject docObject in ObjectsInCurrentDoc)
                        {
                            //Пробегаемся по всем указанным секциям, разделяемым |
                            foreach (DocSections currentSections in docObject.SectionsList)
                            {
                                //По всем уровням секций, разделяемым \ или /
                                foreach (DocSection currentSection in currentSections)
                                {
                                    var sameSection = minRankSections.Where(x => x.section.Name == currentSection.Name && x.sectionIndex == currentSections.IndexOf(currentSection)).FirstOrDefault();

                                    if (sameSection != null)
                                    {
                                        if (sameSection.section.Position > currentSection.Position)
                                        {
                                            sameSection.section.Position = currentSection.Position;
                                        }
                                    }
                                    else
                                    {
                                        minRankSections.Add(
                                            new
                                            {
                                                section = currentSection.CopySection(),
                                                sectionIndex = currentSections.IndexOf(currentSection)
                                            });
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Расстановка или замена приоритетов следования у заголовков, имеющих расхождения в заданных человеком значениях

                        string infoText = string.Empty;
                        string warningText = string.Empty;

                        foreach (DocObject docObject in ObjectsInCurrentDoc)
                        {
                            string tmpInfoText = string.Empty;
                            string tmpWarningText = string.Empty;

                            //Пробегаемся по всем указанным секциям, разделяемым |
                            foreach (DocSections currentSections in docObject.SectionsList)
                            {
                                //По всем уровням секций, разделяемым \ или /
                                foreach (DocSection currentSection in currentSections)
                                {
                                    var sameSection = minRankSections.Where(x => x.section.Name == currentSection.Name && x.sectionIndex == currentSections.IndexOf(currentSection)).First();

                                    if (currentSection.Position != sameSection.section.Position)
                                    {
                                        if (currentSection.IsEmpty)
                                        {
                                            tmpInfoText += "    " + currentSection.Name + ": " + sameSection.section.Position.ToString() + Environment.NewLine;
                                        }
                                        else
                                        {
                                            tmpWarningText += "    " + currentSection.Name + ": " +
                                                   currentSection.Position.ToString() + " --> " +
                                                   sameSection.section.Position.ToString() + Environment.NewLine;
                                        }

                                        currentSection.Position = sameSection.section.Position;
                                    }
                                }

                                sortSqlObjects.Add(new { docObject = docObject, sections = currentSections });

                                infoText += !string.IsNullOrWhiteSpace(tmpInfoText) ? docObject.SqlObject.name + Environment.NewLine + tmpInfoText : tmpInfoText;
                                warningText += !string.IsNullOrWhiteSpace(tmpWarningText) ? docObject.SqlObject.name + Environment.NewLine + tmpWarningText : tmpWarningText;
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(infoText))
                        {
                            infoText = "Расставляем приоритеты сортировки заголовков в объектах "  +
                                   Environment.NewLine + infoText;
                            logger.WriteLine(infoText);
                        }

                        if (!string.IsNullOrWhiteSpace(warningText))
                        {
                            warningText = "Заменяем приоритеты сортировки заголовков в объектах " +
                                   Environment.NewLine + warningText;
                            logger.WriteWarning(warningText);
                        }
                        
                        #endregion


                        sortSqlObjects = sortSqlObjects.OrderBy(x => x.sections).ToList();
                        #endregion

                        logger.WriteLine("Запись в файл " + docName, true);
                        //Выгружаем во все указанные форматы
                        foreach (string outputFileExtension in xmlArguments.OutputFileTypes.Split(Convert.ToChar("|")).ToList())
                        {
                            string tmpFileName = xmlArguments.OutputFolderOrDefault + @"\" + docName + "." + outputFileExtension;

                            //Если файл существует, значит все необходимое древо каталогов так же существует - просто удаляем файл.
                            if (File.Exists(tmpFileName))
                            {
                                File.Delete(tmpFileName);
                            }
                            //Создаем древо каталогов
                            else 
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(tmpFileName));
                            }

                            //Создаем файл для выгрузки
                            using (IDocUploader docUploader = DocFactory.CreateDocUploader(tmpFileName))
                            {
                                //Наполняем документ
                                foreach (var sortObject in sortSqlObjects)
                                {
                                    try
                                    {
                                        sortObject.docObject.UploadToDoc(docUploader, string.Join(@"\", sortObject.sections.Select(x => x.Name)));
                                    }
                                    catch (Exception exception)
                                    {
                                        Exception tmpException = new Exception("Наполнение документа " + tmpFileName, exception);
                                        logger.LogError(ExceptionConverter.GetMessage(tmpException), true);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                if (xmlArguments.OpenAfterOutputFolder)
                {
                    Process.Start(xmlArguments.OutputFolderOrDefault);
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);
            }

            logger.WriteLine("Все операции выполенены", true);

            
            

            Console.WriteLine("Press any key for exit");

            #region В случае Debug конфигурации или если указано аргуменатми - не завершаем выполнение до ввода эникея

            if (xmlArguments.NoExit)
            {
                Console.ReadLine();
            }
            else
            {
                #if DEBUG
                    Console.ReadLine();
                #endif
            }

            #endregion
        }

    }
}

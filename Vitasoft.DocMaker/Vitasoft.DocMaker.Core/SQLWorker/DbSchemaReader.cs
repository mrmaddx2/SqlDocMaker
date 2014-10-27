using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text.RegularExpressions;
using Vitasoft.DocMaker.Core.ErrorProcessing;
using Spd = Vitasoft.DocMaker.Core.Generated.SpdModelClasses;

namespace Vitasoft.DocMaker.Core.SQLWorker
{
    public class DbSchemaReader : IDisposable
    {
        SQLDictionariesDataContext Context;

        public DbSchemaReader(SqlConnection connection)
        {
            Context = new SQLDictionariesDataContext(connection);
        }

        public List<DocFunction> GetFunctions(List<string> functionsList, Logger logger = null, Spd.Model1 model = null)
        {
            //throw new Exception(string.Join(Environment.NewLine, GetObjects(new[] { "FN", "IF", "TF" }).ToList().Select(x => x.name)));

            List<DocFunction> functions = new List<DocFunction>();

            int currentProc = 1;
            var functionObjects =
                GetObjects(new[] { "FN", "IF", "TF" })
                    .ToList()
                    .Where(
                        x =>
                            functionsList == null ||
                            functionsList.Any(
                                y => string.Equals(x.name, y, StringComparison.InvariantCultureIgnoreCase)));
            int allFunc = functionObjects.Count();

            foreach (SqlObject sqlObject in functionObjects)
            {
                try
                {
                    if (logger != null)
                    {
                        logger.WriteLine(currentProc.ToString() + @"/" + allFunc.ToString() + "  " + sqlObject.name, true);
                    }

                    switch (sqlObject.type.ToUpper())
                    {
                        case "FN" :
                            functions.Add(new DocScalarFunction(sqlObject, this, logger, model));
                            break;
                        case "IF" :
                            functions.Add(new DocTableValueFunction(sqlObject, this, logger, model));
                            break;
                        case "TF": 
                            goto case "IF";
                        default: throw new Exception("Не известный тип функции: " + sqlObject.type);
                    }
                }
                catch (Exception exception)
                {
                    if (logger != null)
                    {
                        logger.LogError(ExceptionConverter.GetMessage(exception), true);
                    }
                }

                currentProc++;
            }

            return functions;
        }

        public IQueryable<SqlObject> GetObjects(string[] types = null)
        {
            if (types == null)
            {
                types = new string[0];
            }

            return
                Context.SqlObjects.Where(
                    x =>
                        (!types.Any() || types.Contains(x.type)));
        }

        public List<DocProcedure> GetProcedures(List<string> proceduresList = null, Logger logger = null, Spd.Model1 model = null, bool getOutputDatasetsByExec = false)
        {
            List<DocProcedure> procedures = new List<DocProcedure>();

            int currentProc = 1;
            var procedureObjects =
                GetObjects(types: new[] {"P"})
                    .ToList()
                    .Where(
                        x =>
                            proceduresList == null ||
                            proceduresList.Any(
                                y => string.Equals(x.name, y, StringComparison.InvariantCultureIgnoreCase)));
            int allProc = procedureObjects.Count();

            foreach (SqlObject sqlObject in procedureObjects)
            {
                try
                {
                    if (logger != null)
                    {
                        logger.WriteLine(currentProc.ToString() + @"/" + allProc.ToString() + "  " + sqlObject.name, true);
                    }

                    procedures.Add(new DocProcedure(sqlObject, this, logger, model, getOutputDatasetsByExec));
                }
                catch (Exception exception)
                {
                    if (logger != null)
                    {
                        logger.LogError(ExceptionConverter.GetMessage(exception), true);
                    }
                } 

                currentProc++;
            }

            return procedures;
        }

        public List<SqlObjectParameter> GetParameters(string objectName)
        {
            return Context.SqlObjectParameters.Where(
                x => x.SPECIFIC_NAME == objectName).ToList();
        }

        public OutputSet GetOutputDataSetsByExec(DocProcedure docObject)
        {
            OutputSet result = null;

            if (this.Context.Connection is SqlConnection)
            {
                SqlConnection connection = (Context.Connection as SqlConnection);

                try
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;

                        string tmpParams =
                            string.Join(Environment.NewLine, docObject.Parameters.Select(
                                param =>
                                    "DECLARE " + param.PARAMETER_NAME + " " + param.FullDataType + " = " +
                                    docObject.GetParamValue(param)
                                ).ToList());

                        command.CommandText = tmpParams + Environment.NewLine +
                                              "EXEC " + docObject.SqlObject.name + " " +
                                              string.Join(", ",
                                                  docObject.Parameters.Select(
                                                      x =>
                                                          x.PARAMETER_NAME + " = " + x.PARAMETER_NAME).ToList());

                        {
                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    result = new OutputSet();
                                    int fieldCount = reader.FieldCount;

                                    for (int i = 0; i <= fieldCount - 1; i++)
                                    {
                                        result.OutputFields.Add(new OutputField(Convert.ToString(reader.GetName(i)), Convert.ToString(reader.GetDataTypeName(i))));
                                    }

                                    reader.Close();
                                }
                            }
                            catch (Exception exception)
                            {
                                throw new Exception(command.CommandText, exception);
                            }
                            
                        }
                    }
                }
                catch (Exception mainException)
                {
                    throw new Exception(
                            "Ошибка получения исходящего датасета! Объект:" + docObject.SqlObject.name, mainException);
                }
            }

            return result;
        }

        private OutputSet GetOutputDataSetsByMetadata(string queryString)
        {
            OutputSet result = null;

            if (this.Context.Connection is SqlConnection)
            {
                SqlConnection connection = (Context.Connection as SqlConnection);

                using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = queryString;

                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    result = new OutputSet();

                                    while (reader.Read())
                                    {
                                        if (!Convert.ToBoolean(reader["is_hidden"]))
                                        {
                                            result.OutputFields.Add(new OutputField(
                                                Convert.ToString(reader["name"]),
                                                Convert.ToString(reader["system_type_name"]),
                                                Convert.ToString(reader["source_table"]),
                                                Convert.ToString(reader["source_column"])));
                                        }
                                    }
                                }

                                reader.Close();
                            }
                        }
                    }
            }

            return result;
        }

        public OutputSet GetOutputDataSetsByMetadata(DocObject docObject)
        {
            OutputSet result = null;

            try
            {
                string objectName = docObject.SqlObject.name;

                if (docObject is DocProcedure)
                {
                    result = GetOutputDataSetsByMetadata("EXEC sp_describe_first_result_set N'" + objectName + "', null, 2");
                }
                else if(docObject is DocTableValueFunction)
                {
                    result = GetOutputDataSetsByMetadata("EXEC sp_describe_first_result_set N'SELECT * FROM " + objectName + "(" + string.Join(", ", docObject.Parameters.Select(x => "null")) + ")', null, 1");
                }
                else
                {
                    throw new Exception("Получение исходящего датасета не разрешено для переданного типа объекта!");
                }

                return result;
            }
            catch (Exception mainException)
            {
                throw new Exception(
                        docObject.SqlObject.name + " - Ошибка получения исходящего датасета!", mainException);
            }
        }

        public string GetObjectDefinition(string objectName, Logger logger = null)
        {
            string result = string.Empty;

            try
            {
                if (Context.SqlObjects.Any(x => x.name == objectName))
                {
                    if (Context.Connection is SqlConnection)
                    {
                        SqlConnection connection = (Context.Connection as SqlConnection);

                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = "SELECT OBJECT_DEFINITION(OBJECT_ID('" + objectName + "')) AS GetObjectDefinition";

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        result += Convert.ToString(reader["GetObjectDefinition"]);
                                    }
                                }

                                reader.Close();
                            }
                        }

                    }
                    else
                    {
                        throw new SqlTypeException("Тип соединения не соответствет ожидаемому! " + Context.Connection.GetType());
                    }
                }
                else
                {
                    throw new Exception("Указанного объекта не существет: " + objectName);
                }
            }
            catch (Exception exception)
            {
                Exception newException = new Exception(objectName, exception);

                if (logger == null)
                {
                    throw newException;
                }
                else
                {
                    logger.LogError(ExceptionConverter.GetMessage(newException));
                }
            }

            return result;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

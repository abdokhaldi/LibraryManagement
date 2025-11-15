using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccess
{
    internal class SqlDataHelper
    {

      public enum enExecuteType
        {
           ExecuteScalar =1,
           ExecuteNonQuery=2,
           ExecuteDataReaderList=3,
           ExecuteDataReaderSingleRowAsDictionary=4,
           ExecuteDataReaderTable = 5,
        }

       public static string connectionString = "Server=.;Database=DVLD_v2;User id=sa;Password=sa123456";

        public static object ExecuteCommand(string query, CommandType commandType, Dictionary<string, object> parameters, enExecuteType executeType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = commandType;

                    // Add parameters 
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            //  SqlParameter sqlParam = new SqlParameter(param.Key, param.Value);
                            //  sqlParam.Value = param.Value;
                            //  command.Parameters.Add(sqlParam);
                        }
                    }

                    try
                    {
                        connection.Open();

                        switch (executeType)
                        {
                            case enExecuteType.ExecuteScalar:
                                {
                                    return command.ExecuteScalar();
                                }
                            case enExecuteType.ExecuteDataReaderList:
                                {

                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

                                        while (reader.Read())
                                        {
                                            Dictionary<string, object> row = new Dictionary<string, object>();
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                row.Add(reader.GetName(i), reader.GetValue(i));
                                            }
                                            result.Add(row);
                                        }
                                        return result;
                                    }
                                }
                            case enExecuteType.ExecuteDataReaderTable:
                                {
                                    DataTable dt = new DataTable();
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            dt.Load(reader);
                                        }
                                    }
                                    return dt;
                                }
                            case enExecuteType.ExecuteDataReaderSingleRowAsDictionary:
                                {
                                    Dictionary<string, object> row = new Dictionary<string, object>();
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                row.Add(reader.GetName(i), reader.GetValue(i));
                                            }
                                        }
                                        else
                                        {
                                            row = null;
                                        }

                                    }
                                    return row;
                                }
                            case enExecuteType.ExecuteNonQuery:
                                {
                                    return command.ExecuteNonQuery();
                                }
                            default:
                                throw new InvalidOperationException("Invalid execution type provided!");
                        }
                    }
                    catch (Exception ex)
                    {
                        return "Error : " + ex.Message;
                    }
                }
            }

        }





    public static object ExecuteCommand(string query, CommandType commandType,Dictionary<string,object> parameters,string executeType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {  
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.CommandType = commandType;

                    // Add parameters 
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                           command.Parameters.AddWithValue(param.Key, param.Value?? DBNull.Value);
                          //  SqlParameter sqlParam = new SqlParameter(param.Key, param.Value);
                          //  sqlParam.Value = param.Value;
                          //  command.Parameters.Add(sqlParam);
                        }
                    }

                    try
                    {
                        connection.Open();

                        switch (executeType)
                        {
                            case "ExecuteScalar":
                                {
                                    return command.ExecuteScalar();
                                }
                            case "ExecuteReader":
                                {
                                    
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
                                        
                                        while (reader.Read())
                                        {
                                            Dictionary<string, object> row = new Dictionary<string, object>();
                                            for (int i=0;i<reader.FieldCount;i++)
                                            {
                                                row.Add(reader.GetName(i),reader.GetValue(i));
                                            }
                                            result.Add(row);
                                        }
                                        return result;
                                    }
                                }
                            case "ExecuteReaderDataTable":
                                {
                                    DataTable dt = new DataTable();
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            dt.Load(reader);
                                        }
                                    }
                                    return dt;
                                }
                            case "ExecuteReaderSingleRow":
                                {
                                    Dictionary<string, object> row = new Dictionary<string, object>();
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            for (int i=0;i<reader.FieldCount;i++)
                                            {
                                                row.Add(reader.GetName(i),reader.GetValue(i));
                                            }
                                        }
                                        
                                    }
                                    return row;
                                }
                            case "ExecuteNonQuery":
                                {
                                    return command.ExecuteNonQuery();
                                }
                            default:
                                throw new InvalidOperationException("Invalid execution type provided!");
                        }
                    }
                    catch (Exception ex)
                    {
                        return "Error : " + ex.Message;
                    }  
                }
            }
            
        }
   
    public static object  ExecuteFindCommand(string query, CommandType commandType, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection)) {
                    command.CommandType = commandType;

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {

                            if (param.Value is int)
                            {
                                command.Parameters.AddWithValue(param.Key, (int)param.Value);
                            } else if (param.Value is string) {
                                command.Parameters.AddWithValue(param.Key, (string)param.Value);
                            } else
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value?? DBNull.Value);
                            }

                        }
                    }
              try
                    {
                  connection.Open();
                  using (SqlDataReader reader = command.ExecuteReader())
                    {
                  if (reader.Read()) 
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader.GetName(i), reader.GetValue(i));
                        }
                            return row;
                    }
                    
                 }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine( "Error :" + ex.Message) ;
                    }
                    
               }
                return null;
            }
       }

        public static int ExecuteCommandForTransaction(string query,SqlConnection connection,CommandType commandType,SqlTransaction transaction, Dictionary<string, object> parameters, enExecuteType executeType)
        {
            int result = 0;
            using (var command = new SqlCommand(query,connection,transaction)) {
                command.CommandType = commandType;
                // add parameters
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }

                // executeType
             switch (executeType)
                {

                    case enExecuteType.ExecuteScalar:
                        {
                            result = Convert.ToInt32(command.ExecuteScalar());
                            break;
                        }
                    case enExecuteType.ExecuteNonQuery:
                        {
                            result = command.ExecuteNonQuery();
                            break;
                        }
                }
            }
            return result;
        }



    }
}



using DTO_LibraryManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_LibraryManagement
{
    static public class SqlHelper
    {
        public enum ExecuteType {ExecuteNonQuery,ExecuteScalar ,ExecuteMultiRowsReader}

       public static readonly string connectionString = "Server=.;Database=LibraryManagement_2;User id=sa;Password=sa123456";
       
        public static SqlDataReader ExecuteReader(string query, CommandType commandType,Dictionary<string,(SqlDbType,object,int?)> parameters=null)
        {
           var conn = new SqlConnection(connectionString);
               conn.Open();
           var cmd = new SqlCommand(query,conn);
               cmd.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                   var param = cmd.Parameters.Add(p.Key,p.Value.Item1);
                    if (p.Value.Item3.HasValue)
                    {
                        param.Size = p.Value.Item3.Value;
                    }
                    param.Value = p.Value.Item2;
                }
            }
           
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static SqlDataReader ExecuteReaderWildCard(string query, CommandType commandType, Dictionary<string, (SqlDbType, object, int?)> parameters)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand(query, conn);
            cmd.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    var param = cmd.Parameters.Add(p.Key, p.Value.Item1);
                    if (p.Value.Item3.HasValue)
                    {
                        param.Size = p.Value.Item3.Value;
                    }
                    param.Value = "%" +p.Value.Item2+"%";
                }
            }

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static object ExecuteCommand(string query,CommandType commandType, ExecuteType executeType,Dictionary<string,(SqlDbType,object,int?)> parameters)
        {
            object returnedValue = null;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var comm = new SqlCommand(query, conn))
                    {
                        comm.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var para in parameters)
                            {
                                var value = para.Value.Item2 ?? DBNull.Value;
                                var param = comm.Parameters.Add(para.Key,para.Value.Item1);
                               
                                if (para.Value.Item3.HasValue)
                                    param.Size = para.Value.Item3.Value;

                                param.Value = value;
                            }
                        }


                        switch (executeType)
                        {
                            case ExecuteType.ExecuteScalar:
                                returnedValue = comm.ExecuteScalar();
                                break;
                            case ExecuteType.ExecuteNonQuery:
                                returnedValue = comm.ExecuteNonQuery();
                                break;
                             default:
                                throw new ArgumentOutOfRangeException(nameof(ExecuteType), executeType, "Invalid Execute Type Passed To Execute Command .");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error:{ex.Message}");
            }
            return returnedValue;
        }


        public static OperationResultBLL ExecuteTransaction(List<(string query, Dictionary<string, (SqlDbType, object, int?)> parameters, bool returnsValue)> commands)
        {
            var result = new OperationResultBLL();
            object returnedValue = null;

            using var conn = new SqlConnection(connectionString);

            conn.Open();
            using var transaction = conn.BeginTransaction();

            try
            {
                foreach (var cmd in commands)
                {

                    using var comm = new SqlCommand(cmd.query, conn, transaction);
                    comm.CommandType = CommandType.Text;

                    if (cmd.parameters != null)
                    {

                        foreach (var p in cmd.parameters)
                        {
                            var param = comm.Parameters.Add(p.Key, p.Value.Item1);
                            if (p.Value.Item3.HasValue)
                            {
                                param.Size = p.Value.Item3.Value;
                            }
                            param.Value = p.Value.Item2;
                        }
                        
                    }
                    if (cmd.returnsValue)
                    {
                        returnedValue = comm.ExecuteScalar();
                    }
                    comm.ExecuteNonQuery();
                }
                transaction.Commit();
                result.Success = true;
                result.ReturnedValue = returnedValue;
               
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                result.Success = false;
                result.Message = ex.Message;
                
            }
            return result;
        }

    }

}

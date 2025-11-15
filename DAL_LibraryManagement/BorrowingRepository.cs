using DTO_LibraryManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL_LibraryManagement
{
    public class BorrowingRepository
    {

        public static object IsActiveBorrowing(int bookID,int memberID)
        {
            string query = @"SELECT 1 FROM Borrowings WHERE 
                           BookID=@bookID AND MemberID=@MemberID AND ReturnDate IS NULL;";
          
            var parameters = new Dictionary<string, (SqlDbType, object,int?)>()
            {
                ["@bookID"] = (SqlDbType.Int,bookID,null),
                ["@memberID"] = (SqlDbType.Int, memberID,null)
            };

            object result = SqlHelper.ExecuteCommand(query,CommandType.Text,SqlHelper.ExecuteType.ExecuteScalar,parameters);
            return result;
        }

        public static int AddBorrowingAndUpdateBook(BorrowingDTO borrowingData)
        {
            int borrowingID = 0;
            var commands = new List<(string,Dictionary<string,(SqlDbType,object,int?)>,bool)>();

            string query1 = @"INSERT INTO Borrowings(BookID,MemberID,BorrowingDate,DueDate,ReturnDate,Status)
                          VALUES(@bookID,@memberID,@borrowingData,@dueDate,@returnDate,@status);
                          SELECT CAST(SCOPE_IDENTITY() AS int);";

            string query2 = @"UPDATE Books 
                               SET Quantity = Quantity - 1
                               WHERE BookID = @bookID;";


            var parameters1 = new Dictionary<string, (SqlDbType, object, int?)>() {

                ["@bookID"] = (SqlDbType.Int, borrowingData.BookID, null),
                ["@memberID"] = (SqlDbType.Int, borrowingData.MemberID, null),
                ["@borrowingData"] = (SqlDbType.DateTime, borrowingData.BorrowingDate, null),
                ["@dueDate"] = (SqlDbType.DateTime, borrowingData.DueDate, null),
                ["@returnDate"] = (SqlDbType.DateTime, borrowingData.ReturnDate, null),
                ["@status"] = (SqlDbType.NVarChar, borrowingData.Status, 20),
            };
            var parameters2 = new Dictionary<string, (SqlDbType, object, int?)>()
            {
                ["@bookID"] = (SqlDbType.Int, borrowingData.BookID, null),
            };

                commands.Add((query1,parameters1,true));
               commands.Add((query2,parameters2,false));

            var result = SqlHelper.ExecuteTransaction(commands);

            if (result.Success)
            {
                borrowingID = Convert.ToInt32(result.ReturnedValue);
            }
            return borrowingID;
          }
        
        public static int AddNewBorrowing(BorrowingDTO borrowingData)
        {
            object borrowingID = null;

            string query = @"INSERT INTO Borrowings(BookID,MemberID,BorrowingDate,DueDate,ReturnDate,Status)
                          VALUES(@bookID,@memberID,@borrowingData,@dueDate,@returnDate,@status);
                          SELECT CAST(SCOPE_IDENTITY() AS int);";
            var parameters = new Dictionary<string, (SqlDbType, object, int?)>
            {
                
                ["@bookID"] = (SqlDbType.Int, borrowingData.BookID, null),
                ["@memberID"] = (SqlDbType.Int, borrowingData.MemberID, null),
                ["@borrowingData"]= (SqlDbType.DateTime, borrowingData.BorrowingDate, null),
                ["@dueDate"]= (SqlDbType.DateTime, borrowingData.DueDate, null),
                ["@returnDate"]= (SqlDbType.DateTime, borrowingData.ReturnDate, null),
                ["@status"]= (SqlDbType.NVarChar, borrowingData.Status, 20)
            };
             borrowingID = SqlHelper.ExecuteCommand(query,CommandType.Text,SqlHelper.ExecuteType.ExecuteScalar,parameters);
            return Convert.ToInt32(borrowingID);
        }
        public static int UpdateBorrowing(BorrowingDTO borrowingData)
        {
            string query = @"UPDATE Borrowings
                             
                            SET BookID=@bookID,
                                MemberID = @memberID,
                                BorrowingDate = @borrowingData,
                                DueDate = @dueDate,
                                ReturnDate = @returnDate ,
                                Status = @status
                            WHERE BorrowingID=@borrowingID;";

            var parameters = new Dictionary<string,(SqlDbType, object,int?)>()
            {
                ["@borrowingID"] = (SqlDbType.Int, borrowingData.BorrowingID, null),
                ["@bookID"] = (SqlDbType.Int, borrowingData.BookID, null),
                ["@memberID"] = (SqlDbType.Int, borrowingData.MemberID, null),
                ["@borrowingData"] = (SqlDbType.DateTime, borrowingData.BorrowingDate, null),
                ["@dueDate"] = (SqlDbType.DateTime, borrowingData.DueDate, null),
                ["@returnDate"] = (SqlDbType.DateTime, borrowingData.ReturnDate, null),
                ["@status"] = (SqlDbType.NVarChar, borrowingData.Status, 20)

            };
            int rowsAffected = (int)SqlHelper.ExecuteCommand(query,CommandType.Text,SqlHelper.ExecuteType.ExecuteNonQuery,parameters);
            return rowsAffected;
        }
        
        public static int DeleteBorrowing(int id)
        {
            string query = @"DELETE FROM Borrowings WHERE BorrowingID=@borrowingID;";
            var parameters = new Dictionary<string, (SqlDbType, object, int?)>()
            {
                ["@borrowingID"] = (SqlDbType.Int,id,null)
            };
            int rowsAffected = (int)SqlHelper.ExecuteCommand(query,CommandType.Text,SqlHelper.ExecuteType.ExecuteNonQuery,parameters);
            return rowsAffected;
        }

        public static BorrowingDTO FindBorrowingByID(int borrowingID)
        {
            string query = @"SELECT * FROM Borrowings WHERE BorrowingID=@borrowingID;";
            var parameters = new Dictionary<string, (SqlDbType,object,int?)>
            {
                ["@borrowingID"] = (SqlDbType.Int,borrowingID,null)
            };
          using var reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters);

           if (!reader.Read()) return null;

              return new BorrowingDTO
                {
                    BorrowingID = Convert.ToInt32(reader["BorrowingID"]),
                    BookID = Convert.ToInt32(reader["BookID"]),
                    MemberID = Convert.ToInt32(reader["MemberID"]),
                    BorrowingDate = Convert.ToDateTime(reader["BorrowingDate"]),
                    DueDate = Convert.ToDateTime(reader["DueDate"]),
                    ReturnDate = reader["ReturnDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["ReturnDate"]),
                    Status = reader["Status"].ToString()
                };
            }
           
        public static List<BorrowingDTO> GetAllBorrowings()
        {
            var list = new List<BorrowingDTO>();
            string query = @"SELECT * FROM Borrowings";
            using var reader = SqlHelper.ExecuteReader(query,CommandType.Text);
            BorrowingDTO dto = null;
            while (reader.Read())
            {
                dto = new BorrowingDTO
                {
                    BorrowingID = Convert.ToInt32(reader["BorrowingID"]),
                    BookID = Convert.ToInt32(reader["BookID"]),
                    MemberID = Convert.ToInt32(reader["MemberID"]),
                    BorrowingDate = Convert.ToDateTime(reader["BorrowingDate"]),
                    DueDate = Convert.ToDateTime(reader["DueDate"]),
                    ReturnDate = reader["ReturnDate"] == DBNull.Value ? null : (DateTime?)reader["ReturnDate"],
                    Status = Convert.ToString(reader["Status"])
                };
                list.Add(dto);
            }
            return list;     
        }
         
        public static bool ReturnBookAndRestock(int borrowingID,int bookID,DateTime returnDate,int quantity)
        {
            string query1 = @"UPDATE Borrowings SET ReturnDate=@returnDate WHERE BorrowingID=@borrowingID;";
            string query2 = @"UPDATE Books SET Quantity=@quantity WHERE BookID=@bookID;";

            var parameters1 = new Dictionary<string, (SqlDbType, object, int?)> {
                ["@returnDate"] = (SqlDbType.DateTime,returnDate,null),
                ["@borrowingID"] = (SqlDbType.Int,borrowingID,null)
            };
            var parameters2 = new Dictionary<string, (SqlDbType, object, int?)>
            {
                ["@quantity"] = (SqlDbType.Int, quantity, null),
                ["@bookID"] = (SqlDbType.Int, bookID, null)
            };

            var cmd1 = (query1,parameters1,false);
            var cmd2 = (query2, parameters2,false);

            var commands = new List<(string,Dictionary<string, (SqlDbType, object, int?)>,bool)>()
            {
                cmd1,cmd2
            };
            
           var result = SqlHelper.ExecuteTransaction(commands);

            return  result.Success;
               
       }
        
        
    
    }
}

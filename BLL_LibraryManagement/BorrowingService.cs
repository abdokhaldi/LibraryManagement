using DAL_LibraryManagement;
using DTO_LibraryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BLL_LibraryManagement
{
    public class BorrowingService
    {
        public enum Mode {AddNew=1,Update=2 }
        public int BorrowingID { get; private set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate{ get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }

        public readonly bool IsActive;

        public Mode _Mode = Mode.AddNew;

        public BorrowingService(int borrowingID, int bookID, int memberID, DateTime borrowingDate, DateTime dueDate, DateTime? returnDate, string status)
        {
            BorrowingID = borrowingID;
            BookID = bookID;
            MemberID = memberID;
            BorrowingDate = borrowingDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
            Status = status;
            IsActive = _IsActiveBorrowing(BookID,MemberID);
            _Mode = Mode.Update;
        }
        public BorrowingService()
        {
           
            BookID = -1;
            MemberID = -1;
            BorrowingDate = DateTime.Now;
            DueDate = DateTime.Now;
            ReturnDate = null;
            Status = "Borrowed";
            IsActive = true;
            _Mode = Mode.AddNew;
        }

       

        private BorrowingDTO _FillCurrentDataToTransfer()
        {
            return new BorrowingDTO
                         {
                          BookID = BookID,
                          MemberID = MemberID,
                          BorrowingDate = BorrowingDate,
                          DueDate = DueDate,
                          ReturnDate = ReturnDate,
                          Status = Status,
                        
                          };
           }

        private bool __AddNewBorrowing()
        {
            var borrowingData = _FillCurrentDataToTransfer();
            this.BorrowingID = BorrowingRepository.AddNewBorrowing(borrowingData);
            
            return this.BorrowingID > 0;
        }


        private bool _AddNewBorrowing()
        {
            var borrowingData = _FillCurrentDataToTransfer();

            this.BorrowingID = BorrowingRepository.AddBorrowingAndUpdateBook(borrowingData);

            return this.BorrowingID > 0;
        }

        private bool _UpdateBorrowing()
        {
            var borrowingData = _FillCurrentDataToTransfer();
            int rowsAffected = BorrowingRepository.UpdateBorrowing(borrowingData);
            return rowsAffected > 0;
        }

        private bool _IsActiveBorrowing(int bookID,int memberID)
        {
            var result = BorrowingRepository.IsActiveBorrowing(bookID,memberID);
            return result != null;
        }

        public OperationResultBLL Save()
        {
            switch (_Mode)
            {
                case Mode.AddNew:

                    if (_IsActiveBorrowing(BookID, MemberID))
                        return OperationResultBLL.Fail("The book cannot be borrowed ,the member has an active loan for this book .");
                   
                    if (_AddNewBorrowing())
                    {
                        _Mode = Mode.Update;
                        return OperationResultBLL.Ok("The book has been successfully borrowed .");
                    }
                  
                    break;

                case Mode.Update:

                    if (!IsActive)
                        return OperationResultBLL.Fail("This borrowing cannot be updated,because it is inactive.");
                   
                    if (_UpdateBorrowing())
                        return OperationResultBLL.Ok("The borrowing has been updated successfully .");
                 
                    break;
            }
            return OperationResultBLL.Fail();
        }
        
        public static List<BorrowingService> GetAllBorrowings()
        {
            var borrowingsList = BorrowingRepository.GetAllBorrowings();

            if (borrowingsList == null) return null;

            var borrowings = borrowingsList.Select(
                b => new BorrowingService(b.BorrowingID, b.BookID, b.MemberID, b.BorrowingDate, b.DueDate, b.ReturnDate, b.Status)
              ).ToList();

            return borrowings;
        }

        public static BorrowingService FindBorrowingByID(int id)
        {
            var dtoInfo = BorrowingRepository.FindBorrowingByID(id);
           if(dtoInfo == null) return null;
            return new BorrowingService(dtoInfo.BorrowingID,dtoInfo.BookID,dtoInfo.MemberID,dtoInfo.BorrowingDate,dtoInfo.DueDate,dtoInfo.ReturnDate,dtoInfo.Status);
        }

        public OperationResultBLL ReturnBookAndRestock()
        {
            if (ReturnDate != null)
                return OperationResultBLL.Fail($"Book [{BookID}] has already been returned.");
            

            int newQuantity = BookService.GetQuantity(BookID) + 1;

            if (BorrowingRepository.ReturnBookAndRestock(BorrowingID, BookID, DateTime.Now, newQuantity))
                return OperationResultBLL.Ok($"The book [{BookID}] was successfully returned.");

            return OperationResultBLL.Fail($"The return operation for book [{BookID}] failed.");
        }    
        
    }
}

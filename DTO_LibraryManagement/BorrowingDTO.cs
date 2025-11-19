using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_LibraryManagement
{
   
    public  class BorrowingDTO {
        
        public int BorrowingID { get; set; }
        public int BookID { get; set; }
        public int PersonID { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
    }

}

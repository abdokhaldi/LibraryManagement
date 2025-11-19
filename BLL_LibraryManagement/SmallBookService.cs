using DAL_LibraryManagement;
using DTO_LibraryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_LibraryManagement
{
    public class SmallBookService
    {
        public int BookID { get; set; }
        public string Title { get; set; }

        public SmallBookService(int bookID,string title)
        {
            BookID = bookID;
            Title = title;
        }

        public static List<SmallBookService> GetBookAutoSearch(string searchTerm)
        {
            List<SmallBookDTO> bookDTOs = SmallBookRepository.GetSmallBookAutoSearch(searchTerm);
           List<SmallBookService> booksFounded = null;
           if (bookDTOs == null) return null;
            booksFounded = bookDTOs.Select(p => new SmallBookService(p.BookID,p.Title)).ToList();
            return booksFounded;
        }
    }
}

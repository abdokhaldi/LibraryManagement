using DAL_LibraryManagement;
using DTO_LibraryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_LibraryManagement
{
    public class SmallPersonService
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }

        public SmallPersonService(int personID,string fullName)
        {
            this.PersonID = personID;
            FullName = fullName;
        }


        public static List<SmallPersonService> GetPersonAutoSearch(string searchTerm)
        {
            List<SmallPersonService> people = null;
            var peopleList = SmallPersonRepository.GetPersonAutoSearch(searchTerm);
            if (peopleList == null)
                return null;
            people = peopleList.Select(p => new SmallPersonService(p.PersonID, p.FullName)).ToList();
            return people;
        }
    }
}

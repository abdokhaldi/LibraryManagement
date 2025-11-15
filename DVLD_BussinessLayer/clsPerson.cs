using DVLD_DataAccess;
using DVLD_DataAccess.Countries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsPerson
    {
        public enum enMode {AddNew=1,Update=2 }
        public int    PersonID   { get; set; }
        public string NationalNo { get; set; }
        public string FirstName  { get; set; }
        public string SecondName { get; set; }
        public string ThirdName  { get; set; }
        public string LastName     { get; set; }
        public int    Gender     { get; set; }
        public string Phone      { get; set; }
        public string Address { get; set; }
        public string Email      { get; set; }
        public string ImagePath  { get; set; }
        public DateTime? DateOfBirth { get; set;}
        public int   CountryID { get; set; }
        public string FullName
        {
            get {
                return FirstName + " " + SecondName + " " + ThirdName
                    + " " + LastName;
            }
        }
        public enMode   _Mode { get; set; }

        private clsPerson(int PersonID,string NationalNo,string FirstName,string SecondName,
            string ThirdName,string LastName, int Gendor,DateTime? dateOfBirth , string Address, int nationalityCountryID, string Phone,string Email,string ImagePath)
        {
            this.PersonID  = PersonID  ; 
            this.NationalNo= NationalNo;
            this.FirstName = FirstName ;
            this.SecondName= SecondName;
            this.ThirdName = ThirdName ;
            this.LastName  = LastName ;
            this.Gender    = Gendor ;
            this.DateOfBirth = dateOfBirth;
            this.CountryID = nationalityCountryID;
            this.Address   = Address;
            this.Phone     = Phone     ;
            this.Email     = Email     ;
            this.ImagePath = ImagePath;
            _Mode = enMode.Update;
        }
        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Gender = -1;
            this.Phone = "";
            this.Email = "";
            this.ImagePath = "";
            _Mode = enMode.AddNew;
        }
        
        private bool _UpdatePerson()
        {
           return  DataAccessPerson.UpdatePerson(this.PersonID,this.NationalNo,this.FirstName,
                this.SecondName,this.ThirdName,this.LastName,this.Gender,this.DateOfBirth,
                this.Address,this.CountryID,this.Phone,this.Email, this.ImagePath);
        }
        private bool _AddNewPerson()
        {
            this.PersonID = DataAccessPerson.AddNewPerson(this.NationalNo,this.FirstName,this.SecondName,
                this.ThirdName,this.LastName,this.Gender,this.DateOfBirth,this.Address,this.CountryID,this.Phone,this.Email,this.ImagePath);
            return (this.PersonID != -1);
        }
        public static DataTable GetPeopleList() 
        {
            return DataAccessPerson.GetAllPeople();
        }
        public bool Save()
        {
            switch(_Mode){
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                case enMode.Update:
                    {
                        return _UpdatePerson();
                    }
                      
                }
           return false;
        }
        public static bool checkIfFieldExisting(string field,string paramValue)
        {
            int count = DataAccessPerson.checkIfExisting(field,paramValue);
            return (count !=0);     
        }
        public static DataTable GetCountriesList()
        {
            return DataAccessCountry.GetCountries();
        }
   
        public static clsPerson FindPerson(string field,object input)
        {
            int id = -1; int gendor = 0; int nationalityCountryID=0;
            string nationalNo="",firstName = "", secondName = "", thirdName = "";
            string lastName = "", address = "", phone="", email="", imagePath = "";
            DateTime? dateOfBirth=null;
            
            if (DataAccessPerson.FindPerson(field,input, ref id,ref nationalNo,ref firstName,ref secondName,ref thirdName,ref lastName,
                ref gendor,ref dateOfBirth,ref address,ref nationalityCountryID,ref phone,ref email,ref imagePath))
            {
                return new clsPerson(id, nationalNo, firstName, secondName,thirdName,lastName,
                        gendor,dateOfBirth, address, nationalityCountryID, phone,email,imagePath);
            }else
            {
                return null;
            }
        }
        public static bool DeletePersonByID(int personID)
        {
            return DataAccessPerson.DeletePerson(personID);
        }
    
    }
}

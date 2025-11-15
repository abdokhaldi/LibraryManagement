using DVLD_DataAccess;
using DVLD_DataAccess.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer.Users
{
    public class clsUser
    {
        public enum enMode {AddNew=0,Update=1 }
        public clsPerson PersonInfo;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public enMode _Mode { get; set; }
       private clsUser(int userID,int personID,string userName, string password,bool isActive)
        {
           this.UserID = userID;
            this.PersonID = personID;
            this.PersonInfo = clsPerson.FindPerson("PersonID",PersonID);
           this.UserName = userName;
            this.Password = password;
           this.IsActive = isActive;
           this._Mode = enMode.Update;
        }
        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
            this._Mode = enMode.AddNew;
        }

        private bool _AddNewUser()
        {
            this.UserID =  DataAccessUser.AddNewUser(this.PersonID,this.UserName,this.Password,this.IsActive);
            return (UserID != -1);
        }
        private bool _UpdateUser()
        {
            return DataAccessUser.UpdateUser(this.UserID, this.PersonID, this.UserName, this.IsActive);
        }
        public static bool CheckForLogin(string userName, string password)
        {
            return DataAccessUser.CheckForLogin(userName,password);
        }
        public static DataTable GetUsersList()
        {
            return DataAccessUser.GetAllUsers();
        }



        public static bool CheckIfUsernameExisting(string userName)
        {
            return DataAccessUser.CheckIsUsernameExisting(userName);
        }
        public static bool CheckIfUsernameExisting(int personID)
        {
            return DataAccessUser.CheckIsUsernameExisting(personID);
        }


        public static clsUser FindUser (string field, object input)
        {
            int userID = -1, personID = -1;
            bool isActive = false;
            string username = "", password = "";
         if (DataAccessUser.FindUser(field, input, ref userID, ref personID, ref username, ref password,ref isActive))
            {
                return new clsUser(userID, personID, username,password,isActive);
            }
            else
            {
                return null;
            }
        }

        public bool ChangeUserPassword(int userID)
        {
            return DataAccessUser.ChangeUserPassword(userID,this.Password);
        }

     public static bool DeleteUser(int userID)
        {
            return (DataAccessUser.DeleteUser(userID));
        }

     public bool Save()
        {
            switch(_Mode){
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }

    }
}

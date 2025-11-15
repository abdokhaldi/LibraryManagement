using DVLD_BussinessLayer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_project
{
    public class clsSharedCurrentUserInfo
    {
        private static readonly clsSharedCurrentUserInfo _currentUserInfo
            = new clsSharedCurrentUserInfo();
        public static clsSharedCurrentUserInfo currentUserInfo
        {
            get {

                return _currentUserInfo;
            }
        }
      
        public clsUser UserInfo { get;set; }
        private clsSharedCurrentUserInfo() {
              
        }


}
}

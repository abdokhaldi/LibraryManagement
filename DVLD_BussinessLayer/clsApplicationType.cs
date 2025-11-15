using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.ApplicationTypes
{
    public class clsApplicationType
    {
        public int ApplicationTypeID { get; set; }
        public double ApplicationTypeFeese { get; set; }
        public string ApplicationTypeTitle { get; set; }
        private clsApplicationType(int id,string title,double fees)
        {
            this.ApplicationTypeID = id;
            this.ApplicationTypeTitle = title;
            this.ApplicationTypeFeese = fees;
        }
       public static DataTable ApplicationTypesList()
        {
            return DataAccessApplicationType.GetApplicationTypes();
        }
       public bool UpdateApplicationType(int id)
        {
            return DataAccessApplicationType.UpdateApplicationType(id,this.ApplicationTypeTitle,this.ApplicationTypeFeese);
        }
       public static clsApplicationType FindApplicationType(int id)
        {
            string title = "";
            double fees = 0;
            if (DataAccessApplicationType.FindApplicationType(id,ref title,ref fees))
            {
                return new clsApplicationType(id,title,fees);
            }else
            {
                return null;
            }
        }


    }
}

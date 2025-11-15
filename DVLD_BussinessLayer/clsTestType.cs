using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.TestTypes
{
    public class clsTestType
    {
        public int    TestTypeID { get; set; }
        public double TestTypeFees { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }

        private clsTestType(int id, string title,string description, double fees)
        {
            this.TestTypeID = id;
            this.TestTypeTitle = title;
            this.TestTypeDescription = description;
            this.TestTypeFees = fees;
          }

        public static DataTable TestTypesList()
        {
            return DataAccessTestType.GetTestTypes();
        }
        public bool UpdateTestType(int id)
        {
            return DataAccessTestType.UpdateTestType(id, this.TestTypeTitle, this.TestTypeDescription ,this.TestTypeFees);
        }
        public static clsTestType FindTestType(int id)
        {
            string title = "";
            string description = "";
            double fees = 0;
            if (DataAccessTestType.FindTestType(id, ref title, ref description, ref fees))
            {
                return new clsTestType(id, title,description, fees);
            }
            else
            {
                return null;
            }
        }


    }
}

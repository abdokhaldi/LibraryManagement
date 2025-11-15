using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_LibraryManagement
{
    public class StringValidation
    {

        public static bool IsNumber(string txt)
        {
            return int.TryParse(txt,out int result);
        }


    }
}

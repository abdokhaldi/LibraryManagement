using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_LibraryManagement
{
    public class OperationResultBLL
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception ErrorMessage { get; set; }
        public object ReturnedValue { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_delegate_LogerExample.Core
{
    public class Loger
    {
        public delegate void LogAction(string message);
        private LogAction _logAction;
        
        public Loger(LogAction action)
        {
            _logAction = action;
        }

        public void UnLog(LogAction logAction)
        {
            _logAction-= logAction;
        }
        public void Log(string message)
        {
            _logAction(message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_project
{
    public class ApplicationType
    {
        public enum enApplicationType 
        { 
            NewLocal = 1,
            Renew = 2,
            ReplacementForLost=3,
            ReplacementForDamaged=4,
            ReleaseDetained=5,
            NewInternational=6
        }

       public static enApplicationType applicationType { get; set; }
    
    }
}

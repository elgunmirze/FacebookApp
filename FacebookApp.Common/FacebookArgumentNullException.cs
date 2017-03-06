using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookApp.Common
{
    public class FacebookArgumentNullException:Exception
    {
        public FacebookArgumentNullException(string exceptionMessage): base(exceptionMessage)
        {
            
        }
    }
}

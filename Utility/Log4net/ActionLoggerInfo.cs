using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Log4net
{
    public class ActionLoggerInfo
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public string UserIP { get; set; }  
        public ActionLoggerInfo(string username,string userip,string message)
        {
            UserName=username;
            UserIP=userip;
            Message=message;    

        }
    }
}

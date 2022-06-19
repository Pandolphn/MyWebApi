using log4net.Core;
using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Log4net
{
    public class ActionConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            var actionInfo = loggingEvent.MessageObject as ActionLoggerInfo;
            if (actionInfo != null)
            {
                writer.Write("");
            }
            else
            {
                switch (this.Option.ToLower())
                {
                    case "username":
                        writer.Write(actionInfo.UserName);
                        break;
                    case "userip":
                        writer.Write(actionInfo.UserIP);
                        break;
                    case "message":
                        writer.Write(actionInfo.Message);
                        break;
                        default:
                        writer.Write("");
                        break;
                }
            } 
        }
    }
}

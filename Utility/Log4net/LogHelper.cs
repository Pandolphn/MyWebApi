using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Log4net
{
    public class LogHelper
    {
        public static readonly LogHelper Instance = new LogHelper();
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        public LogHelper()
        {
            string text = "";
            text = System.AppDomain.CurrentDomain.BaseDirectory + "CfgFile/log4net.Config";
            XmlConfigurator.ConfigureAndWatch(new FileInfo(text));

        }

        private static ActionLoggerInfo _message = null;
        private static log4net.ILog _log;
        public static log4net.ILog Log
        {
            get
            {
                if(_log == null)
                {
                    _log = LogManager.GetLogger("OperateLogger");
                }
                return _log;
            }
        }

        public static void Debug()
        {
            if (Log.IsDebugEnabled)
                Log.Debug(_message);
        }
        public static void Error()
        {
            if(Log.IsErrorEnabled)
                Log.Error(_message);
        }
        public static void Fatal()
        {
            if( Log.IsFatalEnabled)
                Log.Fatal(_message);
        }

        public static void Info()
        {
              if (Log.IsInfoEnabled)
                    Log.Info(_message); 
        }
        public static void Warn()
        {
            if(Log.IsWarnEnabled)
                Log.Warn(_message);
        }
        public static void SaveMessage(string username, string userip, string message, int level)
        {
            _message = new ActionLoggerInfo(username, userip, message);
            switch (level)
            {
                case 0:Debug(); break;  
                case 1: Info(); break;
                case 2: Warn(); break;
                case 3:Error(); break;
                case 4:Fatal(); break;
                default:break;
            }
        }
    } 
}

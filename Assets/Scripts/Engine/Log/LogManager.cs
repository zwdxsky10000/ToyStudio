using System;

namespace ToyStudio.Engine.Logger
{
    public class LogMgr
    {
        public static Logger GetLogger(string tag = "Default")
        {
            return LoggerFactory.CreateLogger(tag);
        }

        public static LogEntry GetLogEntry()
        {
            return new LogEntry();
        }
    }
}
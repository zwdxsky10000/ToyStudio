using System;
using System.Collections.Generic;
using System.Threading;
using ToyStudio.Engine.Logger.Targets;

namespace ToyStudio.Engine.Logger
{
    /// <summary>
    /// 定义日志级别
    /// </summary>
    public enum LogLevel : byte
    {
        Debug = 0,
        Info  = 1,
        Warn  = 2,
        Error = 4,
        Fatal = 8
    }
    
    public class LogEntry
    {
        public DateTime time;
        public int ThreadID;
        public LogLevel Level;
        public string Message;
    }
    
    public class Logger
    {
        private Dictionary<string, string> m_LogMetaData = new Dictionary<string, string>();

        private List<ILoggerTarget> m_LogTarget = new List<ILoggerTarget>();

        public void AddMetaData(string key, string value)
        {
            m_LogMetaData.Add(key, value);
        }
        
        public void AddTarget(ILoggerTarget target)
        {
            m_LogTarget.Add(target);
        }
        
        public void PrintLog(LogLevel level, string message)
        {
            LogEntry logEntry = LogManager.GetLogEntry();
            logEntry.time = DateTime.Now;
            logEntry.Level = level;
            logEntry.ThreadID = Thread.CurrentThread.ManagedThreadId;
            logEntry.Message = message;
            PrintLogInternal(logEntry);
        }

        private void PrintLogInternal(LogEntry logEntry)
        {
            foreach (var target in m_LogTarget)
            {
                target.AddLogEntry(logEntry);
            }
        }
    }
}
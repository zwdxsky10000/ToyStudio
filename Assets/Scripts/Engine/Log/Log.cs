using ToyStudio.Engine.Logger.Targets;
using UnityEngine;

namespace ToyStudio.Engine.Logger
{
    public static class Log
    {
        private static Logger s_DefaultLog = null;
        static Log()
        {
            s_DefaultLog = LogMgr.GetLogger();

            s_DefaultLog.AddMetaData("UnityVersion", Application.unityVersion);

            s_DefaultLog.AddTarget(new ConsoleTarget());
            s_DefaultLog.AddTarget(new FileTarget());
        }

        #region Debug:指出细粒度信息事件对调试应用程序是非常有帮助的，主要用于开发过程中打印一些运行信息

        public static void Debug(string msg)
        {
            s_DefaultLog.PrintLog(LogLevel.Debug, msg);
        }
        
        public static void Debug<T0>(string msg, T0 t0)
        {
            string finalMsg = string.Format(msg, t0);
            s_DefaultLog.PrintLog(LogLevel.Debug, finalMsg);
        }
        
        public static void Debug<T0, T1>(string msg, T0 t0, T1 t1)
        {
            string finalMsg = string.Format(msg, t0, t1);
            s_DefaultLog.PrintLog(LogLevel.Debug, finalMsg);
        }
        
        public static void Debug<T0, T1, T2>(string msg, T0 t0, T1 t1, T2 t2)
        {
            string finalMsg = string.Format(msg, t0, t1, t2);
            s_DefaultLog.PrintLog(LogLevel.Debug, finalMsg);
        }
        
        public static void Debug<T0, T1, T2, T3>(string msg, T0 t0, T1 t1, T2 t2, T3 t3)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3);
            s_DefaultLog.PrintLog(LogLevel.Debug, finalMsg);
        }
        
        public static void Debug<T0, T1, T2, T3, T4>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4);
            s_DefaultLog.PrintLog(LogLevel.Debug, finalMsg);
        }
        
        public static void Debug<T0, T1, T2, T3, T4, T5>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4, t5);
            s_DefaultLog.PrintLog(LogLevel.Debug, finalMsg);
        }

        #endregion

        #region Info:用于打印程序应该出现的正常状态信息， 便于追踪定位

        public static void Info(string msg)
        {
            s_DefaultLog.PrintLog(LogLevel.Info, msg);
        }
        
        public static void Info<T0>(string msg, T0 t0)
        {
            string finalMsg = string.Format(msg, t0);
            s_DefaultLog.PrintLog(LogLevel.Info, finalMsg);
        }
        
        public static void Info<T0, T1>(string msg, T0 t0, T1 t1)
        {
            string finalMsg = string.Format(msg, t0, t1);
            s_DefaultLog.PrintLog(LogLevel.Info, finalMsg);
        }
        
        public static void Info<T0, T1, T2>(string msg, T0 t0, T1 t1, T2 t2)
        {
            string finalMsg = string.Format(msg, t0, t1, t2);
            s_DefaultLog.PrintLog(LogLevel.Info, finalMsg);
        }
        
        public static void Info<T0, T1, T2, T3>(string msg, T0 t0, T1 t1, T2 t2, T3 t3)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3);
            s_DefaultLog.PrintLog(LogLevel.Info, finalMsg);
        }
        
        public static void Info<T0, T1, T2, T3, T4>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4);
            s_DefaultLog.PrintLog(LogLevel.Info, finalMsg);
        }
        
        public static void Info<T0, T1, T2, T3, T4, T5>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4, t5);
            s_DefaultLog.PrintLog(LogLevel.Info, finalMsg);
        }

        #endregion
        
        #region Warn:表明会出现潜在错误的情形，有些信息不是错误信息，但是也要给程序员的一些提示

        public static void Warn(string msg)
        {
            s_DefaultLog.PrintLog(LogLevel.Warn, msg);
        }
        
        public static void Warn<T0>(string msg, T0 t0)
        {
            string finalMsg = string.Format(msg, t0);
            s_DefaultLog.PrintLog(LogLevel.Warn, finalMsg);
        }
        
        public static void Warn<T0, T1>(string msg, T0 t0, T1 t1)
        {
            string finalMsg = string.Format(msg, t0, t1);
            s_DefaultLog.PrintLog(LogLevel.Warn, finalMsg);
        }
        
        public static void Warn<T0, T1, T2>(string msg, T0 t0, T1 t1, T2 t2)
        {
            string finalMsg = string.Format(msg, t0, t1, t2);
            s_DefaultLog.PrintLog(LogLevel.Warn, finalMsg);
        }
        
        public static void Warn<T0, T1, T2, T3>(string msg, T0 t0, T1 t1, T2 t2, T3 t3)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3);
            s_DefaultLog.PrintLog(LogLevel.Warn, finalMsg);
        }
        
        public static void Warn<T0, T1, T2, T3, T4>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4);
            s_DefaultLog.PrintLog(LogLevel.Warn, finalMsg);
        }
        
        public static void Warn<T0, T1, T2, T3, T4, T5>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4, t5);
            s_DefaultLog.PrintLog(LogLevel.Warn, finalMsg);
        }

        #endregion
        
        #region Error:指出虽然发生错误事件，但仍然不影响系统的继续运行

        public static void Error(string msg)
        {
            s_DefaultLog.PrintLog(LogLevel.Error, msg);
        }
        
        public static void Error<T0>(string msg, T0 t0)
        {
            string finalMsg = string.Format(msg, t0);
            s_DefaultLog.PrintLog(LogLevel.Error, finalMsg);
        }
        
        public static void Error<T0, T1>(string msg, T0 t0, T1 t1)
        {
            string finalMsg = string.Format(msg, t0, t1);
            s_DefaultLog.PrintLog(LogLevel.Error, finalMsg);
        }
        
        public static void Error<T0, T1, T2>(string msg, T0 t0, T1 t1, T2 t2)
        {
            string finalMsg = string.Format(msg, t0, t1, t2);
            s_DefaultLog.PrintLog(LogLevel.Error, finalMsg);
        }
        
        public static void Error<T0, T1, T2, T3>(string msg, T0 t0, T1 t1, T2 t2, T3 t3)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3);
            s_DefaultLog.PrintLog(LogLevel.Error, finalMsg);
        }
        
        public static void Error<T0, T1, T2, T3, T4>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4);
            s_DefaultLog.PrintLog(LogLevel.Error, finalMsg);
        }
        
        public static void Error<T0, T1, T2, T3, T4, T5>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4, t5);
            s_DefaultLog.PrintLog(LogLevel.Error, finalMsg);
        }

        #endregion
        
        #region Fatal:严重的错误事件将会导致应用程序的退出

        public static void Fatal(string msg)
        {
            s_DefaultLog.PrintLog(LogLevel.Fatal, msg);
        }
        
        public static void Fatal<T0>(string msg, T0 t0)
        {
            string finalMsg = string.Format(msg, t0);
            s_DefaultLog.PrintLog(LogLevel.Fatal, finalMsg);
        }
        
        public static void Fatal<T0, T1>(string msg, T0 t0, T1 t1)
        {
            string finalMsg = string.Format(msg, t0, t1);
            s_DefaultLog.PrintLog(LogLevel.Fatal, finalMsg);
        }
        
        public static void Fatal<T0, T1, T2>(string msg, T0 t0, T1 t1, T2 t2)
        {
            string finalMsg = string.Format(msg, t0, t1, t2);
            s_DefaultLog.PrintLog(LogLevel.Fatal, finalMsg);
        }
        
        public static void Fatal<T0, T1, T2, T3>(string msg, T0 t0, T1 t1, T2 t2, T3 t3)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3);
            s_DefaultLog.PrintLog(LogLevel.Fatal, finalMsg);
        }
        
        public static void Fatal<T0, T1, T2, T3, T4>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4);
            s_DefaultLog.PrintLog(LogLevel.Fatal, finalMsg);
        }
        
        public static void Fatal<T0, T1, T2, T3, T4, T5>(string msg, T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            string finalMsg = string.Format(msg, t0, t1, t2, t3, t4, t5);
            s_DefaultLog.PrintLog(LogLevel.Fatal, finalMsg);
        }

        #endregion
    }
}
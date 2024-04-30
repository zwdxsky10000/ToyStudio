using UnityEngine;

namespace ToyStudio.Engine.Download
{
    public static class DownloadLog
    {
        const string DOWNLOAD_TAG = "Download";
        
        public static bool EnableLog = false;

        public static void Info(string message)
        {
            if (EnableLog)
            {
                PrintLog(LogType.Log, message);
            }
        }
        
        public static void Warning(string message)
        {
            if (EnableLog)
            {
                PrintLog(LogType.Warning, message);
            }
        }
        
        public static void Error(string message)
        {
            if (EnableLog)
            {
                PrintLog(LogType.Error, message);
            }
        }

        private static void PrintLog(LogType logType, string message)
        {
#if UNITY_EDITOR
            switch (logType)
            {
                case LogType.Log:
                    Debug.Log($"[{DOWNLOAD_TAG}] [{logType}] {message}");
                    break;
                case LogType.Warning:
                    Debug.LogWarning($"[{DOWNLOAD_TAG}] [{logType}] Message:{message}");
                    break;
                case LogType.Error:
                    Debug.LogError($"[{DOWNLOAD_TAG}] [{logType}] Message:{message}");
                    break;
            }
#else
                
#endif
        }
    }
}
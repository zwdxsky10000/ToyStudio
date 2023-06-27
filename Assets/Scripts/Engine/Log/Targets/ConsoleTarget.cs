namespace ToyStudio.Engine.Logger.Targets
{
    public class ConsoleTarget : ILoggerTarget
    {
        public void AddLogEntry(LogEntry logEntry)
        {
            switch (logEntry.Level)
            {
                case LogLevel.Debug:
                case LogLevel.Info:
                    UnityEngine.Debug.Log(logEntry.Message);
                    break;
                case LogLevel.Warn:
                    UnityEngine.Debug.LogWarning(logEntry.Message);
                    break;
                case LogLevel.Error:
                    UnityEngine.Debug.LogError(logEntry.Message);
                    break;
                case LogLevel.Fatal:
                    UnityEngine.Debug.LogAssertion(logEntry.Message);
                    break;
                default:
                    UnityEngine.Debug.Log(logEntry.Message);
                    break;
            }
            
        }
    }
}
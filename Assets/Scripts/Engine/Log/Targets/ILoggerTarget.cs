namespace ToyStudio.Engine.Logger.Targets
{
    public interface ILoggerTarget
    {
        public void AddLogEntry(LogEntry logEntry);
    }
}
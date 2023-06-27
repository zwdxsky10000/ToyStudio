namespace ToyStudio.Engine.Logger
{
    public static class LoggerFactory
    {
        public static Logger CreateLogger(string tag)
        {
            return new Logger();
        }
    }
}
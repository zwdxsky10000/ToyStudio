namespace ToyStudio.Engine.Download.Request
{
    public delegate void HandleOnRequestProgress(int curSize, int totalSize);
    
    public delegate void HandleOnRequestReturn(bool ret, string taskName, int errorCode);
    
    internal enum ERequestType
    {
        UWR = 0,
    }

    public abstract class DownloadRequest
    {
        public string TaskName { get; protected set; } = string.Empty;
        public int Priority { get; set; } = 0;
        public int RetryCount { get; protected set; } = 3;
        public int Timeout { get; protected set; } = 5;
        
        public string Url { get; protected set; }
        
        public float Progress { get; protected set; }

        public float Speed { get; protected set; }
        
        public string SavePath { get; protected set; }

        public abstract void Start();

        public abstract bool Update();

        public abstract void Stop();

        public abstract void Reset();
        
        public HandleOnRequestReturn OnRequestReturn;
    }
}
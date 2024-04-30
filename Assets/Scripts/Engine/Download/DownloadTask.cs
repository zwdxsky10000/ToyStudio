using ToyStudio.Engine.Download.Request;

namespace ToyStudio.Engine.Download
{
    public delegate void HandleOnDownloadProgress(int downloadSize, int totalSize);

    public delegate void HandleOnDownloadReturn(DownloadTask task, int errorCode);
    
    public enum EDownloadState
    {
        None = 0,
        Init = 1,
        Waiting = 2,
        Downloading = 3,
        Pause = 4,
        Success = 5,
        Fail = 6,
    }

    public enum EDownloadTaskType
    {
        None = 0,
        Single = 1,
        Batch = 2,
    }
    
    public abstract class DownloadTask
    {
        public EDownloadState State
        {
            get;
            set;
        } = EDownloadState.None;

        public EDownloadTaskType TaskType { get; protected set; } = EDownloadTaskType.None;
        
        public string TaskName { get; protected set; } = string.Empty;
        
        public int Priority { get; set; } = 0;

        public HandleOnDownloadReturn OnDownloadReturn;
        
        public int ErrorCode { get; protected set; } = DownloadError.Ok;

        public int RetryCount { get; protected set; } = 3;

        public int Timeout { get; protected set; } = 5;
        
        protected DownloadRequestMgr RequestMgr { get; private set; }

        internal abstract bool Start();
        internal abstract bool Pause();
        internal abstract bool Resume();
        internal abstract bool Stop();
        internal abstract void OnRequestReturn(bool ret, string taskName, int errorCode);
        
        public abstract void Reset();

        public void Bind(DownloadRequestMgr requestMgr)
        {
            RequestMgr = requestMgr;
        }
    }
}
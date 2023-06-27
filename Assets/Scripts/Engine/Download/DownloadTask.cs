namespace ToyStudio.Engine.Download
{
    public enum EDownloadType
    {
        File = 0,
        Batch = 1,
    }

    public enum EDownloadStatus
    {
        None = 0,
        Init = 1,
        Downloading = 2,
        Pause = 3,
        Stop = 4,
        Finish = 5,
        Fail = 6,
    }

    public class DownloadTask
    {
        public string Name { get; set; }

        public EDownloadType DownloadType { get; set; }

        public EDownloadStatus Status { get; set; }

        public long DownloadingSize { get; set; }

        public long TotalSize { get; set; }

        public float Progress
        {
            get
            {
                if (TotalSize != 0)
                {
                    return (DownloadingSize * 1.0f) / TotalSize;
                }

                return 0f;
            }
        }

        public int ErrCode { get; set; }

        public DownloadTask()
        {
            
        }
        
        public DownloadTask(string name, EDownloadType type)
        {
            Name = name;
            DownloadType = type;
        }

        public void Reset()
        {
            
        }
    }
}
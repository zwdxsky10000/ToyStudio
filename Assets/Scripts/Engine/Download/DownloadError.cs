namespace ToyStudio.Engine.Download
{
    public static class DownloadError
    {
        public const int Ok = 0;
        public const int FileNotExist = -1000;
        public const int DownloadTimeout = -1001;
        public const int StorageNotEnough = -1002;
    }
}
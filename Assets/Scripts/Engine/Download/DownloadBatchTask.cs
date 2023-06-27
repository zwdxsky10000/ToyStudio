using System.Collections.Generic;

namespace ToyStudio.Engine.Download
{
    public class DownloadBatchTask : DownloadTask
    {
        public List<string> NeedDownloadingFiles { get; set; }

        public DownloadBatchTask()
        {
            
        }
        
        public DownloadBatchTask(string name, List<string> files, EDownloadType type) : base(name, type)
        {
            NeedDownloadingFiles = files;
        }
    }
}
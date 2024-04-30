using System.Collections.Generic;
using ToyStudio.Engine.Download.Request;

namespace ToyStudio.Engine.Download
{
    public class DownloadBatchTask : DownloadTask
    {
        private readonly List<string> _downloadList = new List<string>();
        private Dictionary<string, DownloadRequest> _downloadRequests;
        
        public void Init(string taskName, List<string> contents, int priority)
        {
            TaskType = EDownloadTaskType.Batch;
            State = EDownloadState.Init;
            TaskName = taskName;
            Priority = priority;
            _downloadList.Clear();
            _downloadList.AddRange(contents);
            _downloadRequests = new Dictionary<string, DownloadRequest>();
        }

        internal override bool Start()
        {
            foreach (var downloadName in _downloadList)
            {
                var request = RequestMgr.StartRequest(downloadName);
                if (request != null)
                {
                    _downloadRequests.Add(downloadName, request);
                }
            }
            State = EDownloadState.Downloading;
            return true;
        }

        internal override bool Pause()
        {
            bool ret = true;
            foreach (var downloadName in _downloadList)
            {
                if (!RequestMgr.PauseRequest(downloadName))
                {
                    ret = false;
                }
            }
            State = EDownloadState.Pause;
            return ret;
        }

        internal override bool Resume()
        {
            bool ret = true;
            foreach (var downloadName in _downloadList)
            {
                if (!RequestMgr.ResumeRequest(downloadName))
                {
                    ret = false;
                }
            }
            State = EDownloadState.Downloading;
            return ret;
        }
        
        internal override bool Stop()
        {
            bool ret = true;
            foreach (var downloadName in _downloadList)
            {
                if (!RequestMgr.StopRequest(downloadName))
                {
                    ret = false;
                }
            }
            State = EDownloadState.None;
            return ret;
        }

        internal override void OnRequestReturn(bool ret, string taskName, int errorCode)
        {
            
        }
        
        public override void Reset()
        {
            TaskType = EDownloadTaskType.Batch;
            State = EDownloadState.None;
            TaskName = string.Empty;
            Priority = 0;
            _downloadList.Clear();
            _downloadRequests.Clear();
        }
    }
}
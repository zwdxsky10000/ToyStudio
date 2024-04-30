using ToyStudio.Engine.Download.Request;

namespace ToyStudio.Engine.Download
{
    public class DownloadSingleTask : DownloadTask
    {
        private DownloadRequest _downloadRequest;
        
        public void Init(string taskName, int priority)
        {
            TaskType = EDownloadTaskType.Single;
            TaskName = taskName;
            Priority = priority;
            State = EDownloadState.Init;
        }

        internal override bool Start()
        {
            bool result = false;
            var request = RequestMgr.StartRequest(TaskName);
            if (request != null)
            {
                request.OnRequestReturn = OnRequestReturn;
                State = EDownloadState.Downloading;
                result = true;
            }
            return result;
        }

        internal override bool Pause()
        {
            var ret = RequestMgr.PauseRequest(TaskName);
            if (ret)
            {
                State = EDownloadState.Pause;
            }
            return ret;
        }

        internal override bool Resume()
        {
            var ret = RequestMgr.ResumeRequest(TaskName);
            if (ret)
            {
                State = EDownloadState.Downloading;
            }
            return ret;
        }
        
        internal override bool Stop()
        {
            var ret = RequestMgr.StopRequest(TaskName);
            if (ret)
            {
                State = EDownloadState.None;
            }
            return ret;
        }
        
        internal override void OnRequestReturn(bool ret, string taskName, int errorCode)
        {
            State = ret ? EDownloadState.Success : EDownloadState.Fail;
            OnDownloadReturn?.Invoke(this, errorCode);
        }

        public override void Reset()
        {
            TaskName = string.Empty;
            Priority = 0;
            State = EDownloadState.None;
            _downloadRequest = null;
        }

        
    }
}
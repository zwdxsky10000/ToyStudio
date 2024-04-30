using System;
using System.Collections.Generic;

namespace ToyStudio.Engine.Download.Request
{
    public class DownloadRequestMgr
    {
        private uint _maxRequestCount = 6;
        private string _remoteURL = String.Empty;
        private string _rootPath = String.Empty;

        private Dictionary<string, DownloadRequest> _allRequests;
        private Dictionary<string, DownloadRequest> _downloadRequests;
        private List<string> _waitingRequests;
        
        public DownloadRequestMgr()
        {
            _allRequests = new Dictionary<string, DownloadRequest>();
            _downloadRequests = new Dictionary<string, DownloadRequest>();
            _waitingRequests = new List<string>();
        }
        
        public void SetMaxRequestCount(uint maxRequestCount)
        {
            _maxRequestCount = maxRequestCount;
        }

        public void SetRemoteURL(string url)
        {
            _remoteURL = url;
        }

        public void SetRootPath(string rootPath)
        {
            _rootPath = rootPath;
        }
        
        public DownloadRequest StartRequest(string taskName)
        {
            if (_allRequests.TryGetValue(taskName, out var request))
            {
                return request;
            }

            request = CreateDownloadRequest(ERequestType.UWR);
            _allRequests.Add(taskName, request);
            
            if (_downloadRequests.Count < _maxRequestCount)
            {
                _downloadRequests.Add(taskName, request);
                request.Start();
            }
            else
            {
                _waitingRequests.Add(taskName);
            }
            return request;
        }
        
        public bool ResumeRequest(string taskName)
        {
            return false;
        }
        
        public bool PauseRequest(string taskName)
        {
            return false;
        }

        public bool StopRequest(string taskName)
        {
            return false;
        }

        private DownloadRequest CreateDownloadRequest(ERequestType requestType)
        {
            switch (requestType)
            {
                case ERequestType.UWR:
                    return new DownloadRequestUWR();
                default:
                    throw new ArgumentException($"EDownloadRequestType:{requestType} is Unknown.");
            }
            
        }
    }
}
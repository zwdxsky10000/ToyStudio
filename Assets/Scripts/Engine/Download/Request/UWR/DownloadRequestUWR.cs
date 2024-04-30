using UnityEngine.Networking;

namespace ToyStudio.Engine.Download.Request
{
    internal class DownloadRequestUWR : DownloadRequest
    {
        private UnityWebRequest _webRequest;
        private ChunkDownloadHandler _downloadHandler;
        
        public override void Start()
        {
            //断点续传设置读取文件数据流开始索引，成功会返回206
            _webRequest = UnityWebRequest.Get(Url);
            _webRequest.disposeDownloadHandlerOnDispose = true;
            _webRequest.useHttpContinue = true; //默认就是true

            _downloadHandler = new ChunkDownloadHandler(SavePath);
            _webRequest.downloadHandler = _downloadHandler;
            _webRequest.SetRequestHeader("Range", "bytes=" + _downloadHandler.DownedLength + "-");

            _webRequest.SendWebRequest(); //协程操作，可以在协程中调用等待
        }

        public override bool Update()
        {
            if (_webRequest.result == UnityWebRequest.Result.InProgress)
            {
                return false;
            }
            
            if (_webRequest.result == UnityWebRequest.Result.ConnectionError ||
                _webRequest.result == UnityWebRequest.Result.ProtocolError ||
                _webRequest.result == UnityWebRequest.Result.DataProcessingError)
            {
                
                return true;
            }

            return _webRequest.isDone && _webRequest.result == UnityWebRequest.Result.Success;
        }

        public override void Stop()
        {
            if (_downloadHandler != null)
            {
                _downloadHandler.OnDispose();  //释放文件操作的资源
            }

            if (_webRequest != null)
            {
                _webRequest.Abort();    //中止下载
                _webRequest.Dispose();  //释放
            }
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;

namespace ToyStudio.Engine.Download
{
    public class DownloadManager
    {
        #region Fields
        private Dictionary<string, DownloadTask> m_DownloadingTaskMap;

        public Dictionary<string, DownloadTask> DownlodingTaskMap => m_DownloadingTaskMap ??= new Dictionary<string, DownloadTask>();

        public DownloadTaskFactory TaskFactory { get; set; } = new DownloadTaskFactory(4);
        #endregion

        #region OpenAPI

        public DownloadTask CreateTask(string name, EDownloadType type)
        {
            // if (TaskFactory != null)
            // {
            //     var task = TaskFactory.CreateTask(type);
            //     task.Name = name;
            //     task.
            // }
            
            return null;
        }
        
        public DownloadTask CreateBatchTask(string name, EDownloadType type, List<string> files)
        {
            // if (TaskFactory != null)
            // {
            //     var task = TaskFactory.CreateTask<DownloadBatchTask>(type);
            //     task.Name = name;
            //     task.
            // }
            
            return null;
        }

        public DownloadTask GetTask(string name)
        {
            if (DownlodingTaskMap != null && DownlodingTaskMap.TryGetValue(name, out var task))
            {
                return task;
            }

            return null;
        }

        public bool StartTask(string name)
        {
            return false;
        }

        public bool PauseTask(string name)
        {
            return false;
        }

        public bool ResumeTask(string name)
        {
            return false;
        }

        public bool DestroyTask(string name)
        {
            return false;
        }

        public bool PauseAllTask()
        {
            return false;
        }

        public bool ResumeAllTask()
        {
            return false;
        }

        public bool DestroyAllTask()
        {
            return false;
        }
        #endregion

    }
}


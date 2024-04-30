using System.Collections.Generic;
using ToyStudio.Engine.Download.Request;

namespace ToyStudio.Engine.Download
{
    public class DownloadMgr
    {
        private uint _maxDownloadRequestCount = 6;
        
        private uint _maxDownloadTaskCount = 100;
        
        private readonly DownloadRequestMgr _requestMgr;

        private readonly DownloadFactory _taskFactory; 
        
        private readonly Dictionary<string, DownloadTask> _allDownloadTasks = new Dictionary<string, DownloadTask>();
        
        private readonly Dictionary<string, DownloadTask> _downloadingTasks = new Dictionary<string, DownloadTask>();

        private readonly List<string> _waitingTasks = new List<string>();
        
        public DownloadMgr()
        {
            _requestMgr = new DownloadRequestMgr();
            
            _taskFactory = new DownloadFactory();
            _taskFactory.RegisterObjectPool(() => new DownloadSingleTask());
            _taskFactory.RegisterObjectPool(() => new DownloadBatchTask());
        }

        public void SetRemoteURL(string url)
        {
            _requestMgr?.SetRemoteURL(url);
        }
        
        public void SetRootPath(string rootPath)
        {
            _requestMgr?.SetRootPath(rootPath);
        }
        
        public void SetMaxRequestCount(uint maxDLRequest)
        {
            if (_maxDownloadRequestCount != maxDLRequest)
            {
                _requestMgr?.SetMaxRequestCount(maxDLRequest);
                _maxDownloadRequestCount = maxDLRequest;
            }
        }
        
        public void SetMaxTaskCount(uint maxDLTask)
        {
            _maxDownloadTaskCount = maxDLTask;
        }
        
        public T GetTask<T>(string taskName) where T : DownloadTask
        {
            if (_allDownloadTasks.TryGetValue(taskName, out var task))
            {
                return task as T;
            }
            return default(T);
        }
        
        public DownloadTask CreateAndStartTask(string taskName, int priority = 0)
        {
            var task = CreateTask(taskName, priority);
            StartTask(task);
            return task;
        }
        
        public DownloadTask CreateAndStartTask(string taskName, List<string> contents, int priority = 0)
        {
            var task = CreateTask(taskName, contents, priority);
            StartTask(task);
            return task;
        }
        
        public DownloadTask CreateTask(string taskName, int priority = 0)
        {
            if (_allDownloadTasks.TryGetValue(taskName, out var task))
            {
                return task;
            }
            
            var singleTask = _taskFactory.GetObject<DownloadSingleTask>();
            singleTask.Init(taskName, priority);
            _allDownloadTasks.Add(taskName, singleTask);
            
            return singleTask;
        }

        public DownloadTask CreateTask(string taskName, List<string> contents, int priority = 0)
        {
            if (_allDownloadTasks.TryGetValue(taskName, out var task))
            {
                return task;
            }
            
            var batchTask = _taskFactory.GetObject<DownloadBatchTask>();
            batchTask.Init(taskName, contents, priority);
            
            _allDownloadTasks.Add(taskName, batchTask);
            return batchTask;
        }

        public bool StartTask(string taskName, int priority = 0)
        {
            if (!_allDownloadTasks.TryGetValue(taskName, out var task))
            {
                DownloadLog.Warning($"StartTask fail. taskName:{taskName} don't exist _allDownloadTasks.");
                return false;
            }
            return StartTask(task, priority);
        }
        
        public bool StartTask(DownloadTask task, int priority = 0)
        {
            if (task == null)
            {
                return false;
            }

            if (_downloadingTasks.Count < _maxDownloadTaskCount)
            {
                _downloadingTasks.TryAdd(task.TaskName, task);
                TrackTask(task);
                return task.Start();
            }
            else
            {
                task.State = EDownloadState.Waiting;
                _waitingTasks.Add(task.TaskName);
                return true;
            }
        }
        
        public bool PauseTask(string taskName)
        {
            if (!_allDownloadTasks.TryGetValue(taskName, out var task))
            {
                DownloadLog.Warning($"PauseTask fail. taskName:{taskName} don't exist _allDownloadTasks.");
                return false;
            }
            return PauseTask(task);
        }
        
        public bool PauseTask(DownloadTask task)
        {
            if (task == null)
            {
                DownloadLog.Error($"PauseTask fail. task == null.");
                return false;
            }
            
            var taskName = task.TaskName;
            if (_downloadingTasks.ContainsKey(taskName))
            {
                return task.Pause();
            }
            return true;
        }
        
        public bool ResumeTask(string taskName)
        {
            if (!_allDownloadTasks.TryGetValue(taskName, out var task))
            {
                DownloadLog.Warning($"ResumeTask fail. taskName:{taskName} don't exist _allDownloadTasks.");
                return false;
            }
            return ResumeTask(task);
        }
        
        public bool ResumeTask(DownloadTask task)
        {
            if (task == null)
            {
                DownloadLog.Error($"ResumeTask fail. task == null.");
                return false;
            }
            
            var taskName = task.TaskName;
            if (_downloadingTasks.ContainsKey(taskName))
            {
                return task.Resume();
            }
            return true;
        }
        
        public bool RemoveTask(string taskName)
        {
            if (!_allDownloadTasks.TryGetValue(taskName, out var task))
            {
                DownloadLog.Warning($"RemoveTask fail. taskName:{taskName} don't exist _allDownloadTasks.");
                return false;
            }
            
            return RemoveTask(task);
        }
        
        public bool RemoveTask(DownloadTask task)
        {
            if (task == null)
            {
                DownloadLog.Error($"RemoveTask fail. task == null.");
                return false;
            }

            var taskName = task.TaskName;
            if (_downloadingTasks.ContainsKey(taskName))
            {
                task.Stop();
                UnTrackTask(task);
                _downloadingTasks.Remove(taskName);
            }
            
            if (task.TaskType == EDownloadTaskType.Single)
            {
                _taskFactory.ReturnObject(task as DownloadSingleTask);
            }
            else if (task.TaskType == EDownloadTaskType.Batch)
            {
                _taskFactory.ReturnObject(task as DownloadBatchTask);
            }

            return _allDownloadTasks.Remove(taskName);
        }

        private void TrackTask(DownloadTask task)
        {
            task.OnDownloadReturn += HandleDownloadTaskCompleted;
        }
        
        private void UnTrackTask(DownloadTask task)
        {
            task.OnDownloadReturn -= HandleDownloadTaskCompleted;
        }

        private void HandleDownloadTaskCompleted(DownloadTask task, int errCode)
        {
            if (_downloadingTasks.ContainsKey(task.TaskName))
            {
                UnTrackTask(task);
                _downloadingTasks.Remove(task.TaskName);
            }

            for (int index = _waitingTasks.Count - 1; index >= 0; --index)
            {
                if (_downloadingTasks.Count >= _maxDownloadTaskCount) 
                    break;
                
                var waitTask = GetTask<DownloadTask>(_waitingTasks[index]);
                if (waitTask != null)
                {
                    waitTask.Start();
                    TrackTask(waitTask);
                }
                _waitingTasks.RemoveAt(index);
            }
        }

        public bool SetTaskPriority(string taskName, int priority)
        {
            if (!_allDownloadTasks.TryGetValue(taskName, out var task))
            {
                DownloadLog.Warning($"SetTaskPriority fail. taskName:{taskName} don't exist _allDownloadTasks.");
                return false;
            }
            return SetTaskPriority(task, priority);
        }
        
        public bool SetTaskPriority(DownloadTask task, int priority)
        {
            if (task == null)
            {
                DownloadLog.Error($"SetTaskPriority fail. task == null.");
                return false;
            }

            task.Priority = priority;
            return true;
        }

        public void StartAllTask()
        {
            foreach (var taskPair in _allDownloadTasks)
            {
                StartTask(taskPair.Value);
            }
        }

        public void StartTasks(List<string> taskNames)
        {
            foreach (var taskName in taskNames)
            {
                StartTask(taskName);
            }
        }

        public void StartTasks(List<DownloadTask> tasks)
        {
            foreach (var task in tasks)
            {
                StartTask(task);
            }
        }
        
        public void PauseAllTask()
        {
            foreach (var taskPair in _allDownloadTasks)
            {
                PauseTask(taskPair.Value);
            }
        }

        public void PauseTasks(List<string> taskNames)
        {
            foreach (var taskName in taskNames)
            {
                PauseTask(taskName);
            }
        }

        public void PauseTasks(List<DownloadTask> tasks)
        {
            foreach (var task in tasks)
            {
                PauseTask(task);
            }
        }
        
        public void ResumeAllTask()
        {
            foreach (var taskPair in _allDownloadTasks)
            {
                ResumeTask(taskPair.Value);
            }
        }

        public void ResumeTasks(List<string> taskNames)
        {
            foreach (var taskName in taskNames)
            {
                ResumeTask(taskName);
            }
        }

        public void ResumeTasks(List<DownloadTask> tasks)
        {
            foreach (var task in tasks)
            {
                ResumeTask(task);
            }
        }
        
        public void RemoveAllTask()
        {
            foreach (var taskPair in _allDownloadTasks)
            {
                RemoveTask(taskPair.Value);
            }
        }
        
        public void RemoveTasks(List<string> taskNames)
        {
            foreach (var taskName in taskNames)
            {
                RemoveTask(taskName);
            }
        }

        public void RemoveTasks(List<DownloadTask> tasks)
        {
            foreach (var task in tasks)
            {
                RemoveTask(task);
            }
        }
    }
}
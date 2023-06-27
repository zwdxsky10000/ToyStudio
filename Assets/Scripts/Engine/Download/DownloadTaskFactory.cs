using System;

namespace ToyStudio.Engine.Download
{
    public class DownloadTaskFactory
    {
        private uint m_CacheSize;
        
        public DownloadTaskFactory(uint cacheSize)
        {
            m_CacheSize = cacheSize;
        }
        
        public T CreateTask<T>() where T : DownloadTask,new()
        {
            return new T();
        }

        public void ReleaseTask(DownloadTask task)
        {
            
        }
    }
}
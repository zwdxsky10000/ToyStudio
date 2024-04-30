using System;
using System.Collections.Generic;

namespace ToyStudio.Engine.Download
{
    internal class ObjectPool<T>
    {
        private readonly Stack<T> _pool = new Stack<T>();
        private readonly Func<T> _createFunc;

        public ObjectPool(Func<T> createFunc)
        {
            _createFunc = createFunc;
        }

        public T GetObject()
        {
            if (_pool.Count > 0)
            {
                return _pool.Pop();
            }
            else
            {
                return _createFunc();
            }
        }

        public void ReturnObject(T obj)
        {
            _pool.Push(obj);
        }
    }

    public class DownloadFactory
    {
        private readonly Dictionary<Type, object> _objectPools = new Dictionary<Type, object>();

        public void RegisterObjectPool<T>(Func<T> createFunc) where T : DownloadTask
        {
            var type = typeof(T);
            if (!_objectPools.ContainsKey(type))
            {
                _objectPools[type] = new ObjectPool<T>(createFunc);
            }
        }

        public T GetObject<T>() where T : DownloadTask
        {
            var type = typeof(T);
            if (_objectPools.TryGetValue(type, out var pool))
            {
                return ((ObjectPool<T>)pool).GetObject();
            }
            else
            {
                throw new InvalidOperationException($"Object pool for type {type} is not registered.");
            }
        }

        public void ReturnObject<T>(T obj) where T : DownloadTask
        {
            obj?.Reset();

            var type = typeof(T);
            if (_objectPools.TryGetValue(type, out var pool))
            {
                ((ObjectPool<T>)pool).ReturnObject(obj);
            }
            else
            {
                throw new InvalidOperationException($"Object pool for type {type} is not registered.");
            }
        }
    }
}
using System;

namespace ToyStudio.Engine.Save
{
    public sealed class SmartSave
    {
        public void Open(string savePath)
        {
            
        }

        public void Flush(bool force = false)
        {
            
        }

        public void Close()
        {
            
        }
        
        public void SetInt(string key, int value)
        {
            SetValue<SaveInt>(key, value);
        }

        public int GetInt(string key, int defaultValue = 0)
        {
            return GetValue<SaveInt>(key, defaultValue);
        }
        
        public void SetBool(string key, bool value)
        {
            SetValue<SaveBool>(key, value);
        }

        public bool GetBool(string key, bool defaultValue = false)
        {
            return GetValue<SaveBool>(key, defaultValue);
        }
        
        public void SetString(string key, string value)
        {
            SetValue<SaveString>(key, value);
        }

        public string GetString(string key, string defaultValue = "")
        {
            return GetValue<SaveString>(key, defaultValue);
        }
        
        public void SetValue<T>(string key, T value) where T : SaveBase
        {
            
        }

        public T GetValue<T>(string key, T defaultValue = default(T)) where T : SaveBase
        {
            return default(T);
        }
    }
}
using System;

namespace ToyStudio.Engine.Save
{
    public class SaveString : SaveBase
    {
        public string Value { get; private set; }

        // 使用implicit操作符重载，允许隐式转换
        public static implicit operator SaveString(string value)
        {
            return new SaveString(value);
        }

        // 新增的从MyClass到int的隐式转换操作符
        public static implicit operator string(SaveString saveStr)
        {
            if (saveStr == null)
            {
                throw new ArgumentNullException(nameof(saveStr));
            }
            return saveStr.Value;
        }
        
        // 私有构造函数，只能通过上面的操作符重载来创建
        private SaveString(string value)
        {
            Value = value;
        }
    }
}
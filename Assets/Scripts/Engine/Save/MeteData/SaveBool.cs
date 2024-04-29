using System;

namespace ToyStudio.Engine.Save
{
    public class SaveBool : SaveBase
    {
        public bool Value { get; private set; }

        // 使用implicit操作符重载，允许隐式转换
        public static implicit operator SaveBool(bool value)
        {
            return new SaveBool(value);
        }

        // 新增的从MyClass到int的隐式转换操作符
        public static implicit operator bool(SaveBool saveBool)
        {
            if (saveBool == null)
            {
                throw new ArgumentNullException(nameof(saveBool));
            }
            return saveBool.Value;
        }
        
        // 私有构造函数，只能通过上面的操作符重载来创建
        private SaveBool(bool value)
        {
            Value = value;
        }
    }
}
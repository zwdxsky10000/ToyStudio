using System;

namespace ToyStudio.Engine.Save
{
    public class SaveInt : SaveBase
    {
        public int Value { get; private set; }

        // 使用implicit操作符重载，允许隐式转换
        public static implicit operator SaveInt(int value)
        {
            return new SaveInt(value);
        }

        // 新增的从MyClass到int的隐式转换操作符
        public static implicit operator int(SaveInt saveInt)
        {
            if (saveInt == null)
            {
                throw new ArgumentNullException(nameof(saveInt));
            }
            return saveInt.Value;
        }
        
        // 私有构造函数，只能通过上面的操作符重载来创建
        private SaveInt(int value)
        {
            Value = value;
        }
    }
}
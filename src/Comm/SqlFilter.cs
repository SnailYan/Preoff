using System;

namespace Preoff.Comm
{
    public class SqlFilter
    {
        public static SqlFilter Create(string propertyName, Operation operation, object value)
        {
            return new SqlFilter()
            {
                Name = propertyName,
                Operation = operation,
                Value = value
            };
        }

        /// <summary>
        /// 字段名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 搜索操作，大于小于等于
        /// </summary>
        public Operation Operation { get; set; }

        /// <summary>
        /// 搜索参数值
        /// </summary>
        public object Value { get; set; }
    }
}

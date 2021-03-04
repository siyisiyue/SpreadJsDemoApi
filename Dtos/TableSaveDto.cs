using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    /// <summary>
    /// 表单保存
    /// </summary>
    public class TableSaveDto
    {
        /// <summary>
        /// 表类型
        /// </summary>
        public string tableName { get; set; }
        /// <summary>
        /// JSON数据
        /// </summary>
        public string Data { get; set; }
    }
}

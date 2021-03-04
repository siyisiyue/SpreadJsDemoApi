using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    /// <summary>
    /// 坐标模板
    /// </summary>
    public class PostionTemp
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public string FieldName { get; set; }
        public string Type { get; set; }
    }
}

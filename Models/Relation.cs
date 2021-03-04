using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    public class Relation
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 表单类的命名空间
        /// </summary>
        public string TableNamespace { get; set; }
        /// <summary>
        /// 表单名
        /// </summary>
        [Required]
        public string TableName { get; set; }
        /// <summary>
        /// Dto的命名空间
        /// </summary>
        public string DtoNameSpace { get; set; }
        /// <summary>
        /// Dto类名称
        /// </summary>
        [Required]
        public string TableDtoName { get; set; }
        /// <summary>
        /// DtoData类名称
        /// </summary>
        [Required]
        public string TableDtoDataName { get; set; }
        /// <summary>
        /// 初始化时生成实例个数
        /// </summary>
        public int InstanceCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{

    /// <summary>
    /// 表头公有部分
    /// </summary>
    public class TableHead:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 工程项目名称
        /// </summary>
        [Description("工程项目名称")]
        public string Name { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 承包单位
        /// </summary>
        [Description("承包单位")]
        public string CBDW { get; set; }
        /// <summary>
        /// 监理单位
        /// </summary>
        [Description("监理单位")]
        public string JLDW { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        [Description("合同号")]
        public string ContractNo { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        public string No { get; set; }
        /// <summary>
        /// 工程名称
        /// </summary>
        [Description("工程名称")]
        public string ProjectName { get; set; }
        /// <summary>
        /// 施工部位
        /// </summary>
        [Description("施工部位")]
        public string WorkPart { get; set; }
        /// <summary>
        /// 外观
        /// </summary>
        [Description("外观质量")]
        public string Facade { get; set; }
        /// <summary>
        /// 检验结论
        /// </summary>
        [Description("检验结论")]
        public string Result { get; set; }
        /// <summary>
        /// 检验负责人
        /// </summary>
        [Description("检验负责人")]
        public string SignTest { get; set; }
        /// <summary>
        /// 复核
        /// </summary>
        [Description("复核")]
        public string SignReview { get; set; }
        /// <summary>
        /// 记录
        /// </summary>
        [Description("记录")]
        public string SignRecord { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [Description("日期")]
        public string Date { get; set; }


    }
}

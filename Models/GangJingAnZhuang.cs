using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    /// <summary>
    /// 钻(挖)孔灌注桩、地下连续墙钢筋安装检验记录表
    /// </summary>
    public class GangJingAnZhuang : BaseParent
    {
        public int Id { get; set; }
        /// <summary>
        /// 表头Id
        /// </summary>
        public int TableHeadId { get; set; }
        /// <summary>
        /// 主筋间距
        /// </summary>
        [Description("主筋间距设计值")]
        public string ZhuJingJianJuSj { get; set; }
        [Description("主筋间距实测值")]
        public string ZhuJingJianJuSc { get; set; }
        [Description("主筋间距偏差值")]
        public string ZhuJingJianJuPc { get; set; }
        /// <summary>
        /// 箍筋或螺旋筋间距
        /// </summary>
        [Description("箍筋或螺旋筋间距设计值")]
        public string KuJingSj { get; set; }
        [Description("箍筋或螺旋筋间距实测值")]
        public string KuJingSc { get; set; }
        [Description("箍筋或螺旋筋间距偏差值")]
        public string KuJingPc { get; set; }

        /// <summary>
        /// 钢筋骨架外径或厚、宽
        /// </summary>
        [Description("钢筋骨架外径或厚、宽设计值")]
        public string GuJiaWaiJingSj { get; set; }
        [Description("钢筋骨架外径或厚、宽实测值")]
        public string GuJiaWaiJingSc { get; set; }
        [Description("钢筋骨架外径或厚、宽偏差值")]
        public string GuJiaWaiJingPc { get; set; }
        /// <summary>
        /// 钢筋骨架长度
        /// </summary>
        [Description("钢筋骨架长度设计值")]
        public string GangJingChangDuSj { get; set; }
        [Description("钢筋骨架长度实测值")]
        public string GangJingChangDuSc { get; set; }
        [Description("钢筋骨架长度偏差值")]
        public string GangJingChangDuPc { get; set; }
        /// <summary>
        /// 钢筋骨架底端高程
        /// </summary>
        [Description("钢筋骨架底端高程设计值")]
        public string GaoChengSj { get; set; }
        [Description("钢筋骨架底端高程实测值")]
        public string GaoChengSc { get; set; }
        [Description("钢筋骨架底端高程偏差值")]
        public string GaoChengPc { get; set; }
        /// <summary>
        /// 保护层厚度
        /// </summary>
        [Description("保护层厚度设计值")]
        public string HouDuSj { get; set; }
        [Description("保护层厚度实测值")]
        public string HouDuSc { get; set; }
        [Description("保护层厚度偏差值")]
        public string HouDuPc { get; set; }
    }
}

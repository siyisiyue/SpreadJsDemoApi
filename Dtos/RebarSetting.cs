using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    public class RebarSetting:TableHead,BaseData<RebarSetting, GangJingAnZhuang>
    {
        [Description("数据列表")]
        public List<GangJingAnZhuang> Data { get; set; }
    }
}

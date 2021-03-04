using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    public class CementConcrete:TableHead, BaseData<CementConcrete, ShuiNiHunLingTu>
    {
        [Description("数据列表")]
        public List<ShuiNiHunLingTu> Data { get; set; }
    }
}

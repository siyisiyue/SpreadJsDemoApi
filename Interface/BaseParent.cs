using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    public interface BaseParent:BaseEntity
    {
        public int TableHeadId { get; set; }
    }
}

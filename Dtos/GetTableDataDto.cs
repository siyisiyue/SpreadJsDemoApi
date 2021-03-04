using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    public class GetTableDataDto
    {
        public int Id { get; set; }
        public string TableName { get; set; }

        public int InstanceCount { get; set; }
    }
}

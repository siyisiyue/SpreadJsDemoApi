using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    public interface BaseData<T, F>
    {
        public List<F> Data { get; set; }
        public string TableName { get; set; }

    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<TableHead, CementConcrete>();
            CreateMap<TableHead, RebarSetting>();
        }

    }
}

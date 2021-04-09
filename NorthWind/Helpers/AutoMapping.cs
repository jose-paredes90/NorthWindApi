using AutoMapper;
using NorthWind.Dto;
using NorthWind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Products, ProductsDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(m => m.ProductName));
        }
    }
}

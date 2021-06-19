using AutoMapper;
using NorthWind.Dto;
using NorthWind.Dto.Request;
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
                .ForMember(dest => dest.Name, src => src.MapFrom(m => m.ProductName))
                .ForMember(dest => dest.Imagen, src => src.MapFrom(x => "http://localhost/Imagenes/" + x.Imagen));
            CreateMap<Categories, CategoryDto>()
                .ForMember(x => x.Name, src => src.MapFrom(m => m.CategoryName));
            CreateMap<Usuarios, LoginRequest>()
                .ForMember(x => x.UserName, src => src.MapFrom(m => m.UserName ));
            CreateMap<Customers, CustomerDto>()
                .ForMember(x => x.CompanyName, src => src.MapFrom(m => m.CompanyName));
            CreateMap<Suppliers, SupplierDto>()
                .ForMember(x => x.CompanyName, src => src.MapFrom(m => m.CompanyName));
        }
    }
}

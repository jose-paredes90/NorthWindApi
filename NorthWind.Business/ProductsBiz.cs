using AutoMapper;
using NorthWind.Dto;
using NorthWind.Entity.Models;
using NorthWind.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Business
{
    public class ProductsBiz: IProductsBiz
    {
        private readonly NorthwindContext northwindContext;
        private readonly IMapper mapper;
        public ProductsBiz(IMapper mapper, NorthwindContext context)
        {
            northwindContext = context;
            this.mapper = mapper;
        }
        public List<ProductsDto> GetProducts(int categoryId)
        {
            var products = northwindContext.Products
                                .Where(x=> x.CategoryId == categoryId).ToList();
            var response = mapper.Map<List<Products>, List<ProductsDto>>(products);
            return response;
        }

        public List<ProductsDto> BestSellingProducts(int cantidad)
        {
            var top = northwindContext.Products
                    .OrderByDescending(x => x.OrderDetails.Sum(o => o.Quantity))
                    .Take(cantidad)
                    .ToList();
            var response = mapper.Map<List<Products>, List<ProductsDto>>(top);
            return response;
        }
    }
}

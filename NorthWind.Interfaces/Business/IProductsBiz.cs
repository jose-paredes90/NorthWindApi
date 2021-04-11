using System;
using System.Collections.Generic;
using System.Text;
using NorthWind.Dto;

namespace NorthWind.Interfaces.Business
{
    public interface IProductsBiz
    {
        List<ProductsDto> GetProducts(int categoryId);
        List<ProductsDto> BestSellingProducts(int cantidad);
    }
}

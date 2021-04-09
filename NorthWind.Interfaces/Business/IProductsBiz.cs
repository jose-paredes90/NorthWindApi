using System;
using System.Collections.Generic;
using System.Text;
using NorthWind.Dto;

namespace NorthWind.Interfaces.Business
{
    public interface IProductsBiz
    {
        List<ProductsDto> GetProducts();
        List<ProductsDto> BestSellingProducts(int cantidad);
    }
}

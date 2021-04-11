using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Dto;
using NorthWind.Entity;
using NorthWind.Entity.Models;
using NorthWind.Interfaces;
using NorthWind.Interfaces.Business;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IProductsBiz productsBiz;
 
        public ProductsController(IProductsBiz productsBiz)
        {
            this.productsBiz = productsBiz;
        }

        [HttpGet, Route("")]
        public IActionResult Get([FromQuery] int categoryId)
        {
            List<ProductsDto> products = productsBiz.GetProducts(categoryId);
            return Ok(products);
        }

        [HttpGet, Route("top/{cantidad}")]
        public IActionResult BestSellingProducts(int cantidad)
        {
            var topTen = productsBiz.BestSellingProducts(cantidad);
            return Ok(topTen);
        }

    }
}

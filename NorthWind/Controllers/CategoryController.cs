using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Dto;
using NorthWind.Entity.Models;
using NorthWind.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
          private readonly ICategoryBiz categoryBiz;

        public CategoryController(ICategoryBiz category)
        {
            this.categoryBiz = category;
        }

        [HttpGet, Route("")]
        public IActionResult GetCategoria()
        {
            List<CategoryDto> category = categoryBiz.GetCategoria();
            return Ok(category);
        }
    }
}

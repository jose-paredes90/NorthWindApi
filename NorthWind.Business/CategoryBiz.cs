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
    public class CategoryBiz: ICategoryBiz
    {
        private readonly IMapper mapper;
        private readonly NorthwindContext context;

        public CategoryBiz(IMapper mapper, NorthwindContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public List<CategoryDto> GetCategoria()
        {
            var category = context.Categories.ToList();

            var response = mapper.Map<List<Categories>, List<CategoryDto>>(category);
            
            return response;
        }
    }
}

using NorthWind.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Interfaces.Business
{
    public interface ICategoryBiz
    {
        List<CategoryDto> GetCategoria();
    }
}

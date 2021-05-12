using NorthWind.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Interfaces.Business
{
    public interface ICustomerBiz
    {
        CustomerDto GetCustomersById(string customerId);
        List<CustomerDto> GetCustomersByCountry(string pais);
    }
}

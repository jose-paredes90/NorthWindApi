using AutoMapper;
using NorthWind.Dto;
using NorthWind.Entity.Models;
using NorthWind.Interfaces.Business;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Business
{
    public class CustomerBiz : ICustomerBiz
    {
        private readonly NorthwindContext context;
        private readonly IMapper mapper;

        public CustomerBiz(NorthwindContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public CustomerDto GetCustomersById(string customerId)
        {
            var customer = context.Customers
                .Where(x => x.CustomerId == customerId).FirstOrDefault();
            var response = mapper.Map<Customers, CustomerDto>(customer);
            return response;
        }

        public List<CustomerDto> GetCustomersByCountry(string pais)
        {
            var cliente = context.Customers
                .Where(x => x.Country == pais).ToList();
            var response = mapper.Map<List<Customers>, List<CustomerDto>>(cliente);
            return response;
        }   
    }
}


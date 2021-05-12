using Microsoft.AspNetCore.Mvc;
using NorthWind.Dto;
using NorthWind.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBiz customerBiz;

        public CustomerController(ICustomerBiz customerBiz)
        {
            this.customerBiz = customerBiz;
        }

        [HttpGet, Route("")]
        public IActionResult Get([FromQuery] string customerId)
        {
            CustomerDto customers = customerBiz.GetCustomersById(customerId);
           
            return Ok(customers);
        }
    }
}

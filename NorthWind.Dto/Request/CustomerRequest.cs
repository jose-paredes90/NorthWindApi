using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Dto.Request
{
    public class CustomerRequest
    {
        //request es lo que quieres recibir
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }       
        public string Phone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Dto
{
    public class CustomerDto
    {
        //Dto es lo que quieres devolver
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}

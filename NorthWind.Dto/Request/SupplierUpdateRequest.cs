using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Dto.Request
{
    public class SupplierUpdateRequest
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }   
}

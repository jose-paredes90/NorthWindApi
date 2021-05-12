using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Dto.Request
{
    public class SupplierRequest
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
    }
}

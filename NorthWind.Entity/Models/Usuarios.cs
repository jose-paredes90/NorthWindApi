using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NorthWind.Entity.Models
{
    public partial class Usuarios
    {
        public int UserId { get; set; }
        public int? EmployeesId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Employees Employees { get; set; }
    }
}

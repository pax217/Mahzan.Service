using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.EntitiesExtensions
{
    public partial class EmployeesExtension: Employees
    {
        public Guid? RoleId { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }
    }
}

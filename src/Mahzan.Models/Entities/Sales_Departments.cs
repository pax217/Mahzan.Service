using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Sales_Departments
    {
        public Guid SaleDepartmentId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Guid MemberId { get; set; }
    }
}

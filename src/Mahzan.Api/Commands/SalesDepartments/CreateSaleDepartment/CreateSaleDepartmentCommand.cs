using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.SalesDepartments.CreateSaleDepartment
{
    public class CreateSaleDepartmentCommand
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid MemberId { get; set; }
    }
}

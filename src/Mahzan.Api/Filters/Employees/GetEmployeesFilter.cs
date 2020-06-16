using Mahzan.Api.Filters._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Filters.Employees
{
    public class GetEmployeesFilter: BaseFilter
    {
        public Guid? EmployeeId { get; set; }
        public string CodeEmployee { get; set; }
        public string FirstName { get; set; }
    }
}

using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Employees
{
    public class GetEmployeesDto:BaseDto
    {
        public Guid? EmployeeId { get; set; }
        public string CodeEmployee { get; set; }
        public string FirstName { get; set; }
    }
}

using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Employees
{
    public class CreateEmployeeDto: BaseDto
    {
        public string CodeEmploye { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string SureName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Guid RoleId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}

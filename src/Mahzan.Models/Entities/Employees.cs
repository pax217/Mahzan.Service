using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Employees
    {
        public Guid EmployeeId { get; set; }

        public string CodeEmployee { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string SureName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Guid MemberId { get; set; }
        public Guid UserId { get; set; }
    }
}

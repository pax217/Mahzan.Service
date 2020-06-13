using Mahzan.Business.Events._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Employees
{
    public class CreateEmployeeEvent:BaseEvent
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.Exceptions.Employees.CreateEmployee
{
    public class CreateEmployeeArgumentException : ArgumentException
    {
        public CreateEmployeeArgumentException(string message) : base(message)
        {
        }
    }
}

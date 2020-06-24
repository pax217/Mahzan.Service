using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.Exceptions.Companies.CreateCompany
{
    public class CreateCompanyArgumentException : ArgumentException
    {
        public CreateCompanyArgumentException(string message) : base(message)
        {
        }
    }
}

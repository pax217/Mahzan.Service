using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Companies.CreateCompany
{
    public class CreateCompanyCommand
    {
        public Company Company { get; set; }

        public CompanyAdress CompanyAdress { get; set; }

        public CompanyContact CompanyContact { get; set; }
    }


}

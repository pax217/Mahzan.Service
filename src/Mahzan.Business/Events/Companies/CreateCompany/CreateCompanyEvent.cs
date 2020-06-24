using Mahzan.Business.Events._Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Events.Companies.CreateCompany
{
    public class CreateCompanyEvent:BaseEvent
    {
        public CompanyEvent CompanyEvent { get; set; }

        public CompanyAdressEvent CompanyAdressEvent { get; set; }

        public CompanyContactEvent CompanyContactEvent { get; set; }
    }
}

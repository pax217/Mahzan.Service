using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Companies.CreateCompany
{
    public class CompanyAdressEvent
    {

        public string Street { get; set; }

        public string Number { get; set; }

        public string InternalNumber { get; set; }

        public string PostalCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Companies.CreateCompany
{
    public class CompanyContactEvent
    {
        public string ContactName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string WebSite { get; set; }
    }
}

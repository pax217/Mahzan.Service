using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Companies.CreateCompany
{
    public class CompanyEvent
    {
        public string RFC { get; set; }

        public string ComercialName { get; set; }

        public string BusinessName { get; set; }

        public Guid GroupId { get; set; }
    }
}

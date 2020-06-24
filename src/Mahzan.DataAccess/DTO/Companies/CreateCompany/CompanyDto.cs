using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Companies.CreateCompany
{
    public class CompanyDto
    {
        public string RFC { get; set; }

        public string ComercialName { get; set; }

        public string BusinessName { get; set; }

        public Guid GroupId { get; set; }
    }
}

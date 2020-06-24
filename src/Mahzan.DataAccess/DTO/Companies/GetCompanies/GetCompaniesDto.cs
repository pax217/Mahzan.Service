using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Companies.GetCompanies
{
    public class GetCompaniesDto:BaseDto
    {
        public Guid? CompanyId { get; set; }

        public string CommercialName { get; set; }
    }
}

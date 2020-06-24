using Mahzan.Api.Filters._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Filters.Companies
{
    public class GetCompaniesFilter: BaseFilter
    {
        public Guid? CompanyId { get; set; }

        public string CommercialName { get; set; }
    }
}

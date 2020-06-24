using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Companies
    {
        public Guid CompanyId { get; set; }

        public string RFC { get; set; }

        public string CommercialName { get; set; }

        public string BusinessName { get; set; }

        public bool Active { get; set; }

        public Guid GroupId { get; set; }

        public Guid MemberId { get; set; }
    }
}

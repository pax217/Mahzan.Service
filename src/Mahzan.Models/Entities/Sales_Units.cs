using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Sales_Units
    {
        public Guid SaleUnitId { get; set; }

        public string Abbreviation { get; set; }

        public string Description { get; set; }

        public Guid MemberId { get; set; }

        public Guid Store { get; set; }
    }
}

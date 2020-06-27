using Mahzan.Api.Filters._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Filters.PointsOfSale
{
    public class GetPointsOfSaleFilter: BaseFilter
    {
        public Guid? PointOfSaleId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}

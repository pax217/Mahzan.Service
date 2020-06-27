using Mahzan.Business.Events._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.PointsOfSale
{
    public class CreatePointOfSaleEvent:BaseEvent
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid StoreId { get; set; }
    }
}

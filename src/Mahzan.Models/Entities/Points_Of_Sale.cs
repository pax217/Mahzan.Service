using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Points_Of_Sale
    {
        public Guid PointOfSale { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public Guid StoreId { get; set; }

        public Guid MemberId { get; set; }
    }
}

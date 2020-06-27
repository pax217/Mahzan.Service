using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.PointsOfSale.CreatePointOfSale
{
    public class CreatePointOfSaleDto:BaseDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid StoreId { get; set; }
    }
}

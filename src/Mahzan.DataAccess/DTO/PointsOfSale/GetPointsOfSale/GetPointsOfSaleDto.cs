using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.PointsOfSale.GetPointsOfSale
{
    public class GetPointsOfSaleDto:BaseDto
    {
        public Guid? PointOfSaleId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}

using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.SalesUnits.CreateSaleUnit
{
    public  class CreateSaleUnitDto:BaseDto
    {
        public string Abreviation { get; set; }

        public string Description { get; set; }

        public Guid StoreId { get; set; }
    }
}

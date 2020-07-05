using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Products
    {
        public Guid ProductId { get; set; }

        public string Code { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Price  { get; set; }

        public decimal Cost { get; set; }

        public decimal ComercialMargin { get; set; }

        public decimal ComercialMarginPercentaje { get; set; }

        public bool FollowInventory { get; set; }

        public bool AviableInAllStores { get; set; }

        public Guid? SaleDepartmentId { get; set; }

        public Guid? SaleAreaId { get; set; }

        public Guid? SeleSectionId { get; set; }

        public Guid? SaleCategotyId { get; set; }

        public Guid? SaleUnitId { get; set; }

        public Guid MemberId { get; set; }

        public bool Active { get; set; }
    }
}

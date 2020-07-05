using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Products.CreateProduct
{
    public class CreateProductDetailDto
    {
        public string Code { get; set; }


        public string Barcode { get; set; }


        public string Description { get; set; }


        public decimal Price { get; set; }


        public decimal Cost { get; set; }
    }
}

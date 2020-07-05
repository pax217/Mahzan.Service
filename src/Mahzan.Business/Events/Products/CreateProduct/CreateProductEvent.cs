using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Products.CreateProduct
{
    public class CreateProductEvent
    {
        public CreateProductDetailEvent CreateProductDetailEvent { get; set; }
        public CreateProductPhotoEvent CreateProductPhotoEvent { get; set; }


    }
}

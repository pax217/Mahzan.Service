using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Products.CreateProduct
{
    public class CreateProductDto
    {
        public CreateProductDetailDto CreateProductDetailDto { get; set; }

        public CreateProductPhotoDto CreateProductPhotoDto { get; set; }
    }
}

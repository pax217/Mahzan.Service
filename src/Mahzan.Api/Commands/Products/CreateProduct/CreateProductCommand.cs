using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Products.CreateProduct
{
    public class CreateProductCommand
    {

        public CreateProductDetailCommand ProductDetailCommand { get; set; }

        public CreateProductPhotoCommand ProductPhotoCommand { get; set; }
    }
}

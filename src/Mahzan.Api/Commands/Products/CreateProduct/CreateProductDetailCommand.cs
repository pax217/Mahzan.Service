using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Products.CreateProduct
{
    public class CreateProductDetailCommand
    {
        [MaxLength(15, ErrorMessage = "logitud maxima de 15")]
        public string Code { get; set; }

        [MaxLength(15, ErrorMessage = "logitud maxima de 15")]
        public string Barcode { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "logitud maxima de 30")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}

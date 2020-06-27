using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.PointsOfSale.CreatePointOfSale
{
    public class CreatePointOfSaleCommand
    {

        [MaxLength(10, ErrorMessage = "logitud maxima de 10")]
        public string Code { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string Name { get; set; }

        [Required]
        public Guid StoreId { get; set; }

    }
}

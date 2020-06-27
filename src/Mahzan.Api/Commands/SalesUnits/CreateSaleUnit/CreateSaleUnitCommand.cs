using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.SalesUnits.CreateSaleUnit
{
    public class CreateSaleUnitCommand
    {
        [Required]
        [MaxLength(5, ErrorMessage = "logitud maxima de 5")]
        public string Abreviation { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string Description { get; set; }

        [Required]
        public Guid StoreId { get; set; }
    }
}

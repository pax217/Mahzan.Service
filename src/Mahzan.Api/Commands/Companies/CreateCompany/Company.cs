using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Companies.CreateCompany
{
    public class Company
    {
        [Required]
        [MaxLength(13, ErrorMessage = "logitud maxima de 13")]
        public string RFC { get; set; }

        [MaxLength(50, ErrorMessage = "logitud maxima de 50")]
        public string ComercialName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "logitud maxima de 50")]
        public string BusinessName { get; set; }

        [Required]
        public Guid GroupId { get; set; }

    }
}

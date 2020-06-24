using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Companies.CreateCompany
{
    public class CompanyAdress
    {
        [Required]
        [MaxLength(50, ErrorMessage = "logitud maxima de 50")]
        public string Street { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "logitud maxima de 10")]
        public string Number { get; set; }

        [MaxLength(10, ErrorMessage = "logitud maxima de 10")]
        public string InternalNumber { get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = "logitud maxima de 5")]
        public string PostalCode { get; set; }


    }
}

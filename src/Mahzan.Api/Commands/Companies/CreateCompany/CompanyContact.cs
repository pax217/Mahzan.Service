using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Companies.CreateCompany
{
    public class CompanyContact
    {
        [Required]
        [MaxLength(50, ErrorMessage = "logitud maxima de 50")]
        public string ContactName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "logitud maxima de 50")]
        public string Email { get; set; }

        [Required]
        [MaxLength(18, ErrorMessage = "logitud maxima de 18")]
        public string Phone { get; set; }

        [MaxLength(250, ErrorMessage = "logitud maxima de 250")]
        public string WebSite { get; set; }

    }
}

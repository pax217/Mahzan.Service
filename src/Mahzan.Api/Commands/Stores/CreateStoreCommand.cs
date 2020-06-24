using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Stores
{
    public class CreateStoreCommand
    {
        [MaxLength(10, ErrorMessage = "logitud maxima de 10")]
        public string Code { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "logitud maxima de 50")]
        public string Name { get; set; }

        [MaxLength(18, ErrorMessage = "logitud maxima de 18")]
        public string Phone { get; set; }

        [MaxLength(100, ErrorMessage = "logitud maxima de 100")]
        public string Comment { get; set; }

        [Required]
        public Guid CompanyId { get; set; }
    }
}

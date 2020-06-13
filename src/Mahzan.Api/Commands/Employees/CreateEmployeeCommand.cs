using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Employees
{
    public class CreateEmployeeCommand
    {

        public string CodeEmploye { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string FirstName { get; set; }

        public string SecondName { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string SureName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "logitud maxima de 50")]
        public string Email { get; set; }

        [MaxLength(18, ErrorMessage = "logitud maxima de 18")]
        public string Phone { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string Password { get; set; }
    }
}

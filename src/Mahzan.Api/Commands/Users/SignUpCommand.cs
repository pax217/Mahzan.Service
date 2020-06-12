using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Users
{
    public class SignUpCommand
    {
        [Required]
        [MaxLength(25,ErrorMessage ="logitud maxima de 25")]
        public string Name { get; set; }
        [Required]
        [MaxLength(18, ErrorMessage = "logitud maxima de 18")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string Email { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "logitud maxima de 25")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Users
{
    public class LoginCommand
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}

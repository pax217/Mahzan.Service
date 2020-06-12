using Mahzan.DataAccess.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Users.Login
{
    public  interface ILoginRules
    {
        Task HandleRules(LoginDto loginDto);
    }
}

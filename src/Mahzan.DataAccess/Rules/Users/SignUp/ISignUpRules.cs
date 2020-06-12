using Mahzan.DataAccess.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Users.SignUp
{
    public interface ISignUpRules
    {
        Task HandleRules(SignUpDto signUpDto);
    }
}

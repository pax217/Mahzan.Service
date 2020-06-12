using Mahzan.DataAccess.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Users.SignUp
{
    public interface ISignUpRepository
    {
        Task<Models.Entities.Users> HandleRepository(SignUpDto signUpDto);
    }
}

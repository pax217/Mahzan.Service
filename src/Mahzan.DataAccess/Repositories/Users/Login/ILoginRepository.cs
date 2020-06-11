using Mahzan.DataAccess.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Users.Login
{
    public interface ILoginRepository
    {
        Task<Models.Entities.Users> HandleRepository(LoginDto loginDto);
    }
}

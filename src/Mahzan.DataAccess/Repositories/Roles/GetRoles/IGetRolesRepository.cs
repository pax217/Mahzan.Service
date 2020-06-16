using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Roles.GetRoles
{
    public interface IGetRolesRepository
    {
        Task<List<Models.Entities.Roles>> HandleRepository();
    }
}

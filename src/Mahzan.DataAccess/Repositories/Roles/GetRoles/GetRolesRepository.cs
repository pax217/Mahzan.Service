using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Roles.GetRoles
{
    public class GetRolesRepository : DataConnection, IGetRolesRepository
    {
        public GetRolesRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Models.Entities.Roles>> HandleRepository()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from roles ");
            sql.Append("where name not in('MEMBER') ");

            IEnumerable<Models.Entities.Roles> roles;
            roles = await Connection
                .QueryAsync<Models.Entities.Roles>(
                    sql.ToString()
                );

            return roles.ToList();
        }
    }
}

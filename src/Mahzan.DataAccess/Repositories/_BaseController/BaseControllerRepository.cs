using Dapper;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories._BaseController
{
    public class BaseControllerRepository : DataConnection, IBaseControllerRepository
    {
        public BaseControllerRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public User_Role GetRole(string userName)
        {


            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from user_role ");
            sql.Append("Inner Join users on users.user_id = user_role.user_id ");
            sql.Append("where users.user_name = @user_name ");

            IEnumerable<User_Role> role;
            role = Connection
                .Query<User_Role>(
                    sql.ToString(),
                    new
                    {
                        user_name = userName
                    }
                );


            return role.FirstOrDefault();
        }
    }
}

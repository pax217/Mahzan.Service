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

        public Members GetMember(string userName)
        {
            IEnumerable<Members> members;

            StringBuilder sqlUsers = new StringBuilder();
            sqlUsers.Append("Select * from users ");
            sqlUsers.Append("where user_name = @user_name ");
            sqlUsers.Append("limit 1 ");
            

            IEnumerable<Models.Entities.Users> users;
            users = Connection
                .Query<Models.Entities.Users>(
                    sqlUsers.ToString(),
                    new
                    {
                        user_name = userName
                    }
                );

            StringBuilder sqlMembers = new StringBuilder();
            sqlMembers.Append("Select * from members ");
            sqlMembers.Append("where user_id = @user_id ");

            members = Connection
                .Query<Members>(
                    sqlMembers.ToString(),
                    new {
                        user_id = users.FirstOrDefault().UserPatternId!=null? users.FirstOrDefault().UserPatternId: users.FirstOrDefault().UserId
                    }
                );

            return members.FirstOrDefault();
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

        public Models.Entities.Users GetUser(string userName)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from users ");
            sql.Append("where user_name = @user_name ");

            IEnumerable<Models.Entities.Users> users;
            users = Connection
                .Query<Models.Entities.Users>(
                    sql.ToString(),
                    new
                    {
                        user_name = userName
                    }
                );




            return users.FirstOrDefault();
        }
    }
}

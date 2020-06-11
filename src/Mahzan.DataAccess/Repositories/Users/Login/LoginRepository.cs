﻿using Mahzan.DataAccess.DTO.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace Mahzan.DataAccess.Repositories.Users.Login
{
    public class LoginRepository : DataConnection, ILoginRepository
    {
        public LoginRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.Users> HandleRepository(LoginDto loginDto)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select  * ");
            sql.Append("From    users ");
            sql.Append("Where   user_name = @user_name ");
            sql.Append("And     password = @password");

            IEnumerable<Models.Entities.Users> users;
            users = await Connection
                .QueryAsync<Models.Entities.Users>(
                    sql.ToString(),
                    new
                    {
                        user_name = loginDto.UserName,
                        password = loginDto.Password
                    }
                );

            return users.FirstOrDefault();
        }
    }
}
using Dapper;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.Rules.Employees.CreateEmployee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Employees.CreateEmployee
{
    public class CreateEmployeeRepository : DataConnection, ICreateEmployeeRepository
    {

        private readonly ICreateEmployeeRules _createEmployeeRules;

        public CreateEmployeeRepository(
            IDbConnection dbConnection, 
            ICreateEmployeeRules createEmployeeRules) : base(dbConnection)
        {
            _createEmployeeRules = createEmployeeRules;
        }

        public async Task<Models.Entities.Users> HandleRepository(CreateEmployeeDto createEmployeeDto)
        {
            //Rules
            await _createEmployeeRules
                .HandleRules(createEmployeeDto);

            Models.Entities.Users user;

            using (var transaction = Connection.BeginTransaction())
            {
                Guid userId = await CreateUser(createEmployeeDto);

                await CreateUserRole(userId,createEmployeeDto);

                await CreateEmployee(userId, createEmployeeDto);

                user = await GetUser(userId);

                transaction.Commit();
            };


            return user;
        }

        public async Task<Guid> CreateUser(CreateEmployeeDto createEmployeeDto) 
        {

            StringBuilder insertUser = new StringBuilder();
            insertUser.Append("Insert into users ");
            insertUser.Append("(");
            insertUser.Append("user_id,");
            insertUser.Append("user_name,");
            insertUser.Append("password,");
            insertUser.Append("active,");
            insertUser.Append("confirm_email,");
            insertUser.Append("token_confirm_email,");
            insertUser.Append("user_pattern_id,");
            insertUser.Append("email");
            insertUser.Append(") ");
            insertUser.Append("Values ");
            insertUser.Append("(");
            insertUser.Append("@user_id,");
            insertUser.Append("@user_name,");
            insertUser.Append("@password,");
            insertUser.Append("@active,");
            insertUser.Append("@confirm_email,");
            insertUser.Append("@token_confirm_email,");
            insertUser.Append("@user_pattern_id,");
            insertUser.Append("@email");
            insertUser.Append(") ");
            insertUser.Append("RETURNING user_id; ");


            Guid userId = await Connection
                .ExecuteScalarAsync<Guid>(
                    insertUser.ToString(),
                    new
                    {
                        user_id = Guid.NewGuid(),
                        user_name = createEmployeeDto.UserName,
                        password = createEmployeeDto.Password,
                        active = true,
                        confirm_email = false,
                        token_confirm_email = Guid.NewGuid(),
                        user_pattern_id = createEmployeeDto.UserId,
                        email = createEmployeeDto.Email
                    }
                );

            return userId;
        }

        public async Task CreateUserRole(Guid userId, CreateEmployeeDto createEmployeeDto) 
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into user_role ");
            sql.Append("(");
            sql.Append("user_id,");
            sql.Append("role_id");
            sql.Append(") ");
            sql.Append("Values ");
            sql.Append("(");
            sql.Append("@user_id,");
            sql.Append("@role_id");
            sql.Append(") ");


            await Connection
                .ExecuteAsync(
                    sql.ToString(),
                    new
                    {
                        user_id = userId,
                        role_id = createEmployeeDto.RoleId,
                    }
                );

        }

        public async Task CreateEmployee(Guid userId,CreateEmployeeDto createEmployeeDto)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into employees ");
            sql.Append("(");
            sql.Append("employee_id,");
            sql.Append("code_employee,");
            sql.Append("first_name,");
            sql.Append("second_name,");
            sql.Append("last_name,");
            sql.Append("sure_name,");
            sql.Append("email,");
            sql.Append("phone,");
            sql.Append("member_id,");
            sql.Append("user_id");
            sql.Append(") ");
            sql.Append("Values ");
            sql.Append("(");
            sql.Append("@employee_id,");
            sql.Append("@code_employee,");
            sql.Append("@first_name,");
            sql.Append("@second_name,");
            sql.Append("@last_name,");
            sql.Append("@sure_name,");
            sql.Append("@email,");
            sql.Append("@phone,");
            sql.Append("@member_id,");
            sql.Append("@user_id");
            sql.Append(") ");

            await Connection
                .ExecuteAsync(
                    sql.ToString(),
                    new
                    {
                        employee_id = Guid.NewGuid(),
                        code_employee = createEmployeeDto.CodeEmploye,
                        first_name = createEmployeeDto.FirstName,
                        second_name = createEmployeeDto.SecondName,
                        last_name = createEmployeeDto.LastName,
                        sure_name = createEmployeeDto.SureName,
                        email = createEmployeeDto.Email,
                        phone = createEmployeeDto.Phone,
                        member_id = createEmployeeDto.MemberId,
                        user_id = userId
                    }); 
        }

        public async Task<Models.Entities.Users> GetUser(Guid userId) 
        {
            StringBuilder sqlUser = new StringBuilder();
            sqlUser.Append("Select * from Users ");
            sqlUser.Append("Where user_id = @user_id ");

            IEnumerable<Models.Entities.Users> user;
            user = await Connection
                .QueryAsync<Models.Entities.Users>(
                    sqlUser.ToString(),
                    new
                    {
                        user_id = userId
                    }
                );

            return user.FirstOrDefault();
        }
    }
}

using Dapper;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.Exceptions.Employees.CreateEmployee;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Employees.CreateEmployee
{
    public class CreateEmployeeRules : DataConnection,ICreateEmployeeRules
    {
        public CreateEmployeeRules(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task HandleRules(CreateEmployeeDto createEmployeeDto)
        {
            //Valida el Codigo de Empleado
            if (createEmployeeDto.CodeEmploye!=null)
            {
                if (await CodeEmployeeExist(createEmployeeDto))
                {
                    throw new CreateEmployeeArgumentException(
                        $"El codigo de empleado {createEmployeeDto.CodeEmploye} ya existe."
                        );
                }
            }

            //Valida el Email del Empleado
            if (await EmployeeEmailExist(createEmployeeDto))
            {
                throw new CreateEmployeeArgumentException(
                    $"El email de empleado {createEmployeeDto.Email} ya existe."
                    );
            }

            //Valida el Email de Usuario
            if (await UserEmailExist(createEmployeeDto))
            {
                throw new CreateEmployeeArgumentException(
                    $"El email de usuario {createEmployeeDto.Email} ya existe."
                    );
            }

            //Valida el nombre completo del empleado
            if (await CompleteNameExist(createEmployeeDto))
            {
                throw new CreateEmployeeArgumentException(
                    $"El empleado ya existe."
                    );
            }

            //Valida que el RoleIdExista

            if (!await RoleIdExist(createEmployeeDto.RoleId))
            {
                throw new CreateEmployeeArgumentException(
                    $"El role_id {createEmployeeDto.RoleId} no existe."
                    );
            }
        }

        public async Task<bool> CodeEmployeeExist(CreateEmployeeDto createEmployeeDto) 
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from employees ");
            sql.Append("Where member_id = @member_id ");
            sql.Append("And code_employee = @code_employee ");

            IEnumerable<Models.Entities.Employees> employees;
            employees = await Connection
                .QueryAsync<Models.Entities.Employees>(
                    sql.ToString(),
                    new {
                        member_id = createEmployeeDto.MemberId,
                        code_employee = createEmployeeDto.CodeEmploye
                    }
                );

            if (employees.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> EmployeeEmailExist(CreateEmployeeDto createEmployeeDto)
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from employees ");
            sql.Append("Where member_id = @member_id ");
            sql.Append("And email = @email ");

            IEnumerable<Models.Entities.Employees> employees;
            employees = await Connection
                .QueryAsync<Models.Entities.Employees>(
                    sql.ToString(),
                    new
                    {
                        member_id = createEmployeeDto.MemberId,
                        email = createEmployeeDto.Email
                    }
                );

            if (employees.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> CompleteNameExist(CreateEmployeeDto createEmployeeDto)
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from employees ");
            sql.Append("Where member_id = @member_id ");
            sql.Append("And first_name = @first_name ");
            sql.Append("And second_name = @second_name ");
            sql.Append("And last_name = @last_name ");
            sql.Append("And sure_name = @sure_name ");

            IEnumerable<Models.Entities.Employees> employees;
            employees = await Connection
                .QueryAsync<Models.Entities.Employees>(
                    sql.ToString(),
                    new
                    {
                        member_id = createEmployeeDto.MemberId,
                        first_name = createEmployeeDto.FirstName,
                        second_name = createEmployeeDto.SecondName,
                        last_name = createEmployeeDto.LastName,
                        sure_name = createEmployeeDto.SureName
                    }
                );

            if (employees.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UserEmailExist(CreateEmployeeDto createEmployeeDto)
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from users ");
            sql.Append("Where email = @email ");

            IEnumerable<Models.Entities.Users> employees;
            employees = await Connection
                .QueryAsync<Models.Entities.Users>(
                    sql.ToString(),
                    new
                    {
                        email = createEmployeeDto.Email
                    }
                );

            if (employees.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> RoleIdExist(Guid roleId)
        {
            {
                bool result = false;

                StringBuilder sql = new StringBuilder();
                sql.Append("Select * from roles ");
                sql.Append("Where role_id = @role_id ");

                IEnumerable<Models.Entities.Roles> roles;
                roles = await Connection
                    .QueryAsync<Models.Entities.Roles>(
                        sql.ToString(),
                        new
                        {
                            role_id = roleId
                        }
                    );

                if (roles.Any())
                {
                    result = true;
                }

                return result;
            }
        }
    }
}

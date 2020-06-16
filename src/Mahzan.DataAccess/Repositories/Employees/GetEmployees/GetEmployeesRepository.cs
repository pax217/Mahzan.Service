using Dapper;
using Mahzan.DataAccess.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Employees.GetEmployees
{
    public class GetEmployeesRepository :DataConnection, IGetEmployeesRepository
    {
        public GetEmployeesRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Models.EntitiesExtensions.EmployeesExtension>> HandleRepository(GetEmployeesDto getEmployeesDto)
        {
            DynamicParameters parameters = new DynamicParameters();

            StringBuilder sql = new StringBuilder();
            sql.Append("Select ");
            sql.Append("        employees.employee_id,");
            sql.Append("        employees.code_employee,");
            sql.Append("        employees.first_name,");
            sql.Append("        employees.second_name,");
            sql.Append("        employees.last_name,");
            sql.Append("        employees.sure_name,");
            sql.Append("        employees.email,");
            sql.Append("        employees.phone,");
            sql.Append("        employees.member_id,");
            sql.Append("        employees.user_id, ");
            sql.Append("        \"users\".user_name, ");
            sql.Append("        \"users\".password, ");
            sql.Append("        roles.role_id ");
            sql.Append("from    employees ");
            sql.Append("inner join  \"users\" on  \"users\".user_id = employees.user_id ");
            sql.Append("inner join user_role on user_role.user_id = \"users\".user_id ");
            sql.Append("inner join roles on roles.role_id = user_role.role_id ");
            sql.Append("Where   1= 1 ");

            if (getEmployeesDto.MemberId!=null)
            {
                sql.Append("And member_id = @member_id ");
                parameters.Add("@member_id", getEmployeesDto.MemberId, DbType.Guid);
            }

            if (getEmployeesDto.EmployeeId != null)
            {
                sql.Append("And employee_id = @employee_id ");
                parameters.Add("@employee_id", getEmployeesDto.EmployeeId, DbType.Guid);
            }

            if (getEmployeesDto.CodeEmployee != null)
            {
                sql.Append("And code_employee = @code_employee ");
                parameters.Add("@code_employee", getEmployeesDto.CodeEmployee, DbType.String);
            }

            if (getEmployeesDto.FirstName != null)
            {
                sql.Append("And first_name = @first_name ");
                parameters.Add("@first_name", getEmployeesDto.FirstName, DbType.String);
            }


            IEnumerable<Models.EntitiesExtensions.EmployeesExtension> employees = await Connection
                .QueryAsync<Models.EntitiesExtensions.EmployeesExtension>(
                    sql.ToString(),
                    parameters
                );

            return employees.ToList();
        }
    }
}

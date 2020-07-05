using Dapper;
using Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull;
using Mahzan.DataAccess.Exceptions.SalesDepartments.CreateSalesDepartmentsFull;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.SalesDepartments.CreateSalesDepartmentsFull
{
    public class CreateSalesDepartmentsFullRules : DataConnection,ICreateSalesDepartmentsFullRules
    {
        public CreateSalesDepartmentsFullRules(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task HandleRules(
            CreateSalesDepartmentsFullDto createSalesDepartmentsFullDto,
            Guid memberId)
        {
            //Valida que no existan los departamentos
            foreach (var createSalesDepartmentFullDto in createSalesDepartmentsFullDto.ListCreateSalesDepartmentFullDto)
            {
                if (await DepartmentExist(
                    createSalesDepartmentFullDto,
                    memberId))
                {
                    throw new CreateSalesDepartmentsFullArgumentException(
                        $"El departamento {createSalesDepartmentFullDto.Name} ya existe."
                        );
                }
            }
        }


        public async Task<bool> DepartmentExist(
            CreateSalesDepartmentFullDto createSalesDepartmentFullDto,
            Guid memberId) 
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from sales_departments ");
            sql.Append("where member_id = @member_id ");
            sql.Append("and name = @name ");

            IEnumerable<Models.Entities.Sales_Departments> salesDepartments;
            salesDepartments = await Connection
                .QueryAsync<Models.Entities.Sales_Departments>(
                    sql.ToString(),
                    new {
                        member_id = memberId,
                        name = createSalesDepartmentFullDto.Name
                    }
                );

            if (salesDepartments.Any())
            {
                result = true;
            }

            return result;
        }
    }
}

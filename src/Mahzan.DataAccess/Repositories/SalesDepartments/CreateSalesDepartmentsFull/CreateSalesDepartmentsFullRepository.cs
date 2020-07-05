using Dapper;
using Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull;
using Mahzan.DataAccess.Rules.SalesDepartments.CreateSalesDepartmentsFull;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.SalesDepartments.CreateSalesDepartmentsFull
{
    public class CreateSalesDepartmentsFullRepository : DataConnection,ICreateSalesDepartmentsFullRepository
    {
        private readonly ICreateSalesDepartmentsFullRules _createSalesDepartmentsFullRules;


        #region Constructors

        public CreateSalesDepartmentsFullRepository(
            IDbConnection dbConnection,
            ICreateSalesDepartmentsFullRules createSalesDepartmentsFullRules) : base(dbConnection)
        {
            _createSalesDepartmentsFullRules = createSalesDepartmentsFullRules;
        }

        #endregion

        #region Public Methods
        public async Task HandleRepository(
            CreateSalesDepartmentsFullDto createSalesDepartmentsFullDto,
            Guid memberId)
        {

            //Rules
            await _createSalesDepartmentsFullRules
                .HandleRules(
                    createSalesDepartmentsFullDto,
                    memberId
                );

            using (var transaction = Connection.BeginTransaction())
            {
                foreach (var createSaleDepartmentFullDto in createSalesDepartmentsFullDto.ListCreateSalesDepartmentFullDto)
                {
                    //Crea Departamento full
                    await CreateSaleDapartment(
                        createSaleDepartmentFullDto,
                        memberId);

                }

                transaction.Commit();
            }
        }

        #endregion

        #region Private Methods

        private async Task CreateSaleDapartment(
            CreateSalesDepartmentFullDto createSalesDepartmentFullDto,
            Guid memberId) 
        {


            StringBuilder sql = new StringBuilder();
            sql.Append("insert into sales_departments ");
            sql.Append("(");
            sql.Append("sale_department_id,");
            sql.Append("code,");
            sql.Append("name,");
            sql.Append("member_id");
            sql.Append(")"); 
            sql.Append("values ");
            sql.Append("(");
            sql.Append("@sale_department_id,");
            sql.Append("@code,");
            sql.Append("@name,");
            sql.Append("@member_id");
            sql.Append(")");
            sql.Append("returning sale_department_id;");

            Guid saleDepartmentId = await Connection
                .ExecuteScalarAsync<Guid>(
                    sql.ToString(),
                    new {
                        sale_department_id = Guid.NewGuid(),
                        code = createSalesDepartmentFullDto.Code,
                        name = createSalesDepartmentFullDto.Name,
                        member_id = memberId
                    }
                );

            if (createSalesDepartmentFullDto.ListCreateSaleAreasFullDto.Any())
            {
                foreach (var createSaleAreasFullDto in createSalesDepartmentFullDto.ListCreateSaleAreasFullDto)
                {
                    //Create Area
                    await CreateSaleArea(
                        createSaleAreasFullDto, 
                        saleDepartmentId,
                        memberId);
                }
            }

        }

        private async Task CreateSaleArea(
            CreateSaleAreasFullDto createSaleAreasFullDto,
            Guid saleDepartmentId,
            Guid memberId) 
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into sales_areas ");
            sql.Append("(");
            sql.Append("sale_area_id,");
            sql.Append("code,");
            sql.Append("name,");
            sql.Append("member_id,");
            sql.Append("sale_department_id");
            sql.Append(")");
            sql.Append("values ");
            sql.Append("(");
            sql.Append("@sale_area_id,");
            sql.Append("@code,");
            sql.Append("@name,");
            sql.Append("@member_id,");
            sql.Append("@sale_department_id");
            sql.Append(")");
            sql.Append("returning sale_area_id;");


            Guid saleAreaId = await Connection
                .ExecuteScalarAsync<Guid>(
                    sql.ToString(),
                    new
                    {
                        sale_area_id= Guid.NewGuid(),
                        code = createSaleAreasFullDto.Code,
                        name = createSaleAreasFullDto.Name,
                        member_id = memberId,
                        sale_department_id = saleDepartmentId
                    }
                );

            if (createSaleAreasFullDto.ListCreateSalsesSectionsFullDto.Any())
            {
                foreach (var createSalsesSectionsFullDto in createSaleAreasFullDto.ListCreateSalsesSectionsFullDto)
                {
                    await CreateSaleSection(
                        createSalsesSectionsFullDto,
                        memberId,
                        saleAreaId
                        );
                }
            }

        }

        private async Task CreateSaleSection(
            CreateSalsesSectionsFullDto createSalsesSectionsFullDto,
            Guid memberId,
            Guid saleAreaId) 
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("insert into sales_sections ");
            sql.Append("(");
            sql.Append("sale_section_id,");
            sql.Append("code,");
            sql.Append("name,");
            sql.Append("member_id,");
            sql.Append("sale_area_id");
            sql.Append(")");
            sql.Append("values ");
            sql.Append("(");
            sql.Append("@sale_section_id,");
            sql.Append("@code,");
            sql.Append("@name,");
            sql.Append("@member_id,");
            sql.Append("@sale_area_id");
            sql.Append(") ");
            sql.Append("returning sale_section_id;");


            Guid saleSectionId = await Connection
                .ExecuteScalarAsync<Guid>(
                    sql.ToString(),
                    new
                    {
                        sale_section_id = Guid.NewGuid(),
                        code = createSalsesSectionsFullDto.Code,
                        name = createSalsesSectionsFullDto.Name,
                        member_id = memberId,
                        sale_area_id = saleAreaId
                    }
                );

            if (createSalsesSectionsFullDto.ListCreateSalesCategoriesFullDto.Any())
            {
                foreach (var createSalesCategoriesFullDto in createSalsesSectionsFullDto.ListCreateSalesCategoriesFullDto)
                {
                    await CreateSaleCategories(
                        createSalesCategoriesFullDto,
                        memberId,
                        saleSectionId);
                }
            }
        }

        private async Task CreateSaleCategories(
            CreateSalesCategoriesFullDto createSalesCategoriesFullDto,
            Guid memberId,
            Guid saleSectionId) 
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into sales_categories ");
            sql.Append("(");
            sql.Append("sale_category_id,");
            sql.Append("code,");
            sql.Append("name,");
            sql.Append("member_id,");
            sql.Append("sale_section_id");
            sql.Append(")");
            sql.Append("values ");
            sql.Append("(");
            sql.Append("@sale_category_id,");
            sql.Append("@code,");
            sql.Append("@name,");
            sql.Append("@member_id,");
            sql.Append("@sale_section_id");
            sql.Append(") ");
            sql.Append("returning sale_category_id;");

            await Connection
            .ExecuteScalarAsync<Guid>(
                sql.ToString(),
                new
                {
                    sale_category_id = Guid.NewGuid(),
                    code = createSalesCategoriesFullDto.Code,
                    name = createSalesCategoriesFullDto.Name,
                    member_id = memberId,
                    sale_section_id = saleSectionId
                }
            );
        }

        #endregion
    }
}

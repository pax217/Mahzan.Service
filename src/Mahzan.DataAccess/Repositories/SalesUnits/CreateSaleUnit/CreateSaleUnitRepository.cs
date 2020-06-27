using Dapper;
using Mahzan.DataAccess.DTO.SalesUnits.CreateSaleUnit;
using Mahzan.DataAccess.Rules.SalesUnits.CreateSaleUnit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.SalesUnits.CreateSaleUnit
{
    public class CreateSaleUnitRepository : DataConnection, ICreateSaleUnitRepository
    {
        private readonly ICreateSaleUnitRules _createSaleUnitRules;

        public CreateSaleUnitRepository(
            IDbConnection dbConnection, 
            ICreateSaleUnitRules createSaleUnitRules) : base(dbConnection)
        {
            _createSaleUnitRules = createSaleUnitRules;
        }

        public async Task HandleRepository(CreateSaleUnitDto createSaleUnitDto)
        {
            //Rules
            await _createSaleUnitRules
                .HandleRules(createSaleUnitDto);

            StringBuilder sql = new StringBuilder();
            sql.Append("insert into sales_units ");
            sql.Append("(");
            sql.Append("sale_unit_id,");
            sql.Append("abbreviation,");
            sql.Append("description,");
            sql.Append("member_id,");
            sql.Append("store_id");
            sql.Append(")");
            sql.Append("values ");
            sql.Append("(");
            sql.Append("@sale_unit_id,");
            sql.Append("@abbreviation,");
            sql.Append("@description,");
            sql.Append("@member_id,");
            sql.Append("@store_id");
            sql.Append(")");

            await Connection
                .ExecuteAsync(
                    sql.ToString(),
                    new
                    {
                        sale_unit_id = Guid.NewGuid(),
                        abbreviation = createSaleUnitDto.Abreviation,
                        description = createSaleUnitDto.Description,
                        member_id = createSaleUnitDto.MemberId,
                        store_id = createSaleUnitDto.StoreId,
                    }
                );


        }
    }
}

using Dapper;
using Mahzan.DataAccess.DTO.SalesUnits.CreateSaleUnit;
using Mahzan.DataAccess.Exceptions.SalesUnits.CreateSaleUnit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.SalesUnits.CreateSaleUnit
{
    public class CreateSaleUnitRules : DataConnection,ICreateSaleUnitRules
    {
        public CreateSaleUnitRules(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task HandleRules(CreateSaleUnitDto createSaleUnitDto)
        {
            //Abreviación de unidad exoste
            if (await AbbreviationExist(createSaleUnitDto))
            {
                throw new CreateSaleUnitArgumentException(
                    $"La abreviación {createSaleUnitDto.Abreviation} ya existe dentro de esta tienda."
                    );
            }

            //La tienda debe existir
            if (!await StoreIdExist(createSaleUnitDto))
            {
                throw new CreateSaleUnitArgumentException(
                    $"La tienda {createSaleUnitDto.StoreId} no existe."
                    );
            }
        }

        #region Rules

        public async Task<bool> AbbreviationExist(CreateSaleUnitDto createSaleUnitDto) 
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from sales_units ");
            sql.Append("where member_id = @member_id ");
            sql.Append("and store_id = @store_id ");
            sql.Append("and abbreviation = @abbreviation ");

            IEnumerable<Models.Entities.Sales_Units> salesUnits;
            salesUnits = await Connection
                .QueryAsync<Models.Entities.Sales_Units>(
                    sql.ToString(),
                    new {
                        member_id= createSaleUnitDto.MemberId,
                        store_id = createSaleUnitDto.StoreId,
                        abbreviation = createSaleUnitDto.Abreviation
                    }
                );

            if (salesUnits.Any())
            {
                result = true;
            }

            return result;
        
        }

        public async Task<bool> StoreIdExist(CreateSaleUnitDto createSaleUnitDto)
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from stores ");
            sql.Append("where member_id = @member_id ");
            sql.Append("and store_id = @store_id ");
            sql.Append("and active = true ");

            IEnumerable<Models.Entities.Stores> stores;
            stores = await Connection
                .QueryAsync<Models.Entities.Stores>(
                    sql.ToString(),
                    new
                    {
                        member_id = createSaleUnitDto.MemberId,
                        store_id = createSaleUnitDto.StoreId
                    }
                );

            if (stores.Any())
            {
                result = true;
            }

            return result;

        }

        #endregion
    }
}

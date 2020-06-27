using Dapper;
using Mahzan.DataAccess.DTO.PointsOfSale.CreatePointOfSale;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.PointsOfSale.CreatePointOfSale
{
    public class CreatePointOfSaleRepository : DataConnection,ICreatePointOfSaleRepository
    {
        public CreatePointOfSaleRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task HandleRepository(CreatePointOfSaleDto createPointOfSaleDto)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into points_of_sale ");
            sql.Append("( ");
            sql.Append("point_of_sale_id,");
            sql.Append("code,");
            sql.Append("name,");
            sql.Append("active,");
            sql.Append("store_id,");
            sql.Append("member_id ");
            sql.Append(") ");
            sql.Append("values ");
            sql.Append("( ");
            sql.Append("@point_of_sale_id,");
            sql.Append("@code,");
            sql.Append("@name,");
            sql.Append("@active,");
            sql.Append("@store_id,");
            sql.Append("@member_id ");
            sql.Append(") ");

            await Connection
                .ExecuteAsync(
                    sql.ToString(),
                    new {
                        point_of_sale_id = Guid.NewGuid(),
                        code = createPointOfSaleDto.Code,
                        name = createPointOfSaleDto.Name,
                        active = true,
                        store_id = createPointOfSaleDto.StoreId,
                        member_id = createPointOfSaleDto.MemberId
                    }
                );

        }
    }
}

using Dapper;
using Mahzan.DataAccess.DTO.PointsOfSale.GetPointsOfSale;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.PointsOfSale.GetPointsOfSale
{
    public class GetPointsOfSaleRepository : DataConnection,IGetPointsOfSaleRepository
    {
        public GetPointsOfSaleRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Points_Of_Sale>> HandleRepository(GetPointsOfSaleDto getPointsOfSaleDto)
        {
            DynamicParameters parameters = new DynamicParameters();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from points_of_sale ");
            sql.Append("where 1=1 ");

            //MembersId
            if (getPointsOfSaleDto.MemberId!=null)
            {
                sql.Append("and member_id = @member_id ");
                parameters.Add("@member_id", getPointsOfSaleDto.MemberId, DbType.Guid);
            }

            if (getPointsOfSaleDto.Code != null)
            {
                sql.Append("and code LIKE @code ");
                parameters.Add("@code", "%" + getPointsOfSaleDto.Code + "%", DbType.String);
            }

            if (getPointsOfSaleDto.Name != null)
            {
                sql.Append("and name LIKE @name ");
                parameters.Add("@name", "%" + getPointsOfSaleDto.Name + "%", DbType.String);
            }

            IEnumerable<Points_Of_Sale> pointsOfSale;
            pointsOfSale = await Connection
                .QueryAsync<Points_Of_Sale>(
                   sql.ToString(),
                    parameters
                );

            return pointsOfSale.ToList();
        }
    }
}

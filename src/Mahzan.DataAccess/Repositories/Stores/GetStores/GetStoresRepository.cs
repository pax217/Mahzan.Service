using Dapper;
using Mahzan.DataAccess.DTO.Stores.GetStores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Stores.GetStores
{
    public class GetStoresRepository : DataConnection, IGetStoresRepository
    {
        public GetStoresRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Models.Entities.Stores>> HandleRepository(GetStoresDto getStoresDto)
        {
            DynamicParameters parameters = new DynamicParameters();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from stores ");
            sql.Append("where 1 = 1 ");

            if (getStoresDto.MemberId != null)
            {
                sql.Append("and member_id = @member_id ");
                parameters.Add("@member_id", getStoresDto.MemberId , DbType.Guid);
            }

            if (getStoresDto.StoreId != null)
            {
                sql.Append("and store_id = @store_id ");
                parameters.Add("@store_id", getStoresDto.StoreId, DbType.Guid);
            }

            if (getStoresDto.Name != null)
            {
                sql.Append("and name LIKE @name ");
                parameters.Add("@name", "%" + getStoresDto.Name + "%", DbType.String);
            }

            IEnumerable<Models.Entities.Stores> stores;
            stores = await Connection
                .QueryAsync<Models.Entities.Stores>(
                    sql.ToString(),
                    parameters
                );

            return stores.ToList();
        }
    }
}

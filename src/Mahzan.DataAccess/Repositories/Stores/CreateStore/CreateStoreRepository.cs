using Dapper;
using Mahzan.DataAccess.DTO.Stores.CreateStore;
using Mahzan.DataAccess.Rules.Stores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Stores.CreateStore
{
    public class CreateStoreRepository : DataConnection,ICreateStoreRepository
    {

        private readonly ICreateStoreRules _createStoreRules;

        public CreateStoreRepository(
            IDbConnection dbConnection, 
            ICreateStoreRules createStoreRules) : base(dbConnection)
        {
            _createStoreRules = createStoreRules;
        }

        public async Task HandleRepository(CreateStoreDto createStoreDto)
        {
            //Rules
            await _createStoreRules
                .HandleRules(createStoreDto);

            StringBuilder sql = new StringBuilder();

            sql.Append("insert into stores ");
            sql.Append("(");
            sql.Append("store_id,");
            sql.Append("code,");
            sql.Append("name,");
            sql.Append("phone,");
            sql.Append("comment,");
            sql.Append("active,");
            sql.Append("company_id,");
            sql.Append("member_id");
            sql.Append(")");
            sql.Append("values ");
            sql.Append("(");
            sql.Append("@store_id,");
            sql.Append("@code,");
            sql.Append("@name,");
            sql.Append("@phone,");
            sql.Append("@comment,");
            sql.Append("@active,");
            sql.Append("@company_id,");
            sql.Append("@member_id");
            sql.Append(") ");

            await Connection
                .ExecuteAsync(
                   sql.ToString(),
                   new {
                       store_id= Guid.NewGuid(),
                       code = createStoreDto.Code,
                       name = createStoreDto.Name,
                       phone = createStoreDto.Phone,
                       comment = createStoreDto.Comment,
                       active = true,
                       company_id = createStoreDto.CompanyId,
                       member_id = createStoreDto.MemberId
                   }
                );
        }
    }
}

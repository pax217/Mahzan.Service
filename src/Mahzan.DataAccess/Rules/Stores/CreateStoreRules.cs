using Dapper;
using Mahzan.DataAccess.DTO.Stores.CreateStore;
using Mahzan.DataAccess.Exceptions.Stores.CreateStore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Stores
{
    public class CreateStoreRules : DataConnection, ICreateStoreRules
    {
        public CreateStoreRules(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task HandleRules(CreateStoreDto createStoreDto)
        {
            //Code
            if (await CodeExist(createStoreDto.MemberId, createStoreDto.Code))
            {
                throw new CreateStoreArgumentException(
                    $"El código de tienda {createStoreDto.Code} ya exsiste."
                    );
            }

            //Name
            if (await CodeExist(createStoreDto.MemberId, createStoreDto.Name))
            {
                throw new CreateStoreArgumentException(
                    $"El nombre de tienda {createStoreDto.Name} ya exsiste."
                    );
            }

            //Phone
            if (await CodeExist(createStoreDto.MemberId, createStoreDto.Phone))
            {
                throw new CreateStoreArgumentException(
                    $"El teléfono de tienda {createStoreDto.Phone} ya exsiste."
                    );
            }
        }

        public async Task<bool> CodeExist(Guid memberId, string code) 
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from stores ");
            sql.Append("and member_id = @cmember_idode ");
            sql.Append("and code = @code ");

            IEnumerable<Models.Entities.Stores> stores;

            stores = await Connection
                .QueryAsync<Models.Entities.Stores>
                (
                    sql.ToString(),
                    new {
                        member_id = memberId,
                        code = code
                    }
                );

            if (stores.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> NameExist(Guid memberId, string name)
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from stores ");
            sql.Append("and member_id = @cmember_idode ");
            sql.Append("and name = @name ");

            IEnumerable<Models.Entities.Stores> stores;

            stores = await Connection
                .QueryAsync<Models.Entities.Stores>
                (
                    sql.ToString(),
                    new
                    {
                        member_id = memberId,
                        name = name
                    }
                );

            if (stores.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> PhoneExist(Guid memberId, string phone)
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from stores ");
            sql.Append("and member_id = @cmember_idode ");
            sql.Append("and phone = @phone ");

            IEnumerable<Models.Entities.Stores> stores;

            stores = await Connection
                .QueryAsync<Models.Entities.Stores>
                (
                    sql.ToString(),
                    new
                    {
                        member_id = memberId,
                        phone = phone
                    }
                );

            if (stores.Any())
            {
                result = true;
            }

            return result;
        }
    }
}

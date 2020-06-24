using Dapper;
using Mahzan.DataAccess.DTO.Goups;
using Mahzan.DataAccess.Exceptions.Employees.CreateEmployee;
using Mahzan.DataAccess.Exceptions.Groups.CreateGroup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Groups.CreateGroup
{
    public class CreateGroupRules : DataConnection,ICreateGroupRules
    {
        public CreateGroupRules(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task HandleRules(CreateGroupDto createGroupDto)
        {
            //Valdia si el nombre del grupo existe
            if (await NameExist(createGroupDto))
            {
                throw new CreateGroupArgumentException(
                    $"El grupo {createGroupDto.Name} ya existe."
                    );
            }
        }

        public async Task<bool> NameExist(CreateGroupDto createGroupDto) 
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from groups ");
            sql.Append("where member_id = @member_id ");
            sql.Append("and name = @name");

            IEnumerable<Models.Entities.Groups> groups;
            groups = await Connection
                .QueryAsync<Models.Entities.Groups>(
                    sql.ToString(),
                    new {
                        member_id = createGroupDto.MemberId,
                        name = createGroupDto.Name
                    }
                );

            if (groups.Any())
            {
                result = true;
            }

            return result;
        }
    }
}

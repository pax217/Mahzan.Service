using Dapper;
using Mahzan.DataAccess.DTO.Goups;
using Mahzan.DataAccess.Rules.Groups.CreateGroup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Groups.CreateGroup
{
    public class CreateGroupRepository : DataConnection,ICreateGroupRepository
    {
        private readonly ICreateGroupRules _createGroupRules;

        public CreateGroupRepository(
            IDbConnection dbConnection, 
            ICreateGroupRules createGroupRules) : base(dbConnection)
        {
            _createGroupRules = createGroupRules;
        }

        public async Task HandleRepository(CreateGroupDto createGroupDto)
        {
            //Rules
            await _createGroupRules
                .HandleRules(createGroupDto);


            StringBuilder sql = new StringBuilder();
            sql.Append("insert into groups ");
            sql.Append("(");
            sql.Append("group_id,");
            sql.Append("name,");
            sql.Append("active,");
            sql.Append("member_id");
            sql.Append(")");
            sql.Append("values ");
            sql.Append("(");
            sql.Append("@group_id,");
            sql.Append("@name,");
            sql.Append("@active,");
            sql.Append("@member_id");
            sql.Append(")");

            await Connection
                .ExecuteAsync(
                    sql.ToString(),
                    new {
                        group_id = Guid.NewGuid(),
                        name = createGroupDto.Name,
                        active = true,
                        member_id = createGroupDto.MemberId
                    }
                ); 

        }
    }
}

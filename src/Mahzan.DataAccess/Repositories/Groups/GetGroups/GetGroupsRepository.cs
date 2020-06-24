using Dapper;
using Mahzan.DataAccess.DTO.Goups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Groups.GetGroups
{
    public class GetGroupsRepository : DataConnection, IGetGroupsRepository
    {
        public GetGroupsRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Models.Entities.Groups>> HandleRepository(GetGroupsDto getGroupsDto)
        {
            DynamicParameters parameters = new DynamicParameters();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from groups ");
            sql.Append("where  1=1 ");

            //Member
            if (getGroupsDto.MemberId!= null)
            {
                sql.Append("and member_id = @member_id ");
                parameters.Add("@member_id", getGroupsDto.MemberId, DbType.Guid);
            }

            if (getGroupsDto.Name != null)
            {
                sql.Append("and name like @name ");
                parameters.Add("@name", "%" + getGroupsDto.Name + "%", DbType.String);
            }

            if (getGroupsDto.GroupId != null)
            {
                sql.Append("and group_id = @group_id ");
                parameters.Add("@group_id", getGroupsDto.GroupId, DbType.Guid);
            }


            IEnumerable<Models.Entities.Groups> groups;
            groups = await Connection
                .QueryAsync<Models.Entities.Groups>(
                    sql.ToString(),
                    parameters
                );

            return groups.ToList();
        }
    }
}

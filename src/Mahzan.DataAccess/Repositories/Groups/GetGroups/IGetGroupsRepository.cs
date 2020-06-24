using Mahzan.DataAccess.DTO.Goups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Groups.GetGroups
{
    public interface IGetGroupsRepository
    {

        Task<List<Models.Entities.Groups>> HandleRepository(GetGroupsDto getGroupsDto);

    }
}

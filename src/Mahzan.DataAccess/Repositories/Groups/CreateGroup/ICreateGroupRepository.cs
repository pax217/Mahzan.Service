using Mahzan.DataAccess.DTO.Goups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Groups.CreateGroup
{
    public interface ICreateGroupRepository
    {
        Task HandleRepository(CreateGroupDto createGroupDto);
    }
}

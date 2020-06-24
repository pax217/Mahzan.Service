using Mahzan.DataAccess.DTO.Goups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Groups.CreateGroup
{
    public interface ICreateGroupRules
    {
        Task HandleRules(CreateGroupDto createGroupDto);
    }
}

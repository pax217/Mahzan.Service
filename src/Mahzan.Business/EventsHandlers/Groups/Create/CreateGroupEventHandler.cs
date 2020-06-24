using Mahzan.Business.Events.Groups;
using Mahzan.DataAccess.DTO.Goups;
using Mahzan.DataAccess.Repositories.Groups.CreateGroup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Groups.Create
{
    public class CreateGroupEventHandler : ICreateGroupEventHandler
    {
        private readonly ICreateGroupRepository _createGroupRepository;

        public CreateGroupEventHandler(
            ICreateGroupRepository createGroupRepository)
        {
            _createGroupRepository = createGroupRepository;
        }

        public async Task HandleEvent(CreateGroupEvent createGroupEvent)
        {
            await _createGroupRepository
                .HandleRepository( new CreateGroupDto 
                    {
                        Name = createGroupEvent.Name,
                        MemberId = createGroupEvent.MemberId
                }
                );
        }
    }
}

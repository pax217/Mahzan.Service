using Mahzan.Business.Events.Groups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Groups.Create
{
    public interface ICreateGroupEventHandler
    {
        Task HandleEvent(CreateGroupEvent createGroupEvent);
    }
}

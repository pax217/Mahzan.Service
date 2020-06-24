using Mahzan.Business.Events.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Stores.CreateStore
{
    public interface ICreateStoreEventHandler
    {
        Task HandleEvent(CreateStoreEvent createStoreEvent);
    }
}

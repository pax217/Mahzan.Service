using Mahzan.Business.Events.Stores;
using Mahzan.DataAccess.DTO.Stores.CreateStore;
using Mahzan.DataAccess.Repositories.Stores.CreateStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Stores.CreateStore
{
    public class CreateStoreEventHandler : ICreateStoreEventHandler
    {
        private readonly ICreateStoreRepository _createStoreRepository;

        public CreateStoreEventHandler(
            ICreateStoreRepository createStoreRepository) 
        {
            _createStoreRepository = createStoreRepository;
        }

        public async Task HandleEvent(CreateStoreEvent createStoreEvent)
        {
            await _createStoreRepository
                .HandleRepository(new CreateStoreDto
                {
                    Code = createStoreEvent.Code,
                    Name = createStoreEvent.Name,
                    Phone = createStoreEvent.Phone,
                    Comment = createStoreEvent.Comment,
                    CompanyId = createStoreEvent.CompanyId,
                    MemberId = createStoreEvent.MemberId
                });
        }
    }
}

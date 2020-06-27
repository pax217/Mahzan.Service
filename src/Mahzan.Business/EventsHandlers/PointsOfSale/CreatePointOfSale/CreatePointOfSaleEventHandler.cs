using Mahzan.Business.Events.PointsOfSale;
using Mahzan.DataAccess.DTO.PointsOfSale.CreatePointOfSale;
using Mahzan.DataAccess.Repositories.PointsOfSale.CreatePointOfSale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.PointsOfSale.CreatePointOfSale
{
    public class CreatePointOfSaleEventHandler : ICreatePointOfSaleEventHandler
    {
        private readonly ICreatePointOfSaleRepository _createPointOfSaleRepository;

        public CreatePointOfSaleEventHandler(
            ICreatePointOfSaleRepository createPointOfSaleRepository) 
        {
            _createPointOfSaleRepository = createPointOfSaleRepository;
        }

        public async Task HandleEvent(CreatePointOfSaleEvent createPointOfSaleEvent)
        {
            await _createPointOfSaleRepository
                .HandleRepository(new CreatePointOfSaleDto { 
                    Code = createPointOfSaleEvent.Code,
                    Name = createPointOfSaleEvent.Name,
                    StoreId = createPointOfSaleEvent.StoreId,
                    MemberId = createPointOfSaleEvent.MemberId
                });
        }
    }
}

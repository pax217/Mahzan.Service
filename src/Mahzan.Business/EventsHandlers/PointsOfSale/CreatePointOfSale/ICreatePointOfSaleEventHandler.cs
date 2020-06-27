using Mahzan.Business.Events.PointsOfSale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.PointsOfSale.CreatePointOfSale
{
    public interface ICreatePointOfSaleEventHandler
    {
        Task HandleEvent(CreatePointOfSaleEvent createPointOfSaleEvent);
    }
}

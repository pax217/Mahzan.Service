using Mahzan.Business.Events.Menu.GetAside;
using Mahzan.Business.Models.Menu.GetAside;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Menu.GetAside
{
    public interface IGetAsideEventHandler
    {
        Task<MenuModel> HandleEvent(GetAsideEvent getAsideEvent);
    }
}

using Mahzan.Business.EventsHandlers.Menu.GetAside;
using Mahzan.DataAccess.Repositories.Menu.GetAside;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Menu
{
    public static class GetAsideEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<IGetAsideEventHandler>(
                x => new GetAsideEventHandler(
                    x.GetService<IGetAsideRepository>()
                    )
                );
        }
    }
}

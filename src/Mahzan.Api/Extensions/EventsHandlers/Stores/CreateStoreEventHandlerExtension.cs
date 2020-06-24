using Mahzan.Business.EventsHandlers.Stores.CreateStore;
using Mahzan.DataAccess.Repositories.Stores.CreateStore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Stores
{
    public static class CreateStoreEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ICreateStoreEventHandler>(
                x => new CreateStoreEventHandler(
                    x.GetService<ICreateStoreRepository>()
                    )
                );
        }
    }
}

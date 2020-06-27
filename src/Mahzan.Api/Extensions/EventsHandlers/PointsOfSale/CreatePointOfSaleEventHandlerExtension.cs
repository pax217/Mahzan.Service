using Mahzan.Business.EventsHandlers.PointsOfSale.CreatePointOfSale;
using Mahzan.DataAccess.Repositories.PointsOfSale.CreatePointOfSale;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.PointsOfSale
{
    public static class CreatePointOfSaleEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ICreatePointOfSaleEventHandler>(
                x => new CreatePointOfSaleEventHandler(
                    x.GetService<ICreatePointOfSaleRepository>()
                    )
                );
        }
    }
}

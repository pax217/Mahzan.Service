using AutoMapper;
using Mahzan.Business.EventsHandlers.Products.CreateProduct;
using Mahzan.DataAccess.Repositories.Products.CreateProduct;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Products.CreateProduct
{
    public static  class CreateProductEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ICreateProductEventHandler>(
                x => new CreateProductEventHandler(
                    x.GetService<ICreateProductRepository>(),
                    x.GetService<IMapper>()
                    )
                );
        }
    }
}

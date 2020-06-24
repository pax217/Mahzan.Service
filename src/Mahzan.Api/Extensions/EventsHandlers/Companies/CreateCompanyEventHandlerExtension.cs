using Mahzan.Business.EventsHandlers.Companies.CreateCompany;
using Mahzan.DataAccess.Repositories.Companies.CreateCompany;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Companies
{
    public static class CreateCompanyEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ICreateCompanyEventHandler>(
                x => new CreateCompanyEventHandler(
                    x.GetService<ICreateCompanyRepository>()
                    )
                );
        }
    }
}

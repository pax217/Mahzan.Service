using Mahzan.Business.EventsHandlers.Employees.Create;
using Mahzan.DataAccess.Repositories.Employees.CreateEmployee;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Employees
{
    public static class CreateEmployeeEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ICreateEmployeeEventHandler>(
                x => new CreateEmployeeEventHandler(
                    x.GetService<ICreateEmployeeRepository>()
                    )
                );
        }
    }
}

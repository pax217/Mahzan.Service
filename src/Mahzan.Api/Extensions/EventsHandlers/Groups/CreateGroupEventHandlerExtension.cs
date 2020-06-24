using Mahzan.Business.EventsHandlers.Groups.Create;
using Mahzan.DataAccess.Repositories.Groups.CreateGroup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Groups
{
    public static class CreateGroupEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ICreateGroupEventHandler>(
                x => new CreateGroupEventHandler(
                    x.GetService<ICreateGroupRepository>()
                    )
                );
        }
    }
}

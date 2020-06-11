using Mahzan.Business.EventsHandlers.Users.Login;
using Mahzan.DataAccess.Repositories.Users.Login;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Users
{
    public static class LoginEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ILoginEventHandler>(
                x => new LoginEventHandler(
                    x.GetService<ILoginRepository>()
                    )
                );
        }
    }
}

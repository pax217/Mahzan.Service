using Mahzan.Business.EventsHandlers.Users.SignUp;
using Mahzan.DataAccess.Repositories.Users.SignUp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Users
{
    public static class SignUpEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ISignUpEventHandler>(
                x => new SignUpEventHandler(
                    x.GetService<ISignUpRepository>()
                    )
                );
        }
    }
}

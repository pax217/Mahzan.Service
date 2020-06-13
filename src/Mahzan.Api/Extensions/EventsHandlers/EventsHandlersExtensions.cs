using Mahzan.Api.Extensions.EventsHandlers.Employees;
using Mahzan.Api.Extensions.EventsHandlers.Menu;
using Mahzan.Api.Extensions.EventsHandlers.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers
{
    public static class EventsHandlersExtensions
    {
        public static void configure(
            IServiceCollection services)
        {
            LoginEventHandlerExtension
                .Configure(services);
            SignUpEventHandlerExtension
                .Configure(services);
            GetAsideEventHandlerExtension
                .Configure(services);
            CreateEmployeeEventHandlerExtension
                .Configure(services);
        }
    }
}

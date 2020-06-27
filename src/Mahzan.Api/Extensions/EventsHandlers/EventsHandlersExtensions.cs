using Mahzan.Api.Extensions.EventsHandlers.Companies;
using Mahzan.Api.Extensions.EventsHandlers.Employees;
using Mahzan.Api.Extensions.EventsHandlers.Groups;
using Mahzan.Api.Extensions.EventsHandlers.Menu;
using Mahzan.Api.Extensions.EventsHandlers.PointsOfSale;
using Mahzan.Api.Extensions.EventsHandlers.Stores;
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
            //Users
            LoginEventHandlerExtension
                .Configure(services);
            SignUpEventHandlerExtension
                .Configure(services);

            //Menu
            GetAsideEventHandlerExtension
                .Configure(services);

            //Employees
            CreateEmployeeEventHandlerExtension
                .Configure(services);

            //Groups
            CreateGroupEventHandlerExtension
                .Configure(services);

            //Companies
            CreateCompanyEventHandlerExtension
                .Configure(services);

            //Stores
            CreateStoreEventHandlerExtension
                .Configure(services);

            //Points Of Sale
            CreatePointOfSaleEventHandlerExtension
                .Configure(services);
        }
    }
}

using Mahzan.Api.Extensions.Repositories._BaseController;
using Mahzan.Api.Extensions.Repositories.Employees;
using Mahzan.Api.Extensions.Repositories.Menu;
using Mahzan.Api.Extensions.Repositories.Users;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories
{
    public static class RepositoriesExtensions
    {
        public static void configure(
            IServiceCollection services,
            string connectionString) 
        {
            //Base Controller
            BaseControllerRepositoryExtension
                .Configure(services, connectionString);

            //User
            LoginRepositoryExtension
                .Configure(services, connectionString);
            SignUpRepositoryExtension
                .Configure(services, connectionString);
            ConfirmEmailRepositoryExtension
                .Configure(services, connectionString);

            //Menu
            GetAsideRepositoryExtension
                .Configure(services, connectionString);

            //Employees
            CreateEmployeeRepositoryExtension
                .Configure(services, connectionString);
        }
    }
}

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
            LoginRepositoryExtension
                .Configure(services, connectionString);
        }
    }
}

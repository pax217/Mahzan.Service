using Mahzan.DataAccess.Repositories._BaseController;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories._BaseController
{
    public static class BaseControllerRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IBaseControllerRepository>(
                x => new BaseControllerRepository(
                    new NpgsqlConnection(connectionString)
                    ));
        }
    }
}

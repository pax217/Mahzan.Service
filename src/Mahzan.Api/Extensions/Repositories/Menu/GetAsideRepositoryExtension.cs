using Mahzan.DataAccess.Repositories.Menu.GetAside;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Menu
{
    public static class GetAsideRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetAsideRepository>(
                x => new GetAsideRepository(
                    new NpgsqlConnection(connectionString)
                    ));
        }
    }
}

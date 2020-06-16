using Mahzan.DataAccess.Repositories.Roles.GetRoles;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Roles
{
    public static class GetRolesRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetRolesRepository>(
                x => new GetRolesRepository(
                    new NpgsqlConnection(connectionString)
                    ));
        }
    }
}

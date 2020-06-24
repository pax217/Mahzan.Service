using Mahzan.DataAccess.Repositories.Groups.GetGroups;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Groups
{
    public static class GetGroupsRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetGroupsRepository>(
                x => new GetGroupsRepository(
                    new NpgsqlConnection(connectionString)
                    ));
        }
    }
}

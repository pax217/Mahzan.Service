using Mahzan.DataAccess.Repositories.Groups.CreateGroup;
using Mahzan.DataAccess.Rules.Groups.CreateGroup;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Groups
{
    public static class CreateGroupRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateGroupRepository>(
                x => new CreateGroupRepository(
                    new NpgsqlConnection(connectionString),
                    x.GetService<ICreateGroupRules>()
                    ));
        }
    }
}

using Mahzan.DataAccess.Rules.Groups.CreateGroup;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.Groups
{
    public static class CreateGroupRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {

            services
                .AddScoped<ICreateGroupRules>(
                x => new CreateGroupRules(
                    new NpgsqlConnection(connectionString)
                    ));

        }
    }
}

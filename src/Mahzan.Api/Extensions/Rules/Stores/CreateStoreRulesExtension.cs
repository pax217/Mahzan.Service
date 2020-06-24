using Mahzan.DataAccess.Rules.Stores;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.Stores
{
    public static class CreateStoreRulesExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {

            services
                .AddScoped<ICreateStoreRules>(
                x => new CreateStoreRules(
                    new NpgsqlConnection(connectionString)
                    ));

        }
    }
}

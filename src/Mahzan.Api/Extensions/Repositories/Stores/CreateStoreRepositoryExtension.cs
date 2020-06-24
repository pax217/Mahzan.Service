using Mahzan.DataAccess.Repositories.Stores.CreateStore;
using Mahzan.DataAccess.Rules.Stores;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Stores
{
    public static class CreateStoreRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateStoreRepository>(
                x => new CreateStoreRepository(
                    new NpgsqlConnection(connectionString),
                    x.GetService<ICreateStoreRules>()
                    ));
        }
    }
}

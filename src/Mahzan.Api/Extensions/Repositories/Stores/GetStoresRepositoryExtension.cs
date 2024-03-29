﻿using Mahzan.DataAccess.Repositories.Stores.GetStores;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Stores
{
    public static class GetStoresRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetStoresRepository>(
                x => new GetStoresRepository(
                    new NpgsqlConnection(connectionString)
                    ));
        }
    }
}

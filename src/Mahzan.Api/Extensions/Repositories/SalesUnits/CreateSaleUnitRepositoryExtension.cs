using Mahzan.DataAccess.Repositories.SalesUnits.CreateSaleUnit;
using Mahzan.DataAccess.Rules.SalesUnits.CreateSaleUnit;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.SalesUnits
{
    public static class CreateSaleUnitRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateSaleUnitRepository>(
                x => new CreateSaleUnitRepository(
                    new NpgsqlConnection(connectionString),
                    x.GetService<ICreateSaleUnitRules>()
                    ));
        }
    }
}

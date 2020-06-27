using Mahzan.DataAccess.Rules.SalesUnits.CreateSaleUnit;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.SalesUnits
{
    public static class CreateSaleUnitRulesExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {

            services
                .AddScoped<ICreateSaleUnitRules>(
                x => new CreateSaleUnitRules(
                    new NpgsqlConnection(connectionString)
                    ));

        }
    }
}

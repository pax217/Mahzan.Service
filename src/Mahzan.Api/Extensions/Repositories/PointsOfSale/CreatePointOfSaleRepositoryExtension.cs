using Mahzan.DataAccess.Repositories.PointsOfSale.CreatePointOfSale;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.PointsOfSale
{
    public static class CreatePointOfSaleRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreatePointOfSaleRepository>(
                x => new CreatePointOfSaleRepository(
                    new NpgsqlConnection(connectionString)
                    ));
        }
    }
}

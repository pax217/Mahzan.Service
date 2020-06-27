using Mahzan.DataAccess.Repositories.PointsOfSale.GetPointsOfSale;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.PointsOfSale
{
    public static class GetPointsOfSaleRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetPointsOfSaleRepository>(
                x => new GetPointsOfSaleRepository(
                    new NpgsqlConnection(connectionString)
                    ));
        }
    }
}

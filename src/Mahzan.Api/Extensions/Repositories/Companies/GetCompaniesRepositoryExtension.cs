using Mahzan.DataAccess.Repositories.Companies.GetCompanies;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Companies
{
    public static class GetCompaniesRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetCompaniesRepository>(
                x => new GetCompaniesRepository(
                    new NpgsqlConnection(connectionString)
                    ));
        }
    }
}

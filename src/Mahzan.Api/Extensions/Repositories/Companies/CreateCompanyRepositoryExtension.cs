using Mahzan.DataAccess.Repositories.Companies.CreateCompany;
using Mahzan.DataAccess.Rules.Companies.CreateCompany;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Companies
{
    public static class CreateCompanyRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateCompanyRepository>(
                x => new CreateCompanyRepository(
                    new NpgsqlConnection(connectionString),
                    x.GetService<ICreateCompanyRules>()
                    ));
        }
    }
}

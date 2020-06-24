using Mahzan.DataAccess.Rules.Companies.CreateCompany;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.Companies
{
    public static class CreateCompanyRulesExtension
    {

        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {

            services
                .AddScoped<ICreateCompanyRules>(
                x => new CreateCompanyRules(
                    new NpgsqlConnection(connectionString)
                    ));

        }
    }
}

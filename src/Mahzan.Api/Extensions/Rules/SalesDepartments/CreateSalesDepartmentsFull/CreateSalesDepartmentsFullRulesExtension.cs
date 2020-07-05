using Mahzan.DataAccess.Rules.SalesDepartments.CreateSalesDepartmentsFull;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.SalesDepartments.CreateSalesDepartmentsFull
{
    public static class CreateSalesDepartmentsFullRulesExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {

            services
                .AddScoped<ICreateSalesDepartmentsFullRules>(
                x => new CreateSalesDepartmentsFullRules(
                    new NpgsqlConnection(connectionString)
                    ));

        }
    }
}

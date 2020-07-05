using Mahzan.DataAccess.Repositories.SalesDepartments.CreateSalesDepartmentsFull;
using Mahzan.DataAccess.Rules.SalesDepartments.CreateSalesDepartmentsFull;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.SalesDepartments
{
    public static class CreateSalesDepartmentsFullRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateSalesDepartmentsFullRepository>(
                x => new CreateSalesDepartmentsFullRepository(
                    new NpgsqlConnection(connectionString),
                    x.GetService<ICreateSalesDepartmentsFullRules>()
                    ));
        }
    }
}

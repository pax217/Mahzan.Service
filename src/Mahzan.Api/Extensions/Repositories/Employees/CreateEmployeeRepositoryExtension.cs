using Mahzan.DataAccess.Repositories.Employees.CreateEmployee;
using Mahzan.DataAccess.Rules.Employees.CreateEmployee;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Employees
{
    public static class CreateEmployeeRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateEmployeeRepository>(
                x => new CreateEmployeeRepository(
                    new NpgsqlConnection(connectionString),
                    x.GetService<ICreateEmployeeRules>()
                    )); ;
        }
    }
}

using Mahzan.DataAccess.Repositories.Employees.GetEmployees;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Employees
{
    public static class GetEmployeesRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetEmployeesRepository>(
                x => new GetEmployeesRepository(
                    new NpgsqlConnection(connectionString)
                    )); ;
        }
    }
}

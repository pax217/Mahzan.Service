using Mahzan.DataAccess.Repositories.Users.Login;
using Mahzan.DataAccess.Rules.Users.Login;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Users
{
    public static class LoginRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ILoginRepository>(
                x => new LoginRepository(
                    new NpgsqlConnection(connectionString),
                    x.GetService<ILoginRules>()
                    ));
        }
    }
}

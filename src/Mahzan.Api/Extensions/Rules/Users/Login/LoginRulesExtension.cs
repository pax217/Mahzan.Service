using Mahzan.DataAccess.Rules.Users.Login;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.Users.Login
{
    public class LoginRulesExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {

            services
                .AddScoped<ILoginRules>(
                x => new LoginRules(
                    new NpgsqlConnection(connectionString)
                    ));

        }
    }
}

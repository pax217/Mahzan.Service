using Mahzan.DataAccess.Repositories.Users.SignUp;
using Mahzan.DataAccess.Rules.Users.SignUp;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.Users.SignUp
{
    public static class SignUpRulesExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {

                services
                    .AddScoped<ISignUpRules>(
                    x => new SignUpRules(
                        new NpgsqlConnection(connectionString)
                        ));

        }
    }
}

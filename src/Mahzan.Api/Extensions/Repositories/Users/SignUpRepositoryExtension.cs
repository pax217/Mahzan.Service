using Mahzan.DataAccess.Repositories.Users.SignUp;
using Mahzan.DataAccess.Rules.Users.SignUp;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Users
{
    public static class SignUpRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ISignUpRepository>(
                x => new SignUpRepository(
                    new NpgsqlConnection(connectionString),
                    x.GetService<ISignUpRules>()
                    ));
        }
    }
}

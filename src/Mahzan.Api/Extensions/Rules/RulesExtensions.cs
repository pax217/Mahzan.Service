using Mahzan.Api.Extensions.Rules.Employees;
using Mahzan.Api.Extensions.Rules.Users.Login;
using Mahzan.Api.Extensions.Rules.Users.SignUp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules
{
    public static class RulesExtensions
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString) 
        {
            SignUpRulesExtension
                .Configure(services, connectionString);
            LoginRulesExtension
                .Configure(services, connectionString);
            CreateEmployeeRulesExtension
                .Configure(services, connectionString);
        }
    }
}

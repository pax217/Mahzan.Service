using Mahzan.Api.Extensions.Rules.Companies;
using Mahzan.Api.Extensions.Rules.Employees;
using Mahzan.Api.Extensions.Rules.Groups;
using Mahzan.Api.Extensions.Rules.SalesDepartments.CreateSalesDepartmentsFull;
using Mahzan.Api.Extensions.Rules.SalesUnits;
using Mahzan.Api.Extensions.Rules.Stores;
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
            CreateGroupRepositoryExtension
                .Configure(services, connectionString);

            //Companies
            CreateCompanyRulesExtension
                .Configure(services, connectionString);

            //Stores
            CreateStoreRulesExtension
                .Configure(services, connectionString);

            //Sales Units
            CreateSaleUnitRulesExtension
                .Configure(services, connectionString);

            //Sales Departments
            CreateSalesDepartmentsFullRulesExtension
                .Configure(services, connectionString);
        }
    }
}

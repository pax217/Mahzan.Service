using Mahzan.Api.Extensions.Repositories._BaseController;
using Mahzan.Api.Extensions.Repositories.Companies;
using Mahzan.Api.Extensions.Repositories.Employees;
using Mahzan.Api.Extensions.Repositories.Groups;
using Mahzan.Api.Extensions.Repositories.Menu;
using Mahzan.Api.Extensions.Repositories.PointsOfSale;
using Mahzan.Api.Extensions.Repositories.Products.CreateProduct;
using Mahzan.Api.Extensions.Repositories.Roles;
using Mahzan.Api.Extensions.Repositories.SalesDepartments;
using Mahzan.Api.Extensions.Repositories.SalesUnits;
using Mahzan.Api.Extensions.Repositories.Stores;
using Mahzan.Api.Extensions.Repositories.Users;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories
{
    public static class RepositoriesExtensions
    {
        public static void configure(
            IServiceCollection services,
            string connectionString) 
        {
            //Base Controller
            BaseControllerRepositoryExtension
                .Configure(services, connectionString);

            //User
            LoginRepositoryExtension
                .Configure(services, connectionString);
            SignUpRepositoryExtension
                .Configure(services, connectionString);
            ConfirmEmailRepositoryExtension
                .Configure(services, connectionString);

            //Menu
            GetAsideRepositoryExtension
                .Configure(services, connectionString);

            //Employees
            CreateEmployeeRepositoryExtension
                .Configure(services, connectionString);
            GetEmployeesRepositoryExtension
                .Configure(services, connectionString);

            //Roles
            GetRolesRepositoryExtension
                .Configure(services, connectionString);

            //Groups
            CreateGroupRepositoryExtension
                .Configure(services, connectionString);
            GetGroupsRepositoryExtension
                .Configure(services, connectionString);


            //Companies
            CreateCompanyRepositoryExtension
                .Configure(services, connectionString);
            GetCompaniesRepositoryExtension
                .Configure(services, connectionString);

            //Stores
            CreateStoreRepositoryExtension
                .Configure(services, connectionString);
            GetStoresRepositoryExtension
                .Configure(services, connectionString);

            //Points Of Sale
            CreatePointOfSaleRepositoryExtension
                .Configure(services, connectionString);
            GetPointsOfSaleRepositoryExtension
                .Configure(services, connectionString);

            //Sales Units
            CreateSaleUnitRepositoryExtension
                .Configure(services, connectionString);

            //Sales Departments
            CreateSalesDepartmentsFullRepositoryExtension
                .Configure(services, connectionString);

            //Products
            CreateProductRepositoryExtension
                .Configure(services, connectionString);
        }
    }
}

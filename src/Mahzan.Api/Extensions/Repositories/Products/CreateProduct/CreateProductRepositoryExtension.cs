using Mahzan.DataAccess.Repositories.Products.CreateProduct;
using Mahzan.DataAccess.Rules.Products.CreateProduct;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Products.CreateProduct
{
    public static class CreateProductRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateProductRepository>(
                x => new CreateProductRepository(
                    new NpgsqlConnection(connectionString),
                    x.GetService<ICreateProductRules>()
                    ));
        }
    }
}

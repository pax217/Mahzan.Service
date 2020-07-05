using Mahzan.DataAccess.Rules.Products.CreateProduct;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.Products
{
    public static class CreateProductRulesExtension
    {
        public static void Configure(
             IServiceCollection services,
             string connectionString)
        {

            services
                .AddScoped<ICreateProductRules>(
                x => new CreateProductRules(
                    new NpgsqlConnection(connectionString)
                    ));

        }
    }
}

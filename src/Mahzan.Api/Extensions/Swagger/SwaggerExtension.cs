using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Swagger
{
    public static class SwaggerExtension
    {

        public static void configure(this IServiceCollection services) 
        {

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mahzan API",
                    Description = "Sistema de punto de venta y control de inventario",
                    TermsOfService = new Uri("https://www.mahzan.com/terminos"),
                    Contact = new OpenApiContact
                    {
                        Name = "Carlos Albero Maldonado Díaz",
                        Email = "cmaldonadod.217@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Mahzan",
                        Url = new Uri("https://www.mahzan.com"),
                    }
                });

                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();


            });
        }

    }
}

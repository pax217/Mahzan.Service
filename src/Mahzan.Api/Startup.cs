using Mahzan.Api.Exceptions;
using Mahzan.Api.Extensions.Email;
using Mahzan.Api.Extensions.EventsHandlers;
using Mahzan.Api.Extensions.Jwt;
using Mahzan.Api.Extensions.Repositories;
using Mahzan.Api.Extensions.Rules;
using Mahzan.Api.Extensions.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;
using AutoMapper;

namespace Mahzan.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();

            //Configura Ignorar valores null en json
            services.AddMvc()
                    .AddJsonOptions(options => {
                        options.JsonSerializerOptions.IgnoreNullValues = true;
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });
            //Configura Ignorar referencias circulares
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //Email
            EmailExtensions.Configure(services, _configuration);

            //Jwt 
            JwtExtensions.configure(services, _configuration);

            //Agrega Versionador de API
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            //Swagger
            SwaggerExtension.configure(services);

            //Rules
            RulesExtensions
                .Configure(services, _configuration.GetConnectionString("Mahzan"));

            //Repositories
            RepositoriesExtensions
                .configure(services, _configuration.GetConnectionString("Mahzan"));

            //Events Handlers
            EventsHandlersExtensions
                .configure(services);

            //Handle Errors
            services.AddMvc(options => { options.Filters.Add(typeof(UnhandledException)); })
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                    .ConfigureApiBehaviorOptions(options => {
                        options.InvalidModelStateResponseFactory = InvalidModelStateHandler.Handler;
                    });

            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Use Cors
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

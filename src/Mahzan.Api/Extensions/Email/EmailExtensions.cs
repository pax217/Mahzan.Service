using Mahzan.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Email
{
    public static class EmailExtensions
    {
        public static void Configure(
            this IServiceCollection services,
            IConfiguration configuration) 
        {
            //Envio de Email
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddSingleton<IEmailSender, EmailSender>();
        }
    }
}

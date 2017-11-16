using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL.Common
{
   public static class ConfigureServices 
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PatientDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });

            return services;
        }
    }
}

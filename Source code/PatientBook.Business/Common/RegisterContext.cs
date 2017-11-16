using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBook.Business.Common
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PatientDbContext>(options =>
            {
                Utility.ManageDbConnection(options);
            });

            return services;
        }

        public static IServiceCollection AddRepositoryScope(this IServiceCollection services)
        {
            services.AddScoped<IRepository.IPatientRepository, Repository.PatientRepository>();


            return services;
        }

        public static IServiceCollection AddDapperRepositoryScope(this IServiceCollection services)
        {
            services.AddScoped<Persistence.DAL.IDapper.IPatientDapperRepo, Persistence.DAL.Dapper.PatientDapperRepo>();

            return services;
        }
    }
}

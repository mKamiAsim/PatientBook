using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Serilog;
using Serilog.Events;
using PatientBook.Core.Entity;
using PatientBook.Business.Common;
namespace PatientBook.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("Settings"));

            services.RegisterDbContext(Configuration);
            services.AddRepositoryScope();
            services.AddDapperRepositoryScope();


            services.AddLogging((builder =>
            {
                builder.AddSerilog(dispose: true);
            }));

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });
            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(Configuration)
                        .CreateLogger();

            if (env.IsDevelopment())
            {
                //Log.Logger = new LoggerConfiguration()
                //             .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                //             .MinimumLevel.Override("System", LogEventLevel.Warning)
                //             .Enrich.FromLogContext()
                //             .WriteTo.Seq("http://localhost:5341")
                //            .CreateLogger();

                app.UseDeveloperExceptionPage();
            }
            else
            {

                app.UseExceptionHandler("/Home/Error");
            }

            try
            {
                SessionObj.AppSettings = Configuration.GetSection("Settings").Get<AppSettings>();
                SessionObj.AppSettings.ConnectionString = Configuration.GetConnectionString(SessionObj.AppSettings.ConnectionName);
                if (string.IsNullOrWhiteSpace(SessionObj.AppSettings.ConnectionString))
                {
                    throw new Exception("No database connection found. Make sure valid connection name is entered in Settings=>ConnectionName");
                }
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, ex.Message);
                throw ex;
            }

            app.UseMvc();

        }
    }
}

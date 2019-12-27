using Autofac;
using EntityAuth.Core;
using EntityAuth.Core.Services;
using CurrencyApp.Api.Middleware;
using CurrencyApp.Infrastructure.ApiClient;
using CurrencyApp.Infrastructure.DAL;
using CurrencyApp.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestSharp;
using EntityAuth.Core.Uttils;

namespace CurrencyApp.Api
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Swagger ui
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "CurrencyApp task with ASP.NET Core 3.0"
                });
                c.IncludeXmlComments(string.Format(@"{0}\CurrencyApp.Api.xml",
                          System.AppDomain.CurrentDomain.BaseDirectory));
            });

            // Db context
            var connectionString = Configuration.GetConnectionString("CurrencyAppConnectionString");
            services.AddDbContext<CurrencyDbContext>(options => options.UseSqlServer(connectionString));
           
            // Services
            services.AddTransient<IApiLogService, ApiLogService>();
            services.AddTransient<INbpClientLogService, NbpClientLogService>();
            services.AddTransient<IRateService, RateService>();

            
            
            /////////////////// entity auth implementation
            
            services.AddEntityFilter()
                .SetIdentifierType<long>()
                .SetAuthFilterScope(ServiceLifetime.Transient)
                .SetAuthorizationScope(ServiceLifetime.Transient)
                .SetAuthorizationImplementationType<AuthorizationService<long>>()
                .Add();
            
            /*
             * equal to:
             * services.AddTransient<IAuthFitlerService<long>, AuthLongFilterService>();
             * services.AddTransient<IAuthorizationService<long>, AuthorizationService<long>>();
             */

            ////////////////////


            // Rest client
            services.AddTransient<INbpRestClient, NbpRestClient>();
            services.AddSingleton<IRestClient>(new RestClient("https://api.nbp.pl/api"));
           
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceProviderAspectFactory.ServiceProvider = app.ApplicationServices;


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ApiLoggingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });
        }
    }
}

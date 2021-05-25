using DesafioGuilherme.Api.Application;
using DesafioGuilherme.Api.Application.Interfaces;
using DesafioGuilherme.Api.CrossCutting.Assemblies;
using DesafioGuilherme.Api.Domain.Repositories.Interfaces;
using DesafioGuilherme.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace DesafioGuilherme.Api.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());

            services.AddScoped<IWeatherForecastApplication, WeatherForecastApplication>();

            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            services.AddSingleton(typeof(IMemoryCache), typeof(MemoryCache));

            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DesafioGuilherme.Api.Api",
                    Description = "API - DesafioGuilherme.Api.Api",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "DesafioGuilherme.Api.Api.xml");
                var applicationPath = Path.Combine(AppContext.BaseDirectory, "DesafioGuilherme.Api.Application.xml");

                c.IncludeXmlComments(apiPath);

                c.IncludeXmlComments(applicationPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UsePathBase("/DesafioGuilherme.Api");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/DesafioGuilherme.Api/swagger/v1/swagger.json", "API DesafioGuilherme.Api");
            });
        }
    }
}

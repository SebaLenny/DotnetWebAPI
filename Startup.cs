using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetWebAPI.Models;
using DotnetWebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DotnetWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string CreateConnectionString()
        {
            Configuration.GetSection("DbEnvVars:POSTGRES_DB");
            var server = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
            var port = "5432";
            var db = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? Configuration["DbEnvVars:POSTGRES_DB"];
            var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? Configuration["DbEnvVars:POSTGRES_USER"];
            var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? Configuration["DbEnvVars:POSTGRES_PASSWORD"];
            var connectionString = $"Server={server};Port={port};Database={db};User Id={dbUser};Password={dbPassword};";
            return connectionString;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = CreateConnectionString();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IUniversalService, UniversalService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotnetWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotnetWebAPI v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

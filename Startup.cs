using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElipgoBE.DataSet;
using ElipgoBE.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ElipgoBE.Models;
using System.Text.Json;

namespace ElipgoBE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string AllowedCors = "_AllowedCors";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowedCors,
                builder =>
                {
                    builder.WithOrigins()
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
                });
            });

            var connection = @"Data Source=35.199.80.25;User Id=sqlserver;Password=sqlserver;Database=ElipgoDB;";
            services.AddDbContext<MyDbContext>(options =>
                    options.UseSqlServer(connection));

            services.AddMvc().AddNewtonsoftJson();
            services.AddScoped<StoresServices>();
            services.AddScoped<StoresDataSet>();
            services.AddScoped<ArticlesServices>();
            services.AddScoped<ArticlesDataSet>();
            services.AddScoped<LoginService>();
            services.AddScoped<LoginDataSet>();
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(AllowedCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using APIDapper.Repositories;
using APIDapper.Repositories.Interfaces;
using BercaCafe_API.Context;
using BercaCafe_API.Repositories.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BercaCafe_API
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
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddDbContext<BercaCafeContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("BercaCafe")));
            services.AddScoped<IReport, ReportRepository>();
            services.AddScoped<IMenu, MenuRepository>();
            services.AddScoped<IStock, StockRepository>();
            services.AddScoped<IComposition, CompositionRepository>();
            services.AddScoped<ICompositionType, CompositionTypeRepository>();
            services.AddScoped<IEmployeeUser, EmployeeUserRepository>();
            services.AddScoped<IOrder, OrderRepository>();
            services.AddScoped<IRefill, RefillRepository>();
            services.AddCors(e =>
            {

                e.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
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
            app.UseCors(options =>
            options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using InschrijvenPietieterken.Shared;
using InschrijvingPietieterken.DataAccess;
using InschrijvingPietieterken.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InschrijvingPietieterken
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
            AppSettings.RegisterConfiguration(services, Configuration.GetSection("ProductionConstants"));
            var appSettings = services.BuildServiceProvider().GetService<IOptions<AppSettings>>().Value;

            var connString = GetConnString(appSettings);

            services.AddServices();
            services.AddAutoMapper();
            services.AddDbContext<EntityContext>(options =>
                options.UseSqlServer(connString));
            services.AddMvc();

        }

        private string GetConnString(AppSettings appSettings)
        {
            return $"Server=tcp:{appSettings.Host},1433;Initial Catalog={appSettings.Database};Persist Security Info=False;User ID={appSettings.Username};Password={appSettings.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCors(options =>
            {
                options.AllowAnyMethod();
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
                options.AllowCredentials();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "api",
                    template: "api/{controller}/{action}");
            });
        }
    }
}

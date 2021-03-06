using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Velocity.Core.Repository;
using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Web
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
            services.AddControllersWithViews();
            services.AddScoped<VelocityContext>();
            services.AddScoped<ClientRepository>();
            services.AddScoped<ContainerRepository>();
            services.AddScoped<DriverRepository>();
            services.AddScoped<FeeRepository>();
            services.AddScoped<InvoiceRepository>();
            services.AddScoped<InvoiceDetailRepository>();
            services.AddScoped<TransitRepository>();
            services.AddScoped<Client>();
            services.AddScoped<Container>();
            services.AddScoped<Driver>();
            services.AddScoped<Fee>();
            services.AddScoped<Invoice>();
            services.AddScoped<InvoiceDetail>();
            services.AddScoped<Transit>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

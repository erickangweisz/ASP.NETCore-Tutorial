using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmployeeApi.Service.Models;
using EmployeeApi.Data.Providers.Interfaces;
using EmployeeApi.Data.Providers;

namespace EmployeeApi
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
            /*services.AddDbContext<EmployeeContext>(opt =>
                opt.UseInMemoryDatabase("EmployeeList"));*/
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // TODO: Create config.xml and add Initial Catalog and server value and add it into .gitignore
            services.AddTransient<IEmployeeProvider>(f => 
                new EmployeeProvider(@"Persist Security Info = false; Integrated Security = true; Initial Catalog = EmployeeDB; server = DESKTOP-UHSRDD1"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

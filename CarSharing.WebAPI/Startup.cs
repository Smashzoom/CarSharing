using AutoMapper;
using CarSharing.BLL.Contracts;
using CarSharing.BLL.Implementation;
using CarSharing.DataAccess.Context;
using CarSharing.DataAccess.Contracts;
using CarSharing.DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarSharing.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(ICompanyCreateService),typeof(CompanyCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICompanyGetService),typeof(CompanyGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICompanyUpdateService),typeof(CompanyUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICarCreateService),typeof(CarCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICarGetService),typeof(CarGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICarUpdateService),typeof(CarUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IRentCreateService),typeof(RentCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IRentGetService),typeof(RentGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IRentUpdateService),typeof(RentUpdateService), ServiceLifetime.Scoped));
            
            //DataAccess
            services.Add(new ServiceDescriptor(typeof(ICompanyDataAccess), typeof(CompanyDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ICarDataAccess), typeof(CarDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRentDataAccess), typeof(RentDataAccess), ServiceLifetime.Transient));
            
            //DB Contexts
            services.AddDbContext<CompanyContext>(options =>
                options.UseNpgsql(this.Configuration.GetConnectionString("Company")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CompanyContext>();
                context.Database.EnsureCreated(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
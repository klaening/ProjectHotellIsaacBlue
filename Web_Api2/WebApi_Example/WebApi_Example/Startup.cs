using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi_Example_Domain.Repository;
using WebApi_Example_Domain.Services;

namespace WebApi_Example
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
            services.AddSingleton<ICustomerTypesService, CustomerTypesService>();
            services.AddSingleton<ICustomerTypesRepository>(c => new CustomerTypesRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IStaffService, StaffService>();
            services.AddSingleton<IStaffRepository>(c => new StaffRepository(Configuration["ConnectionString"]));

            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository>(c => new CustomerRepository(Configuration["ConnectionString"]));

            services.AddControllers();
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
        }
    }
}

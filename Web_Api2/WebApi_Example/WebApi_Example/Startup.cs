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
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IAccountRepository>(c => new AccountRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IBookingService, BookingService>();
            services.AddSingleton<IBookingRepository>(c => new BookingRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IBookingRoomService, BookingRoomService>();
            services.AddSingleton<IBookingRoomRepository>(c => new BookingRoomRepository(Configuration["ConnectionString"]));

            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository>(c => new CustomerRepository(Configuration["ConnectionString"]));

            services.AddSingleton<ICustomerTypeService, CustomerTypeService>();
            services.AddSingleton<ICustomerTypeRepository>(c => new CustomerTypeRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IDepartmentRepository>(c => new DepartmentRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IPaymentService, PaymentService>();
            services.AddSingleton<IPaymentRepository>(c => new PaymentRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IPhoneNumberService, PhoneNumberService>();
            services.AddSingleton<IPhoneNumberRepository>(c => new PhoneNumberRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IPhoneNumberTypeService, PhoneNumberTypeService>();
            services.AddSingleton<IPhoneNumberTypeRepository>(c => new PhoneNumberTypeRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IReviewService, ReviewService>();
            services.AddSingleton<IReviewRepository>(c => new ReviewRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IRoomService, RoomService>();
            services.AddSingleton<IRoomRepository>(c => new RoomRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IRoomTypeService, RoomTypeService>();
            services.AddSingleton<IRoomTypeRepository>(c => new RoomTypeRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IStaffService, StaffService>();
            services.AddSingleton<IStaffRepository>(c => new StaffRepository(Configuration["ConnectionString"]));

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

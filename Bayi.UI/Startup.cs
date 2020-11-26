using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.Business.Factory;
using Bayi.Business.IService;
using Bayi.Business.IServiceRepository;
using Bayi.Business.Service;
using Bayi.Business.ServiceRepository;
using Bayi.Business.UnitOfWork;
using Bayi.DataAccess;
using Bayi.Utilities.EmailSending;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bayi.UI
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
            services.AddDbContext<BayiDbContext>();
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<BayiDbContext>().AddDefaultTokenProviders();
            services.AddSession();
            services.AddControllersWithViews();
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = $"/Account/Login";
            });
            var emailConfig = Configuration
      .GetSection("EmailConfiguration")
      .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbFactory, DbFactory>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IDealerRepository, DealerRepository>();
            services.AddScoped<IDealerService, DealerService>();


            services.AddScoped<IDealerProductRepository, DealerProductRepository>();
            services.AddScoped<IDealerProductService, DealerProductService>();

            services.AddScoped<IAdminSaleRepository, AdminSaleRepository>();
            services.AddScoped<IAdminSaleService, AdminSaleService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IDealerSaleRepository, DealerSaleRepository>();
            services.AddScoped<IDealerSaleService, DealerSaleService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IErrorRepository, ErrorRepository>();
            services.AddScoped<IErrorService, ErrorService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseExceptionHandler("/account/error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            app.UseStatusCodePagesWithRedirects("/ErrorPage/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

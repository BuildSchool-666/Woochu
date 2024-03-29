using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCModels.Repositories;
using Front.Service.Home;
using Front.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Front.Service.Rooms;
using Front.Service.RoomDetail;
using Front.Service.Order;
using Front.Service.Account_setting;
using Front.Service.Payment.Service;
using Front.Service.Accounts;
using Front.Service.Cloudinarys;

namespace Front
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
            services.AddDbContext<WoochuContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WoochuContext")));
            services.AddScoped<WoochuRepository>();
            services.AddHttpContextAccessor();
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    //options.LoginPath = new PathString("/Account/Login");

                    //options.ReturnUrlParameter = "ReturnUrl";

                    //options.LogoutPath = new PathString("/Account/Logout");

                    //options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                });
                
            services.AddScoped<IRoomsService, RoomsService>(); 
            services.AddScoped<IRoomDetailService, RoomDetailService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<CloudinaryService>();
            services.AddScoped<IAccount_settingService, Account_settingService>();

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

            app.UseAuthentication();

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

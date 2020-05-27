using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using CSD480Group3Capstone001.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSD480Group3Capstone001
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
            services.AddDbContext<ApplicationDbContext>(options => 

              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection"))) ;
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MyDbContext>()
                .AddDefaultTokenProviders();


            //Seting the Account Login page  
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings  
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login  
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout  
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied  
                options.SlidingExpiration = true;
            });

            /*services.AddDbContext<PropertyManagementContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));*/
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        //private async Task CreateUserRoles(IServiceProvider serviceProvider)
        //{
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();


        //    IdentityResult roleResult;
        //    //Adding Addmin Role  
        //    var roleCheck = await RoleManager.RoleExistsAsync("Admin");
        //    if (!roleCheck)
        //    {
        //        //create the roles and seed them to the database  
        //        roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
        //    }
        //    //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
        //    IdentityUser user = await UserManager.FindByEmailAsync("syedshanumcain@gmail.com");
        //    var User = new IdentityUser();
        //    await UserManager.AddToRoleAsync(user, "Admin");

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            /*app.UseAuthentication();
            app.UseAuthorization();*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

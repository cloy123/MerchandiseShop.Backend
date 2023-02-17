using MerchandiseShop.Application;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Persistence;
using MerchandiseShop.WebApp.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

namespace MerchandiseShop.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IMerchShopDbContext).Assembly));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/auth/login";
                options.LogoutPath = "/auth/logout";
                options.AccessDeniedPath = "/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
            });
            services.AddAuthorization();

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/accessdenied", async (HttpContext context) =>
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Access Denied");
                });
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=AuthController}/{action=Login}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Users}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Events}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Holidays}/{action=Index}/{id?}"); ;
            });
        }
    }
}

using MerchandiseShop.Application;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Persistence;
using MerchandiseShop.WebApi.Middleware;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.IO;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Net.Http.Headers;
using MerchandiseShop.WebApi.AuthCommon;

namespace MerchandiseShop.WebApi
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

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = "",
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateAudience = false
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context => {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddAuthorization();

            services.AddSingleton<IJWTManagerRepository, JWTManagerRepository>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
                    ConfigureSwaggerOptions>();
            
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint($"swagger/v1/swagger.json", "MerchShop API");
                config.RoutePrefix = string.Empty;
            });

            app.UseCustomExceptionHandler();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

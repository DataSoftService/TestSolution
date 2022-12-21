using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Threading.Tasks;
using Test.Solution.Application.Module.Services;
using TestSolution.Infrastructure.Database.Communication;
using Unity;

namespace TestSoluction.Distribution.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            container.AddContainerApplication();
            container.AddContainerInfrastructure();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddServiceInfraestruturaGeneral();
            services.AddServiceApplicationGeneral();
            services.AddControllers();
            //services.AddSingleton(typeof(EmailUserUniqueAttribute));
            IdentityModelEventSource.ShowPII = true;
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                       .AddJwtBearer(c =>
                                       {
                                           c.TokenValidationParameters = new TokenValidationParameters
                                           {
                                               ValidateIssuerSigningKey = true,
                                               IssuerSigningKey = new SymmetricSecurityKey(
                                               System.Text.Encoding.ASCII.GetBytes(
                                               Configuration.GetSection("Configuracion:Token").Value)),
                                               ValidateIssuer = false,
                                               ValidateAudience = false,
                                               ValidateLifetime = true,
                                               ClockSkew = TimeSpan.Zero
                                           };
                                           c.Events = new JwtBearerEvents
                                           {
                                               OnAuthenticationFailed = context =>
                                               {
                                                   if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                                   {
                                                       context.Response.Headers.Add("Token-Expired", "El token inspiro");
                                                   }
                                                   return Task.CompletedTask;
                                               }
                                           };
                                       });
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Autorizacion Standar, Usar Bearer. Ejemplo \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });
            services.AddCors();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
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

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            

        }
    }
}

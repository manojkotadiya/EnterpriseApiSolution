using EnterpriseApi.API.Extensions;
using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EnterpriseApi.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJwtAuthentication(Configuration);
            services.AddControllers();

            services.AddApplicationConfiguration(Configuration);
            services.AddPersistence(Configuration);

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultCorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            services.AddScoped<IClientValidationService,
                  ClientValidationService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "AdminOnly",
                    policy =>
                        policy.RequireRole("Admin"));

                options.AddPolicy(
                    "ManagerOnly",
                    policy =>
                        policy.RequireRole("Manager"));

                options.AddPolicy(
                    "AdminOrManager",
                    policy =>
                        policy.RequireRole(
                            "Admin",
                            "Manager"));

                options.AddPolicy(
                    "AuthenticatedUser",
                    policy =>
                        policy.RequireAuthenticatedUser());
            });

            services.AddSwaggerDocumentation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Middleware
            app.UseGlobalExceptionMiddleware();
            app.UseCorrelationIdMiddleware();
            app.UseRequestLoggingMiddleware();
            app.UseResponseLoggingMiddleware();
            app.UseSecurityHeadersMiddleware();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("DefaultCorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Enterprise API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

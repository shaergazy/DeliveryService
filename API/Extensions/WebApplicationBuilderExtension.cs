using API.Infrastructure;
using Common.DTOs;
using DAL.Ef_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.SwaggerUI;
using Common.Extensions;
using Common.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        internal static void RegisterVirtualDir(this IApplicationBuilder app, IConfiguration configuration)
        {
            var settings = configuration.GetSection(nameof(SettingsDto.VirtualDir)).Get<SettingsDto.VirtualDir>();
            var dir = Directory.GetCurrentDirectory().Combine(settings.BaseDir);
            dir.CreateDirectoryIfNotExist();
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(dir),
                RequestPath = new PathString(settings.BaseSuffixUri)
            });
            AppConstants.RelativeFilesPath = settings.BaseDir;
            AppConstants.BaseDir = dir;
        }

        internal static void RegisterSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "DeliveryService API");
                x.RoutePrefix = string.Empty;
                x.DefaultModelExpandDepth(3);
                x.DefaultModelRendering(ModelRendering.Example);
                x.DefaultModelsExpandDepth(-1);
                x.DisplayOperationId();
                x.DisplayRequestDuration();
                x.DocExpansion(DocExpansion.None);
                x.EnableDeepLinking();
                x.EnableFilter();
                x.ShowExtensions();
            });
        }

        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
            var services = app.ApplicationServices.GetService<IServiceProvider>();
            //DatabaseMigrator.SeedDatabaseAsync(services).GetAwaiter().GetResult();
        }
        internal static void ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.RegisterCors(configuration);
            services.AddControllers(x => x.Filters.Add<NoContentFilter>());
            services.AddMvc();
            services.AddSignalR();
            services.AddHttpContextAccessor();
            services.RegisterConnectionString(configuration);
            services.RegisterServices(configuration);

            services.RegisterIOptions(configuration);
            services.RegisterSwagger();
            services.ConfigMapper();
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = configuration["IdentityServer:Authority"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api1");
                });
            });
        }

        internal static WebApplication Configure(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            if (builder.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.RegisterVirtualDir(builder.Configuration);
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();




            app.RegisterSwaggerUI();
            app.UseEndpoints(x => {
                x.MapControllers();
            });
            app.InitializeDatabase();

            return app;
        }
    }
}

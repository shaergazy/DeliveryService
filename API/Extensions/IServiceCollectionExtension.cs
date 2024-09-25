﻿using API.Infrastructure;
using AutoMapper;
using Common.DTOs;
using DAL.Ef_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class IServiceCollectionExtension
    {

        internal static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext>(sp => sp.GetRequiredService<AppDbContext>());
            services.RegisterIOptions(configuration);
        }

        internal static void RegisterCors(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(nameof(SettingsDto.Cors)).Get<SettingsDto.Cors>();
            services.AddCors(x => x.AddDefaultPolicy(b => b
                .WithOrigins(settings.Origins.ToArray())
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()));
        }

        public static void ConfigMapper(this IServiceCollection services)
        {
            services.AddSingleton(_ => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BLL.Infrastructure.AutoMapperProfile());
            }).CreateMapper());
        }
        internal static void RegisterConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("Default")));
        }

        internal static void RegisterIOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthDto.Jwt>(x => configuration.GetSection(nameof(AuthDto.Jwt)).Bind(x));
            services.Configure<SettingsDto.Cors>(x => configuration.GetSection(nameof(SettingsDto.Cors)).Bind(x));
            services.Configure<SettingsDto.ServiceUri>(x => configuration.GetSection(nameof(SettingsDto.ServiceUri)).Bind(x));
        }

        internal static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kinopoisk API",
                    Version = "v1",
                });
                x.DescribeAllParametersInCamelCase();

                x.AddSecurityDefinition(JwtBuilder.Bearer(), new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = JwtBuilder.Authorization(),
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBuilder.Bearer(),
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBuilder.Bearer(),
                        },
                        Scheme = "oauth2",
                        Name = JwtBuilder.Bearer(),
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                },
            });
                x.SchemaFilter<DtoExampleFilter>();

                x.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
            });
        }
    }
}

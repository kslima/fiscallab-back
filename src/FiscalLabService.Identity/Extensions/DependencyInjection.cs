using System.Text;
using FiscalLabService.App.Interfaces;
using FiscalLabService.Identity.Context;
using FiscalLabService.Identity.Resources;
using FiscalLabService.Identity.Services;
using FiscalLabService.Repository.PostgreSql.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FiscalLabService.Identity.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtOptions = configuration
            .GetSection(nameof(JwtOptions))
            .Get<JwtOptions>() ?? new JwtOptions();
        jwtOptions.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key));

        services.AddSingleton(jwtOptions);

        services.AddDbContext<IdentityDataContext>((sp, options) =>
            options.UseNpgsql(sp.GetRequiredService<PostgresOptions>().ConnectionString,
                    builder => { builder.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), null); })
                .EnableSensitiveDataLogging()
        );

        services
            .AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IIdentityService, IdentityService>();

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = jwtOptions.SecurityKey,

            ClockSkew = TimeSpan.Zero
        };

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });
        return services;
    }
}
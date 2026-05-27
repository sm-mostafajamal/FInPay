using System.Text;
using FinPay.Application.Common.Interfaces.Persistence.Repositories;
using FinPay.Application.Common.Interfaces.Services;
using FinPay.Application.Common.Interfaces.Services.Authentication;
using FinPay.Infrastructure.Persistence;
using FinPay.Infrastructure.Persistence.Repositories;
using FinPay.Infrastructure.Services.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FinPay.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();

        services.AddDbContext<FinPayDbContext>(options => {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(
                connectionString, 
                // ServerVersion.AutoDetect(connectionString)
                new MySqlServerVersion(new Version(8, 0, 0))
            );
        });

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettingConfiguration = configuration.GetSection("JwtSetting");
        var jwtSetting = jwtSettingConfiguration.Get<JwtSetting>();
        services.Configure<JwtSetting>(jwtSettingConfiguration);
        services.AddSingleton<IJwtTokenService, JwtTokenService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,

                        ValidAudience = jwtSetting?.Audience,
                        ValidIssuer = jwtSetting?.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSetting.SecretKey))
                   }; 
                });

        return services;
    }
}
using System.Text;
using FinApp.Application.Common.Interfaces.Persistence.Repositories;
using FinApp.Application.Common.Interfaces.Services;
using FinApp.Application.Common.Interfaces.Services.Authentication;
using FinApp.Infrastructure.Persistence;
using FinApp.Infrastructure.Persistence.Repositories;
using FinApp.Infrastructure.Services.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FinApp.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();

        services.AddDbContext<FinAppDbContext>(options => {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(
                connectionString
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
                    options.IncludeErrorDetails = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSetting?.Issuer,
                        ValidAudience = jwtSetting?.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSetting.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine(context.Exception.ToString());
                            return Task.CompletedTask;
                        }
                    };
                });

        return services;
    }
    
}
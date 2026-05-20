using FinPay.Application.Common.Interfaces.Persistence.Repositories;
using FinPay.Application.Common.Interfaces.Services;
using FinPay.Infrastructure.Persistence.Repositories;
using FinPay.Infrastructure.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinPay.Infrastructure;


public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        // services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        var jwtSetting = configuration.GetSection("JwtSetting");
        services.Configure<JwtSetting>(jwtSetting);

        return services;
    }
}
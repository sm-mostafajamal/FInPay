using FinPay.Application.Common.Interfaces.Persistence.Repositories;
using FinPay.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinPay.Infrastructure;


public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        // services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();



        return services;
    }
}
using FinPay.Application.Interfaces.Repositories;
using FinPay.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinPay.Infrastructure;


public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}
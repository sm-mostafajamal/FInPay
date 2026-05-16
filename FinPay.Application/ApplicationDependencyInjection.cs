using FinPay.Application.Common.Behaviour;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinPay.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ApplicationDependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehaviour<,>));
        services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
        
        return services;
    }
}
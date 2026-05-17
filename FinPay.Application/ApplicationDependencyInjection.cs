using System.Reflection;
using FinPay.Application.Common.Behaviour;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinPay.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
            cfg.AddOpenBehavior(typeof(ValidatorBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
        
        return services;
    }
}
using System.Reflection;
using FinApp.Application.Common.Behaviour;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinApp.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidatorBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
        
        return services;
    }
}
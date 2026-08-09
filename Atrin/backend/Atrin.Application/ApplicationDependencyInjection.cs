using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Atrin.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ApplicationDependencyInjection).Assembly;

        services.AddAutoMapper(cfg => cfg.AddMaps(assembly), assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(Common.Behaviors.ValidationBehavior<,>));
        });

        return services;
    }
}




using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Puregold.Application;

public static class DependencyInjection
{
    private static IServiceCollection AddApplication(this IServiceCollection services) =>
        services.AddAutoMapper()
            .AddMediator();

    private static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
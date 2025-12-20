using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Puregold.Application.Abstractions.Repositories;
using Puregold.Infra.Database.Contexts;
using Puregold.Infra.Database.Repositories;

namespace Puregold.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContexts(configuration)
            .AddRepositories();

    private static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PuregoldDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
        
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
        
        return services;
    }
}
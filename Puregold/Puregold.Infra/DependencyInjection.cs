using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Puregold.Application.Abstractions.Authentication;
using Puregold.Application.Abstractions.Repositories;
using Puregold.Infra.Authentication;
using Puregold.Infra.Database.Contexts;
using Puregold.Infra.Database.Repositories;

namespace Puregold.Infra;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(configuration);
        services.AddDbContexts(configuration);
        services.AddRepositories();
    }

    private static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PuregoldDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
    }

    private static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSetting = JwtSetting.FromConfiguration(configuration);
        
        services.AddSingleton(jwtSetting);
        services.AddSingleton<ITokenProvider, TokenProvider>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Secret)),
                    ValidIssuer = jwtSetting.Issuer,
                    ValidAudience = jwtSetting.Audience,
                    ClockSkew = TimeSpan.Zero
                };
            });
    }
}
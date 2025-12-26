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
using Puregold.Infra.Database.Interceptors;
using Puregold.Infra.Database.Repositories;

namespace Puregold.Infra;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddAuthentication(configuration);
            services.AddDbContexts(configuration);
            services.AddInterceptors();
            services.AddRepositories();
        }

        private void AddInterceptors()
        {
            services.AddSingleton<AuditEntitiesInterceptor>();
        }

        private void AddDbContexts(IConfiguration configuration)
        {
            services.AddDbContext<PuregoldDbContext>((sp, opt) =>
            {
                var interceptor = sp.GetRequiredService<AuditEntitiesInterceptor>();

                opt.UseSqlServer(configuration.GetConnectionString("MigrationDb"))
                    .AddInterceptors(interceptor);
            });
        }

        private void AddRepositories()
        {
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private void AddAuthentication(IConfiguration configuration)
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
}
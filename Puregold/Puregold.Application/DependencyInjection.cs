using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Puregold.Application.Behaviors;

namespace Puregold.Application;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public void AddApplication()
        {
            services.AddAutoMapper();
            services.AddMediator();
        }

        private void AddAutoMapper()
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private void AddMediator()
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
                config.AddOpenBehavior(typeof(DbTransactionPipelineBehavior<,>));
            });
        }
    }
}
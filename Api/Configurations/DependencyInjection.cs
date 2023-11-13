using MediatR;
using Core.Messages.Notifications;

namespace APN.WebApi.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // services
            // .AddScoped<IUsuarioRepository, UsuarioRepository>()
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // services
            // .AddScoped<IIdentityService, IdentityService>()
            // .AddScoped<ITokenService, TokenService>();

            return services;
        }

        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            services
            .AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>()
            .AddScoped<INotificationHandler<DomainSuccesNotification>, DomainSuccesNotificationHandler>();

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            // services
            // .AddScoped<IUsuarioQuery, UsuarioQuery>()
            return services;
        }
    }
}

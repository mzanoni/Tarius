using Microsoft.Extensions.DependencyInjection;

namespace Tarius.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDefaultDbConnection(this IServiceCollection services, DefaultConnection connection)
        {
            return services
                .AddScoped<IDbFactory>(provider => new DbFactory(connection));
        }

        public static IServiceCollection AddDbConnection<TDbConnection>(this IServiceCollection services, TDbConnection dbConnection)
            where TDbConnection : Connection
        {
            return services
                .AddScoped<IDbFactory<TDbConnection>>(provider => new DbFactory<TDbConnection>(dbConnection));
        }
    }
}

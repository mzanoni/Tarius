using Microsoft.Extensions.DependencyInjection;

namespace Tarius.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDefaultDbConnection(this IServiceCollection services, DefaultConnection connection, ServiceLifetime? serviceLifetime = null)
    {
        services.Add(new ServiceDescriptor(typeof(DbFactory), _ => new DbFactory(connection), serviceLifetime ?? ServiceLifetime.Scoped));

        return services;
    }

    public static IServiceCollection AddDbConnection<TDbConnection>(this IServiceCollection services, TDbConnection dbConnection, ServiceLifetime? serviceLifetime = null)
        where TDbConnection : Connection
    {
        services.Add(new ServiceDescriptor(typeof(DbFactory<TDbConnection>), _ => new DbFactory<TDbConnection>(dbConnection), serviceLifetime ?? ServiceLifetime.Scoped));

        return services;
    }
}
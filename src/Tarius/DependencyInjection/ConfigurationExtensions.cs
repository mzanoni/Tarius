using System;
using Microsoft.Extensions.Configuration;

namespace Tarius.DependencyInjection;

public static class ConfigurationExtensions
{
    /// <summary>
    ///  Tries to locate a Machine specific connection string by following format '{connectionStringName}.{machineName}', eg "SqlDb.peters-laptop", fall backs to shared "SqlDb" if not specified.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="connectionStringName"></param>
    /// <returns>A connection string</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string GetUserSpecificConnectionString(this IConfiguration configuration, string connectionStringName)
    {
        string? userSpecificConnectionString = configuration.GetConnectionString($"{connectionStringName}.{Environment.MachineName}");

        return
            userSpecificConnectionString.NullIfEmpty() ??
            configuration.GetConnectionString(connectionStringName) ??
            throw new InvalidOperationException($"Unable to get connection string for '{connectionStringName}'.");
    }

    private static string? NullIfEmpty(this string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value;
    }
}
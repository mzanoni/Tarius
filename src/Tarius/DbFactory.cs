using System;
using System.Data.Common;

namespace Tarius;

public class DbFactory<TConnection> : IDbFactory<TConnection>
    where TConnection : Connection
{
    private readonly TConnection _connection;

    public DbFactory(TConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    public DbConnection CreateConnection() => _connection.GetConnection();
}

public class DbFactory : IDbFactory
{
    private readonly IDbFactory<DefaultConnection> _wrappedDbFactory;

    public DbFactory(DefaultConnection connection)
    {
        _wrappedDbFactory = new DbFactory<DefaultConnection>(connection);
    }

    public DbConnection CreateConnection() => _wrappedDbFactory.CreateConnection();
}

using System;
using System.Data.Common;

namespace Tarius;

public class DbFactory<TConnection>(TConnection connection) : IDbFactory<TConnection>
    where TConnection : Connection
{
    private readonly TConnection _connection = connection ?? throw new ArgumentNullException(nameof(connection));

    public DbConnection CreateConnection() => _connection.GetConnection();
}

public class DbFactory(DefaultConnection connection) : IDbFactory
{
    private readonly IDbFactory<DefaultConnection> _wrappedDbFactory = new DbFactory<DefaultConnection>(connection);

    public DbConnection CreateConnection() => _wrappedDbFactory.CreateConnection();
}

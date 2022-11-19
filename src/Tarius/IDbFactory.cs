using System.Data.Common;

namespace Tarius;

// ReSharper disable once UnusedTypeParameter
public interface IDbFactory<TConnection> where TConnection : Connection
{
    DbConnection CreateConnection();
}

public interface IDbFactory : IDbFactory<DefaultConnection>
{
}

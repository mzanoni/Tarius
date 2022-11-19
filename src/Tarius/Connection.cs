using System;
using System.Data.Common;

namespace Tarius;

public abstract class Connection
{
    protected Connection(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException($"{nameof(connectionString)} cannot be null or empty.");

        ConnectionString = connectionString;
    }

    public string ConnectionString { get; }

    public abstract DbConnection GetConnection();
}

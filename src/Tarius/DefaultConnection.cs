using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace Tarius;

public class DefaultConnection(string connectionString) : Connection(connectionString)
{
    public override DbConnection GetConnection() => new SqlConnection(ConnectionString);
}

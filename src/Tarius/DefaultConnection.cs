using System.Data.Common;
using System.Data.SqlClient;

namespace Tarius;

public class DefaultConnection : Connection
{
    public DefaultConnection(string connectionString)
        : base(connectionString)
    {
    }

    public override DbConnection GetConnection() => new SqlConnection(ConnectionString);
}

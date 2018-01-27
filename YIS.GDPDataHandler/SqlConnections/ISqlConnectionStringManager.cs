using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.SqlConnections
{
    public interface ISqlConnectionStringManager
    {
        string GetConnectionStringWith(string connectionNamee);

        string GetDatabaseNameFor(string connectionName);
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Configuration;
using YIS.GDPDataHandler.Helpers;

namespace YIS.GDPDataHandler.SqlConnections
{
    public class SqlConnectionStringManager:ISqlConnectionStringManager
    {
        readonly IApplicationSettings _applicationSettings;
        readonly IConnectionSettings _connectionSettings;

        public SqlConnectionStringManager(
            IApplicationSettings applicationSettings,
            IConnectionSettings connectionSettings)
        {
            _applicationSettings = applicationSettings;
            _connectionSettings = connectionSettings;
        }

        public string GetConnectionStringWith(string connectionName)
        {
            if (connectionName.IsNullEmptyOrWhiteSpace())
                throw new ArgumentNullException
                    (
                        "connectionstring",
                        "db connstring par null or empty"
                    );
            return _connectionSettings.GetConnectionStringBy(connectionName);
        }

        public string GetDatabaseNameFor(string connectoinName)
        {
            string connectionString =
                _connectionSettings.GetConnectionStringBy(connectoinName);

            return new SqlConnectionStringBuilder(connectionString).InitialCatalog;
        }
    }
}

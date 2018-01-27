using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Helpers;

namespace YIS.GDPDataHandler.Configuration
{
    public class ConnectionStringSettings : IConnectionSettings
    {
        readonly IConnectionStringManager _connectionStringManager;

        public ConnectionStringSettings(IConnectionStringManager connectionStringManager)
        {
            _connectionStringManager = connectionStringManager;
        }

        public string GetConnectionStringBy(string connectionStringName)
        {
            if (connectionStringName.IsNullEmptyOrWhiteSpace())
            {
                const string MissingParameter = "ConnectionStringName";
                throw GetMissingApplicationSettingExceptionFor(MissingParameter);
            }

            try
            {
                var connectionString = _connectionStringManager
                    .ConnectionStrings[connectionStringName]
                    .ConnectionString;

                if (connectionString.IsNullEmptyOrWhiteSpace())
                {
                    throw new Exception();
                }
                return connectionString;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private ArgumentNullException GetMissingApplicationSettingExceptionFor(string parameterName)
        {
            const string MissingParameterMessage = "String bad";
            throw new ArgumentNullException(parameterName, string.Format(MissingParameterMessage, parameterName));
        }
    }
}

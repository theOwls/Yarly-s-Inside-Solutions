using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Configuration
{
    public class AwkwardConnectionManager : IConnectionStringManager
    {
        private static ConnectionStringSettingsCollection _connectionStrings;
        public virtual ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                if(_connectionStrings != null)
                {
                    return _connectionStrings;
                }
                _connectionStrings = new ConnectionStringSettingsCollection();
                var webConfigConnectionStrings = ConfigurationManager.ConnectionStrings;

                var connectionStringNames = new List<string>();
                for(var i = 0; i < webConfigConnectionStrings.Count; i++)
                {
                    connectionStringNames.Add(webConfigConnectionStrings[i].Name.ToLower());
                    _connectionStrings.Add(new System.Configuration.ConnectionStringSettings
                    {
                        ConnectionString = webConfigConnectionStrings[i].ConnectionString,
                        Name = webConfigConnectionStrings[i].Name,
                        ProviderName = webConfigConnectionStrings[i].ProviderName
                    });
                }

                var appSettings = ConfigurationManager.AppSettings;
                foreach(var key in appSettings.Keys)
                {
                    if (!connectionStringNames.Contains(key.ToString().ToLower()))
                    {
                        _connectionStrings.Add(new System.Configuration.ConnectionStringSettings
                        {
                            ConnectionString = appSettings[key.ToString()],
                            Name = key.ToString(),
                            ProviderName = "System.Data.SqlClient"
                        });
                    }                    
                }

                return _connectionStrings;
            }
        }

        public void ClearCachedSettings()
        {
            _connectionStrings = null;
        }
    }
}

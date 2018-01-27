using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Configuration;

namespace YIS.GDPDataHandler.Factories
{
    public static class ConnectionStringSettingFactory
    {
        public static IConnectionSettings GetConnectionStringSettings()
        {
            var connectionStringManager = new AwkwardConnectionManager();
            return new ConnectionStringSettings(connectionStringManager);
        }
    }
}

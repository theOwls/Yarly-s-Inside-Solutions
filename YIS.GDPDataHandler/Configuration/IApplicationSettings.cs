using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Configuration
{
    public interface IApplicationSettings
    {
        T Get<T>(string applicationSettingKey);
        bool SettingsExistWith(string applicationSettingKey);
        void ReloadCachedValues();
        T GetIfExists<T>(string applicationSettingKey);
    }
}

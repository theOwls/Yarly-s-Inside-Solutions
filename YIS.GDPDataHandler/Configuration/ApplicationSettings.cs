using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Helpers;

namespace YIS.GDPDataHandler.Configuration
{
    public class ApplicationSettings : IApplicationSettings
    {
        readonly IConfigurationManager _configurationManager;

        public ApplicationSettings(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public T Get<T>(string applicationSettingKey)
        {
            if (applicationSettingKey.IsNullEmptyOrWhiteSpace())
            {
                const string MissingParameter = "applicationSettingKey";
                throw GetMissingApplicationSettingExceptionFor(MissingParameter);
            }
            try
            {
                var applicationSettingValue
                    = _configurationManager.AppSettings[applicationSettingKey];
                if (applicationSettingValue.IsNull())
                {
                    throw new Exception();
                }

                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromInvariantString(applicationSettingValue);
                
            }
            catch
            {
                throw;
            }
        }

        private ArgumentNullException GetMissingApplicationSettingExceptionFor(string parameterName)
        {
            return new ArgumentNullException(parameterName, "Failure");
        }

        public bool SettingsExistWith(string applicationSettingsKey)
        {
            if (applicationSettingsKey.IsNullEmptyOrWhiteSpace())
            {
                throw GetMissingApplicationSettingExceptionFor("appSettingKey");              
            }
            try
            {
                return _configurationManager.AppSettings[applicationSettingsKey].IsNotNull();
            }
            catch
            {
                return false;
            }
        }

        public void ReloadCachedValues()
        {
            _configurationManager.ClearCachedSettings();
        }

        public T GetIfExists<T>(string applicationSettingKey)
        {
            if (!SettingsExistWith(applicationSettingKey))
            {
                return typeof(T).Equals(typeof(String)) ? (T)(object)String.Empty : default(T);
            }

            return Get<T>(applicationSettingKey);

        }
    }
}

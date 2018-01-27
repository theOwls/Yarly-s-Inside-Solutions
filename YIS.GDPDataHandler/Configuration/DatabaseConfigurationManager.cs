using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Data.Infrastructure;
using YIS.GDPDataHandler.Db;

namespace YIS.GDPDataHandler.Configuration
{
    public class DatabaseConfigurationManager : IConfigurationManager
    {
        readonly IUnitOfWork _unitOfWork;

        public DatabaseConfigurationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static NameValueCollection _appSettings;

        public virtual NameValueCollection AppSettings
        {
            get
            {
                if (_appSettings != null)
                {
                    return _appSettings;
                }
                _appSettings = new NameValueCollection();
                var settings = _unitOfWork
                    .GetRepository<AppSetting>()
                    .GetAll()
                    .ToList();

                settings.ForEach(x => _appSettings.Add(x.Key, x.Value));
                return _appSettings;
            }
        }
        public void ClearCachedSettings()
        {
            _appSettings = null;
        }
    }
}

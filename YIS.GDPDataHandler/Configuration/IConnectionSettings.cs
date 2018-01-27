using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Configuration
{
    public interface IConnectionSettings
    {
        string GetConnectionStringBy(string connectionStringName);
    }
}

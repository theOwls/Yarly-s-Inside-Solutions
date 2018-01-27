using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Factories
{
    public interface IEntityDataTableFactory
    {
        DataTable CreateDataTableFrom<T>(List<T> entityList) where T : class;
    }
}

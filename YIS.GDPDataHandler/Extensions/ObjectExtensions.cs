using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object o)
        {
            return o != null;
        }
    }
}

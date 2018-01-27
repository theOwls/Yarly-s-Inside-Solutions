using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Extensions
{
    public static class BooleanExtensions
    {
        public static bool IsFalse(this bool b)
        {
            return b == false;
        }
    }
}

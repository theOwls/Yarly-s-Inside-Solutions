using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Helpers
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object o)
        {
            return o == null;
        }

        public static bool IsNotNull(this object o)
        {
            return o != null;
        }

        public static T GetDefaultValue<T>(this object o)
        {
            Type objectType = o.GetType();

            if(objectType == typeof(String))
            {
                return (T)(object)String.Empty;
            }

            return default(T);
        }

        public static bool Is<T>(this object o)
        {
            return o is T || o.GetType() == typeof(T);
        }
        
        public static bool IsNot<T>(this object o)
        {
            return o.Is<T>();
        }
    }
}

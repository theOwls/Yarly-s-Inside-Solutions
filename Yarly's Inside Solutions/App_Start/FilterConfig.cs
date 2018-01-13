using System.Web;
using System.Web.Mvc;

namespace Yarly_s_Inside_Solutions
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

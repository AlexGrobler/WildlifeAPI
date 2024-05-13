using System.Web;
using System.Web.Mvc;
#pragma warning disable
namespace WildlifeAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

using NovoRumoProjeto.Utilities.Filters;
using System.Web.Mvc;

namespace NovoRumoProjeto
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleAndLogErrorAtribute());
        }
    }
}

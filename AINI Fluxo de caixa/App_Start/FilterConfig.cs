using System.Web;
using System.Web.Mvc;

namespace AINI_Fluxo_de_caixa
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

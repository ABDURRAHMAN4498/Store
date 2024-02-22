using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    //taghelperler ilgili yönlendirmeyi yapabilmesi
    //endpointler ile controller eşleşmesi için bu attribut ifadesine ihtiyac var 
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
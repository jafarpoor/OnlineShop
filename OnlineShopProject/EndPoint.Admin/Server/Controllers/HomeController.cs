using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Admin.Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Admin.Server.Controllers
{
    [Route("api/ProductType")]
    [ApiController]
    [Authorize]
    public class ProductTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

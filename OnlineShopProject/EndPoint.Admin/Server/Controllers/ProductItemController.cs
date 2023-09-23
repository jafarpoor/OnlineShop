using Application.Interface.Base;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Admin.Server.Controllers
{
    public class ProductItemController : Controller
    {
        private readonly IUnitOfWork _uox;
         public  ProductItemController(IUnitOfWork uox)
         {
            _uox= uox;
         }

        [HttpGet]
        public IActionResult GetPLPPRoductItem()
        {
            var Result = _uox.ProductItemRepository.GetProductItemPLPList();
            return Json(Result);
        }

        [HttpGet]
        public IActionResult GetPDPProductItem()
        {
            var Result = _uox.ProductItemRepository.GetProductItemPDPList();
            return Json(Result);
        }
    }
}

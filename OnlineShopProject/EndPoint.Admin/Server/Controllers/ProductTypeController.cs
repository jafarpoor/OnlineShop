using Application.ViewModel.Users;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModel.Products;
using Domain.Entity;
using Application.Interface.Base;

namespace EndPoint.Admin.Server.Controllers
{
    [Route("api/ProductType")]
    [ApiController]
    //[Authorize]
    public class ProductTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Save")]
        public ActionResult Save([FromBody] ProductTypeViewModel model)
        {
            //Massage
            ProductType productType = new ProductType
            {
                ProductTypeName = model.ProductTypeName,
            };
            _unitOfWork.ProductTypeRepository.Insert(productType);
            _unitOfWork.Save();
            return Json(new BaseDto { IsSuccess = true, Message = "" });
        }
    }
}

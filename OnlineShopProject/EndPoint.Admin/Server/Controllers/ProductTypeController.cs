using Application.Interface.Base;
using Application.ViewModel;
using Application.ViewModel.Products;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using RM = Resoures.Messages;
namespace EndPoint.Admin.Server.Controllers
{
    //[Route("api/ProductType")]
    //[ApiController]
    //[Authorize]
    public class ProductTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult Save([FromBody] ProductTypeViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ProductTypeName))
                    return Json(new BaseDto { IsSuccess = false, Message = RM.EnterProductName });

                ProductType productType = new ProductType
                {
                    ProductTypeName = model.ProductTypeName,
                };
                _unitOfWork.ProductTypeRepository.Insert(productType);
                _unitOfWork.Save();
                return Json(new BaseDto { IsSuccess = true, Message = "" });
            }
            catch (Exception ex)
            {
                return Json(new BaseDto { IsSuccess = false, Message = ex.Message.ToString() });
            }
        }

        [HttpPost]
        public ActionResult Update([FromBody] ProductTypeViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ProductTypeName))
                    return Json(new BaseDto { IsSuccess = false, Message = RM.EnterProductName });
                var Result = new ProductType
                {
                    ProductTypeName = model.ProductTypeName,
                    ID = model.Id
                };
                _unitOfWork.ProductTypeRepository.Insert(Result);
                _unitOfWork.Save();
                return Json(new BaseDto { IsSuccess = true, Message = RM.SuccessUpdateMsg });
            }
            catch (Exception ex)
            {
                return Json(new BaseDto { IsSuccess = false,Message = ex.Message.ToString() });
            } 
        }

        [HttpPost]
        public ActionResult Delete([FromBody]long Id)
        {
            try
            {
                var Result = _unitOfWork.ProductTypeRepository.Get(p => p.ID == Id).SingleOrDefault();
                if (Result is null)
                    return Json(new BaseDto { IsSuccess = false, Message = RM.NoRecords });
                else
                {
                    _unitOfWork.ProductTypeRepository.Delete(Result);
                    _unitOfWork.Save();
                    return Json(new BaseDto { IsSuccess = true, Message = RM.SuccessDeleteMsg });
                }
            }
            catch (Exception ex)
            {
                return Json(new BaseDto { IsSuccess = false, Message = ex.Message.ToString() });
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            var Result = _unitOfWork.ProductTypeRepository.Get().Select(p => new ProductTypeViewModel
            {
                Id = p.ID,
                ProductTypeName = p.ProductTypeName
            }).OrderBy(p => p.Id).ToList();
            return Json(Result);
        }
    }
}

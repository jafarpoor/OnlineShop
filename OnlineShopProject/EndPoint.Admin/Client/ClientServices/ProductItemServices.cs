using Application.ViewModel;
using Application.ViewModel.Products;
using Authorize.Base;
using System;

namespace EndPoint.Admin.Client.ClientServices
{
    public class ProductItemServices : HttpService<ProductItemPDPViewModel>
    {
        public ProductItemServices(IBaseHttpService baseHttpService) : base(baseHttpService)
        {

        }

        public async Task<BaseDto<ProductItemPDPViewModel>> GetPDPProductItem(string url)
        {
            var Result = await GetAll<BaseDto<ProductItemPDPViewModel>>(url);
            return Result;

        }

        public async Task<BaseDto<ProductItemPLPViewModel>> GetPLPProductItem(string url)
        {
            var Result = await GetAll<BaseDto<ProductItemPLPViewModel>>(url);
            return Result;
        }
    }
}

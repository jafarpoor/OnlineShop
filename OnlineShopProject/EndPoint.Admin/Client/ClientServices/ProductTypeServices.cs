using Application.ViewModel.Users;
using Application.ViewModel;
using EndPoint.Admin.Client.ClientServices.Base;
using Application.ViewModel.Products;

namespace EndPoint.Admin.Client.ClientServices
{
    public class ProductTypeServices : HttpService<ProductTypeViewModel>
    {
        public ProductTypeServices(IBaseHttpService baseHttpService) : base(baseHttpService)
        {
        }

        public async Task<BaseDto> Add(string url, ProductTypeViewModel data)
        {
            var resp = await PostEntity<ProductTypeViewModel, BaseDto>(data, url);
            return resp;
        }

        public async Task<BaseDto<List<ProductTypeViewModel>>> Get(string url)
        {
            var resp = await GetAll<BaseDto<List<ProductTypeViewModel>>>(url);
            return resp;
        }

        public async Task<BaseDto> Delete(string url, long id)
        {
            var resp = await PostEntity<long, BaseDto>(id, url);
            return resp;
        }

        public async Task<BaseDto> Update(string url, ProductTypeViewModel data)
        {
            var resp = await PostEntity<ProductTypeViewModel, BaseDto>(data, url);
            return resp;
        }
    }
}

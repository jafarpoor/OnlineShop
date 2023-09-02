using Application.ViewModel;
using Application.ViewModel.Users;
using Authorize.Base;

namespace Authorize.Services;

public class UserServices : HttpService<RegisterUserViewModel>
{
    public UserServices(IBaseHttpService baseHttpService) : base(baseHttpService)
    {
    }

    public async Task<BaseDto> Add(string url, RegisterUserViewModel data)
    {
        var resp = await PostEntity<RegisterUserViewModel, BaseDto>(data, url);
        return resp;
    }

    public async Task<BaseDto<List<RegisterUserViewModel>>> Get(string url)
    {
        var resp = await GetAll<BaseDto<List<RegisterUserViewModel>>>(url);
        return resp;
    }

    public async Task<BaseDto> Delete(string url, long id)
    {
        var resp = await PostEntity<long, BaseDto>(id, url);
        return resp;
    }

    public async Task<BaseDto> Update(string url, RegisterUserViewModel data)
    {
        var resp = await PostEntity<RegisterUserViewModel, BaseDto>(data, url);
        return resp;
    }

}




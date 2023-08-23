namespace EndPoint.Admin.Client.ClientServices.Base;

public class HttpService<T> : IHttpService<T>
{
    private readonly IBaseHttpService _baseHttpService;

    public HttpService(IBaseHttpService baseHttpService)
    {
        _baseHttpService = baseHttpService;
    }

    #region GetMethod

    public async Task<T> GetByID(string uri, long id)
    {
        var resp = await _baseHttpService.GetByID<T>(uri, id);

        if (!resp.IsSuccess)
            throw new Exception("خطا در دریافت اطلاعات" + " " + resp.GetErrorMessage());

        return resp.ResponseDeserialize == null
           ? throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage())
           : resp.ResponseDeserialize;
    }

    public async Task<List<T>> GetByFkID(string uri)
    {
        var resp = await _baseHttpService.GetByFKID<List<T>>(uri);
        if (!resp.IsSuccess)
            throw new Exception("خطا در دریافت اطلاعات" + " " + resp.GetErrorMessage());

        return resp.ResponseDeserialize == null
             ? throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage())
             : resp.ResponseDeserialize;
    }

    public async Task<List<T>> GetAll(string uri)
    {
        var resp = await _baseHttpService.GetAll<List<T>>(uri);
        if (!resp.IsSuccess)
            throw new Exception("خطا در دریافت اطلاعات" + " " + resp.GetErrorMessage());

        return resp.ResponseDeserialize == null
            ? throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage())
            : resp.ResponseDeserialize;
    }



    public async Task<IQueryable<T>> GetAllIQueryable(string uri)
    {
        var resp = await _baseHttpService.GetAll<IQueryable<T>>(uri);
        if (!resp.IsSuccess)
            throw new Exception("خطا در دریافت اطلاعات" + " " + resp.GetErrorMessage());

        return resp.ResponseDeserialize == null
            ? throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage())
            : resp.ResponseDeserialize;
    }

    public async Task<List<T>> GetByCustomClause<TInput>(string uri, TInput input)
    {
        var resp = await _baseHttpService.GetByCustomClause<List<T>, TInput>(uri, input);
        if (!resp.IsSuccess)
            throw new Exception("خطا در دریافت اطلاعات" + " " + resp.GetErrorMessage());

        return resp.ResponseDeserialize == null
            ? throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage())
            : resp.ResponseDeserialize;
    }

    public async Task<T> GetByInput(string uri, string input)
    {
        var resp = await _baseHttpService.GetByInput<T>(uri, input);
        if (!resp.IsSuccess)
            throw new Exception("خطا در دریافت اطلاعات" + " " + resp.GetErrorMessage());

        return resp.ResponseDeserialize == null
             ? throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage())
             : resp.ResponseDeserialize;
    }

    public async Task<(Tresp, int)> GetApiWithRespHeader<Tresp>(string url, int page, int quatityPerPage)
    {
        var resp = await _baseHttpService.GetApiWithRespHeader<Tresp>(url, page, quatityPerPage);
        if (!resp.IsSuccess)
            throw new Exception("خطا در دریافت اطلاعات" + " " + resp.GetErrorMessage());

        var TotalPage = resp.Quantity;
        return resp.ResponseDeserialize == null
       ? throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage())
       : (resp.ResponseDeserialize, TotalPage);
    }

    public async Task<TResult> GetAll<TResult>(string uri)
    {
        var resp = await _baseHttpService.GetAll<TResult>(uri);
        if (!resp.IsSuccess)
            throw new Exception("خطا در دریافت اطلاعات" + " " + resp.GetErrorMessage());

        return resp.ResponseDeserialize == null
            ? throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage())
            : resp.ResponseDeserialize;
    }

    #endregion GetMethod

    #region PostMethod

    public async Task PostEntity(T Entity, string uri)
    {
        var resp = await _baseHttpService.PostApi(uri, Entity);
        if (!resp.IsSuccess)
            throw new Exception("خطا در ثبت اطلاعات : " + resp.GetErrorMessage());
    }

    public async Task<TResult> PostEntity<TEntity, TResult>(TEntity Entity, string uri)
    {
        HttpResponseWrapper<TResult> resp = await _baseHttpService.PostApi<TEntity, TResult>(uri, Entity);

        if (!resp.IsSuccess)
            throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage());

        return resp.ResponseDeserialize == null
            ? throw new Exception("خطا در ارسال اطلاعات : " + resp.GetErrorMessage())
            : resp.ResponseDeserialize;
    }

    #endregion PostMethod
}
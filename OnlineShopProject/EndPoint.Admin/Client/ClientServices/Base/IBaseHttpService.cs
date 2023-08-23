namespace EndPoint.Admin.Client.ClientServices.Base;

public interface IBaseHttpService
{
    #region GetMethod

    Task<HttpResponseWrapper<TResult>> GetByID<TResult>(string url, long Id);
    Task<HttpResponseWrapper<TResult>> GetByFKID<TResult>(string url);
    Task<HttpResponseWrapper<TResult>> GetAll<TResult>(string url);
    Task<HttpResponseWrapper<TResult>> GetByCustomClause<TResult, Tinput>(string url, Tinput input);
    Task<HttpResponseWrapper<TResult>> GetByInput<TResult>(string url, string input);
    Task<HttpResponseWrapper<TResult>> GetApiWithRespHeader<TResult>(string url, int page, int quatityPerPage);

    #endregion GetMethod

    #region PostMethod

    Task<HttpResponseWrapper<object>> PostApi<T>(string url, T data);
    Task<HttpResponseWrapper<TResult>> PostApi<T, TResult>(string url, T data);

    #endregion PostMethod
}
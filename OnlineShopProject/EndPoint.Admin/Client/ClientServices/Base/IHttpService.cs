namespace EndPoint.Admin.Client.ClientServices.Base;

public interface IHttpService<T>
{
    /// <summary>
    /// پست کردن با موجودیت اصلی - خروجی ندارد
    /// </summary>
    Task PostEntity(T Entity, string uri);

    /// <summary>
    /// پست کردن با موجودیت دلخواه و خروجی دلخواه
    /// </summary>
    Task<TResult> PostEntity<TEntity, TResult>(TEntity Entity, string uri);

    Task<T> GetByID(string uri, long id);

    Task<T> GetByInput(string uri, string input);

    Task<(TResult, int)> GetApiWithRespHeader<TResult>(string url, int page, int quatityPerPage);

    Task<List<T>> GetAll(string uri);

    /// <summary>
    ///خروجی دلخواه 
    /// </summary>
    Task<TResult> GetAll<TResult>(string uri);

    Task<List<T>> GetByFkID(string uri);
}
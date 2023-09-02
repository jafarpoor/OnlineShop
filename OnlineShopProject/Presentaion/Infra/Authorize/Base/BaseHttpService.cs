using System.Text;
using System.Text.Json;

namespace Authorize.Base;

public class BaseHttpService : IBaseHttpService
{
    private readonly HttpClient _httpClient;
    public BaseHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    #region GetMethod

    public async Task<HttpResponseWrapper<TResult>> GetByID<TResult>(string url, long Id)
    {
        var fullUri = "/" + url + Id;
        var response = await _httpClient.GetAsync(fullUri);

        //will throw an exception if not successful
        // response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            var DesResult = JsonSerializer.Deserialize<TResult>(content, options);

            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<TResult>(DesResult, response.IsSuccessStatusCode, response);
            }
            else
            {
                return new HttpResponseWrapper<TResult>(default, response.IsSuccessStatusCode, response);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("GetByID : " + ex.Message);
        }
    }

    public async Task<HttpResponseWrapper<TResult>> GetByFKID<TResult>(string url)
    {
        var fullUri = "/" + url;
        var response = await _httpClient.GetAsync(fullUri);

        //will throw an exception if not successful
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var DesResult = JsonSerializer.Deserialize<TResult>(content, options);
        if (response.IsSuccessStatusCode)
        {
            return new HttpResponseWrapper<TResult>(DesResult, response.IsSuccessStatusCode, response);
        }
        else
        {
            return new HttpResponseWrapper<TResult>(default, response.IsSuccessStatusCode, response);
        }
    }

    public async Task<HttpResponseWrapper<TResult>> GetAll<TResult>(string url)
    {
        var fullUri = "/" + url;
        var response = await _httpClient.GetAsync(fullUri);
        string content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            var DesResult = JsonSerializer.Deserialize<TResult>(content, options);

            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<TResult>(DesResult, response.IsSuccessStatusCode, response);
            }
            else
            {
                return new HttpResponseWrapper<TResult>(default, response.IsSuccessStatusCode, response);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("GetAll : " + ex.Message);
        }
    }

    public async Task<HttpResponseWrapper<TResult>> GetByCustomClause<TResult, Tinput>(string url, Tinput input)
    {
        var dataJson = JsonSerializer.Serialize(input);

        var c2 = new StringContent(dataJson, Encoding.UTF8, "application/json");
        var resp = await _httpClient.PostAsync(url, c2);

        var apiResponse = resp.Content.ReadAsStringAsync().Result;

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var DesResult = JsonSerializer.Deserialize<TResult>(apiResponse, options);
        if (resp.IsSuccessStatusCode)
        {
            return new HttpResponseWrapper<TResult>(DesResult, resp.IsSuccessStatusCode, resp);
        }
        else
        {
            return new HttpResponseWrapper<TResult>(default, resp.IsSuccessStatusCode, resp);
        }
    }

    public async Task<HttpResponseWrapper<TResult>> GetByInput<TResult>(string url, string input)
    {
        var fullUri = "/" + url + input;
        var response = await _httpClient.GetAsync(fullUri);
        string content = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            var DesResult = JsonSerializer.Deserialize<TResult>(content, options);

            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<TResult>(DesResult, response.IsSuccessStatusCode, response);
            }
            else
            {
                return new HttpResponseWrapper<TResult>(default, response.IsSuccessStatusCode, response);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("GetByInput : " + ex.Message);
        }
    }

    public async Task<HttpResponseWrapper<TResult>> GetApiWithRespHeader<TResult>(string url, int page, int quatityPerPage)
    {
        var fullUri = "/" + url + $"?page={page}&quantityPerPage={quatityPerPage}";
        var response = await _httpClient.GetAsync(fullUri);

        //will throw an exception if not successful
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            var DesResult = JsonSerializer.Deserialize<TResult>(content, options);
            if (response.IsSuccessStatusCode)
            {
                var tmp = response.Headers.GetValues("pagesQuantity").FirstOrDefault();
                var Quantity = tmp == null ? 0 : int.Parse(tmp);

                return new HttpResponseWrapper<TResult>(DesResult, response.IsSuccessStatusCode, Quantity, response);
            }
            else
            {
                return new HttpResponseWrapper<TResult>(default, response.IsSuccessStatusCode, response);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("GetApiWithRespHeader : " + ex.Message);
        }
    }

    #endregion

    #region PostMethod

    public async Task<HttpResponseWrapper<object>> PostApi<T>(string url, T data)
    {
        var dataJson = JsonSerializer.Serialize(data);
        var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
        var resp = await _httpClient.PostAsync(url, stringContent);
        return new HttpResponseWrapper<object>(null, resp.IsSuccessStatusCode, resp);
    }

    public async Task<HttpResponseWrapper<TResult>> PostApi<T, TResult>(string url, T data)
    {
        var json = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        var dataJson = JsonSerializer.Serialize(data, json);
        var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
        var resp = await _httpClient.PostAsync(url, stringContent);
        var apiResponse = resp.Content.ReadAsStringAsync().Result;
        var DesResult = JsonSerializer.Deserialize<TResult>(apiResponse, json);

        if (resp.IsSuccessStatusCode)
        {
            return new HttpResponseWrapper<TResult>(DesResult, resp.IsSuccessStatusCode, resp);
        }
        else
        {
            return new HttpResponseWrapper<TResult>(default, resp.IsSuccessStatusCode, resp);
        }

    }

    #endregion
}

public class HttpResponseWrapper<T>
{
    public bool IsSuccess { get; set; }
    public T? ResponseDeserialize { get; set; }
    public HttpResponseMessage ResponseMessage { get; set; }
    public int Quantity { get; set; }

    public HttpResponseWrapper(T? responseDeserial, bool isSuccess, HttpResponseMessage message)
    {
        IsSuccess = isSuccess;
        ResponseDeserialize = responseDeserial;
        ResponseMessage = message;

    }
    public HttpResponseWrapper(T? responseDeserial, bool isSuccess, int quantity, HttpResponseMessage message)
    {
        IsSuccess = isSuccess;
        ResponseDeserialize = responseDeserial;
        ResponseMessage = message;
        Quantity = quantity;
    }
    public async Task<string> GetErrorMessage()
    {
        return await ResponseMessage.Content.ReadAsStringAsync();

    }
}
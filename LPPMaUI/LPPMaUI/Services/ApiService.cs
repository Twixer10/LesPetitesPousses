using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using LPPMaUI.Commons;
using LPPMaUI.Helper.Interfaces;
using LPPMaUI.Models.DTOs;
using LPPMaUI.Services.Interfaces;
using Newtonsoft.Json;

namespace LPPMaUI.Services;

public class ApiService : IApiService
{
    #region Private
    
    private readonly IHttpClientHelper _httpClientHelper;

    #endregion
    
    #region Constructor
    
    public ApiService(IHttpClientHelper httpClientHelper)
    {
        _httpClientHelper = httpClientHelper;
    }
    
    #endregion
    
    
        
    public async Task<DataTransferResult<TResult>> CallApiAsync<TResult>(string url, HttpMethod method, bool isAuth = false, string json = null, Dictionary<string, string> parameters = null,
        CancellationToken cancellationToken = default) where TResult : class
    {
        try
        {
            var client = _httpClientHelper.GetHttpClient();
            if (client is null)
                return null;
            
            var httpRequestMessage = new HttpRequestMessage {Method = method, RequestUri = new Uri(Constants.ApiUrl + url)};
            
            if (method == HttpMethod.Post &&  parameters != null)
                httpRequestMessage.Content = new FormUrlEncodedContent(parameters);
            else if (method != HttpMethod.Get)
                httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

            if (isAuth && !string.IsNullOrEmpty(Preferences.Get("AccessToken", string.Empty)))
            {
                if (client.DefaultRequestHeaders.Contains("Authorization"))
                    client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("AccessToken", string.Empty));
                
            }
            
            var result = await client.SendAsync(httpRequestMessage, cancellationToken);
            
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<TResult>(content);

                return new DataTransferResult<TResult>
                {
                    Message = "Success",
                    Result = data,
                    StatusCode = result.StatusCode
                };
            }
            else
            {
                var data = await result.Content.ReadAsStringAsync();
                var error = JsonNode.Parse(data);
                var message = "Une erreur est survenue";
                if (error?["message"] != null)
                    message = (string)error["message"];
                return new DataTransferResult<TResult>
                {
                    Message = message,
                    StatusCode = result.StatusCode
                };
            }
        }
        catch (Exception e)
        {
            return new DataTransferResult<TResult>
            {
                Message = $"{e.Message} in route {Constants.ApiUrl + url}",
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<DataTransferResult<TResult>> SendFileApiAsync<TResult>(string url, string filePath) where TResult : class
    {
        try
        {
            var client = _httpClientHelper.GetHttpClient();
            if (client is null)
                return null;
            using var form = new MultipartFormDataContent();
            using var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(filePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            form.Add(fileContent, "formFile", Path.GetFileName(filePath));

            if (client.DefaultRequestHeaders.Contains("Authorization"))
                client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("AccessToken", string.Empty));
            var response = await client.PostAsync(new Uri(Constants.ApiUrl + url), form);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<TResult>(content);
                return new DataTransferResult<TResult>
                {
                    Message = "Success",
                    Result = data,
                    StatusCode = response.StatusCode
                };
            }
            else
            {
                return new DataTransferResult<TResult>
                {
                    Message = response.Content.ToString(),
                    StatusCode = response.StatusCode
                };
            }
        }
        catch (Exception e)
        {
            return new DataTransferResult<TResult>
            {
                Message = $"{e.Message} in route {Constants.ApiUrl + url}",
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
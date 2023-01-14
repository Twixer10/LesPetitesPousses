using LPPMaUI.Models.DTOs;

namespace LPPMaUI.Services.Interfaces;

public interface IApiService
{
    public Task<DataTransferResult<TResult>> CallApiAsync<TResult>(string url, HttpMethod method, bool isAuth = false, string json = null, Dictionary<string, string> parameters = null, CancellationToken cancellationToken = default) where TResult : class;

    public Task<DataTransferResult<TResult>> SendFileApiAsync<TResult>(string url, string filePath) where TResult : class;
}
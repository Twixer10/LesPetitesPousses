using System.Net;

namespace LPPMaUI.Models.DTOs;

public class DataTransferResult<T>
{

    public HttpStatusCode StatusCode { get; set; }
    public T Result { get; set; }
    public string Message { get; set; }
    
}
using System.Net;


namespace SChainIntro_MVC.BLL.Common.Exceptions;


public class StatusCodeException(HttpStatusCode statusCode,
                                 string message)
    : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}

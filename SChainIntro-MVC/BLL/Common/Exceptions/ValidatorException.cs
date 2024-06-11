using System.Net;


namespace SChainIntro_MVC.BLL.Common.Exceptions;


public class ValidatorException : StatusCodeException
{
    public ValidatorException(HttpStatusCode statusCode, string message)
        : base(statusCode, message) { }
}

using FluentValidation.Results;
using System.Text;

namespace SChainIntro_MVC.BLL.Common.Validator;

public static class Extension
{
    public static string GetErrorMessage(this ValidationResult result)
    {
        var resultMessage = new StringBuilder();
        foreach (var error in result.Errors)
        {
            resultMessage.Append(error.ErrorMessage);
        }

        return resultMessage.ToString();
    }
}

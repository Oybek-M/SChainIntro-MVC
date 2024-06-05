using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;


namespace SChainIntro_MVC.BLL.Common.Validator;

public static class Extension
{
    public static string GetErrorMessage(this ValidationResult result)
    {
        var resultMessage = new StringBuilder();
        foreach (var error in result.ErrorMessage)
        {
            resultMessage.Append(error);
        }

        return resultMessage.ToString();
    }
}

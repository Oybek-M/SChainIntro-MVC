using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.Common.Validator;

public class ServiceValidator : AbstractValidator<Service>
{
    public ServiceValidator()
    {
        RuleFor(x => x.ImagePath)
            .NotEmpty().WithMessage("Image is required");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(1, 30).WithMessage("Title must be between 1 and 30 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required");
    }
}

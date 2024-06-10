using FluentValidation;
using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.Common.Validator.Validator;

public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Title is required")
            .Length(1, 30).WithMessage("Title must be between 1 and 30 characters");

        RuleFor(p => p.Content).NotEmpty().WithMessage("Content is required")
            .Length(1, 350).WithMessage("Contetn must be 1 and 350 characterrs");
    }
}
using FluentValidation;
using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.Common.Validator.Validator;

public class VideoValidator : AbstractValidator<Video>
{
    public VideoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .Length(1, 30).WithMessage("Name must be between 1 and 30 characters");

        RuleFor(x => x.VideoURL)
            .NotEmpty().WithMessage("Video`s URL is Required1");
    }
}
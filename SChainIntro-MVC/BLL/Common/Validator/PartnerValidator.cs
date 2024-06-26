﻿using FluentValidation;
using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.BLL.Common.Validator.Validator;


public class PartnerValidator : AbstractValidator<Partner>
{
    public PartnerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(1, 30).WithMessage("Name must be between 1 and 30 characters");
    }
}
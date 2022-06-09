﻿using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class RebarworksFootingInputValidator : AbstractValidator<RebarworksFootingInputModel>
    {
        public RebarworksFootingInputValidator()
        {
            RuleFor(input => input.LengthOfFooting)
                .NotEmpty()
                .WithMessage("Length of Footing is required");

            RuleFor(input => input.WidthOfFooting)
               .NotEmpty()
               .WithMessage("Width of Footing is required");

            RuleFor(input => input.ThicknessOfFooting)
               .NotEmpty()
               .WithMessage("Thickness of Footing is required");

            RuleFor(input => input.NumbersOfCount)
               .NotEmpty()
               .WithMessage("Numbers of Count/s is required");
        }
    }
}
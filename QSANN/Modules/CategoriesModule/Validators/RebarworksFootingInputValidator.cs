using CategoriesModule.Models;
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

            RuleFor(input => input.NumbersOfFooting)
               .NotEmpty()
               .WithMessage("Numbers of Footing is required");

            RuleFor(input => input.SizeOfSteelbar)
                .NotEmpty()
                .WithMessage("Size of Steel Bar is required");

            RuleFor(input => input.SpacingOfSteelbar)
                .NotEmpty()
                .WithMessage("Spacing of Steel Bar is required");
        }
    }
}
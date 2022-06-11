using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class RebarworksColumnInputValidator : AbstractValidator<RebarworksColumnInputModel>
    {
        public RebarworksColumnInputValidator()
        {
            RuleFor(input => input.LengthOfColumn)
                .NotEmpty()
                .WithMessage("Length of Column is required");

            RuleFor(input => input.WidthOfColumn)
               .NotEmpty()
               .WithMessage("Width of Column is required");

            RuleFor(input => input.HeightOfColumn)
               .NotEmpty()
               .WithMessage("Height of Column is required");

            RuleFor(input => input.NumbersOfColumn)
               .NotEmpty()
               .WithMessage("Numbers of Column is required");

            RuleFor(input => input.SizeOfMainbar)
               .NotEmpty()
               .WithMessage("Size of Main bar is required");

            RuleFor(input => input.SizeOfLateralties)
               .NotEmpty()
               .WithMessage("Size of Lateral Ties is required");
        }
    }
}
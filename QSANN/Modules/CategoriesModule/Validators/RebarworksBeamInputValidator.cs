using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class RebarworksBeamInputValidator : AbstractValidator<RebarworksBeamInputModel>
    {
        public RebarworksBeamInputValidator()
        {
            RuleFor(input => input.LengthOfBeam)
                .NotEmpty()
                .WithMessage("Length of Beam is required");

            RuleFor(input => input.WidthOfBeam)
               .NotEmpty()
               .WithMessage("Width of Beam is required");

            RuleFor(input => input.HeightOfBeam)
               .NotEmpty()
               .WithMessage("Height of Beam is required");

            RuleFor(input => input.NumbersOfBeam)
               .NotEmpty()
               .WithMessage("Numbers of Count/s is required");

            RuleFor(input => input.WidthOfColumn)
                .NotEmpty()
                .WithMessage("Width of Column is required");

        }
    }
}
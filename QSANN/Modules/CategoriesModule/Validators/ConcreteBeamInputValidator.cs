using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class ConcreteBeamInputValidator : AbstractValidator<ConcreteBeamInputModel>
    {
        public ConcreteBeamInputValidator()
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

            RuleFor(input => input.NumbersOfCount)
               .NotEmpty()
               .WithMessage("Numbers of Count/s is required");
        }
    }
}
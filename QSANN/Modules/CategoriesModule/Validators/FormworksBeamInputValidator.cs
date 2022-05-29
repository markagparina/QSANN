using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class FormworksBeamInputValidator : AbstractValidator<FormworksBeamInputModel>
    {
        public FormworksBeamInputValidator()
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

            RuleFor(input => input.NumberOfCounts)
               .NotEmpty()
               .WithMessage("Numbers of Count/s is required");
        }
    }
}

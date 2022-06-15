using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class RebarworksSlabInputValidator : AbstractValidator<RebarworksSlabInputModel>
    {
        public RebarworksSlabInputValidator()
        {
            RuleFor(input => input.FloorArea)
                .NotEmpty()
                .WithMessage("Floor Area is required");

            RuleFor(input => input.SteelbarSpacing)
               .NotEmpty()
               .WithMessage("Steel Bar Spacing is required");

            RuleFor(input => input.SizeOfSteelbar)
               .NotEmpty()
               .WithMessage("Size of Steel Bar is required");

            RuleFor(input => input.OneWayOrTwoWay)
                .IsInEnum()
                .WithMessage("Slab Type is required");
        }
    }
}
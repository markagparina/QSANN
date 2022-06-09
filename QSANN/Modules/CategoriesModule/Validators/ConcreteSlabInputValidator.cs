using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class ConcreteSlabInputValidator : AbstractValidator<ConcreteSlabInputModel>
    {
        public ConcreteSlabInputValidator()
        {
            RuleFor(input => input.LengthOfSlab)
                .NotEmpty()
                .WithMessage("Length of Slab is required");

            RuleFor(input => input.WidthOfSlab)
               .NotEmpty()
               .WithMessage("Width of Slab is required");

            RuleFor(input => input.ThicknessOfSlab)
               .NotEmpty()
               .WithMessage("Thickness of Slab is required");

            RuleFor(input => input.NumbersOfCount)
               .NotEmpty()
               .WithMessage("Numbers of Count/s is required");
        }
    }
}
using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class ConcreteColumnInputValidator : AbstractValidator<ConcreteColumnInputModel>
    {
        public ConcreteColumnInputValidator()
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

            RuleFor(input => input.NumbersOfCount)
               .NotEmpty()
               .WithMessage("Numbers of Count/s is required");

            RuleFor(input => input.ClassMixture)
                .NotEmpty()
                .WithMessage("Class Mixture is required");
        }
    }
}
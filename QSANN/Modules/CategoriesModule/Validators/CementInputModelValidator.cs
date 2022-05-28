using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class CementInputModelValidator : AbstractValidator<CementInputModel>
    {
        public CementInputModelValidator()
        {
            RuleFor(input => input.LengthOfColumn)
                .NotEmpty()
                .WithMessage("Length of Column is required");

            RuleFor(input => input.WidthOfColumn)
               .NotEmpty()
               .WithMessage("WidTH of Column is required");

            RuleFor(input => input.HeightOfColumn)
               .NotEmpty()
               .WithMessage("Height of Column is required");

            RuleFor(input => input.NumbersOfColumn)
               .NotEmpty()
               .WithMessage("Numbers of Column is required");
        }
    }
}

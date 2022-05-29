using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class ConcreteOtherInputValidator : AbstractValidator<ConcreteOtherInputModel>
    {
        public ConcreteOtherInputValidator()
        {
            RuleFor(input => input.TotalVolume)
                .NotEmpty()
                .WithMessage("Total Volume is required");

            RuleFor(input => input.NumbersOfCount)
               .NotEmpty()
               .WithMessage("Numbers of Count/s is required");
        }
    }
}

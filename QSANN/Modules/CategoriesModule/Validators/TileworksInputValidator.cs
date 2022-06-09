using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class TileworksInputValidator : AbstractValidator<TileworksInputModel>
    {
        public TileworksInputValidator()
        {
            RuleFor(input => input.AreaOfWorkDesignation)
                .NotEmpty()
                .WithMessage("Area of work Designation is required.");

            RuleFor(input => input.SelectedMultiplier)
                .NotNull()
                .WithMessage("Please select a multiplier.");
        }
    }
}
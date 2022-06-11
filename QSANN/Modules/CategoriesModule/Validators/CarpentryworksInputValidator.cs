using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class CarpentryworksInputValidator : AbstractValidator<CarpentryworksInputModel>
    {
        public CarpentryworksInputValidator()
        {
            RuleFor(input => input.AreaOfDesignation)
                .NotEmpty()
                .WithMessage("Area of work Designation is required.");

            RuleFor(input => input.SizeOfLumber)
                .NotNull()
                .WithMessage("Size of Lumber is required.");
        }
    }
}
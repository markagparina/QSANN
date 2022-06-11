using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class PaintworksInputValidator : AbstractValidator<PaintworksInputModel>
    {
        public PaintworksInputValidator()
        {
            RuleFor(input => input.AreaOfApplication)
                .NotEmpty()
                .WithMessage("Area of Application is required.");

            RuleFor(input => input.Finish)
                .NotNull()
                .WithMessage("Finish is required.");
        }
    }
}

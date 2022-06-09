using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class MasonryInputModelValidator : AbstractValidator<MasonryInputModel>
    {
        public MasonryInputModelValidator()
        {
            RuleFor(input => input.HeightOfWall)
                .NotEmpty()
                .WithMessage("Height of Wall is required");

            RuleFor(input => input.LengthOfWall)
               .NotEmpty()
               .WithMessage("Length of Wall is required");

            RuleFor(input => input.VerticalBarSpacing)
               .NotEmpty()
               .WithMessage("Vertical Bar Spacing is required");

            RuleFor(input => input.HorizontalBarSpacing)
               .NotEmpty()
               .WithMessage("Horizontal Bar Spacing is required");
        }
    }
}
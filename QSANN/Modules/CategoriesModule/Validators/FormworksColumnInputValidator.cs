using CategoriesModule.Models;
using FluentValidation;

namespace CategoriesModule.Validators
{
    public class FormworksColumnInputValidator : AbstractValidator<FormworksColumnInputModel>
    {
        public FormworksColumnInputValidator()
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

            RuleFor(input => input.NumberOfCounts)
               .NotEmpty()
               .WithMessage("Numbers of Count/s is required");
        }
    }
}

using CategoriesModule.Models;
using FluentValidation;
using QSANN.Core.Enums;
using QSANN.Services.Interfaces.Models;
using System.Collections.ObjectModel;

namespace CategoriesModule.Validators
{
    public class RebarworksSlabInputValidator : AbstractValidator<RebarworksSlabInputModel>
    {
        private ObservableCollection<RebarworksSlabTypeMultiplier> _multipliers;

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
               .WithMessage("Size of Steel Bar is required")
               .NotNull()
               .WithMessage("Size of Steel Bar is required");

            RuleFor(input => input.OneWayOrTwoWay)
                .IsInEnum()
                .WithMessage("Slab Type is required");

        }

        public RebarworksSlabInputValidator(ObservableCollection<RebarworksSlabTypeMultiplier> multipliers) : this()
        {
            _multipliers = multipliers;            
            
        }
    }
}
using BookRate.DAL.DTO.Serie;
using BookRate.DAL.DTO.Shelf;
using BookRate.Validation.Extentions;
using FluentValidation;

namespace BookRate.Validation
{
    public class ShelfValidator : AbstractValidator<ShelfDto>
    {
        public ShelfValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
               .Must(name => !ValidationHelper.HasLeadingOrTrailingSpaces(name))
               .WithMessage("Name must not contain leading or trailing spaces.")
               .Must(name => !ValidationHelper.HasMultipleSpaces(name))
               .WithMessage("Name must not contain multiple consecutive spaces.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must be less than 500 characters long.")
                .When(x => !string.IsNullOrEmpty(x.Description))
                .Must(name => !ValidationHelper.HasMultipleSpaces(name))
                .WithMessage("Name must not contain multiple consecutive spaces.");
        }
    }
}

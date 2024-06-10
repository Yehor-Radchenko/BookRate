using BookRate.DAL.DTO.Genre;
using FluentValidation;
using BookRate.Validation.Extentions;

namespace BookRate.Validation
{
    public class GenreValidator : AbstractValidator<GenreDto>
    {
        public GenreValidator()
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

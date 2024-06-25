using BookRate.DAL.DTO.Review;
using BookRate.Validation.Extentions;
using FluentValidation;

namespace BookRate.Validation
{

    public class ReviewValidator : AbstractValidator<ReviewDto>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Text must be at most 100 characters long.")
                .Must(title => !ValidationHelper.HasLeadingOrTrailingSpaces(title))
                .WithMessage("Title must not contain leading or trailing spaces.")
                .Must(title => !ValidationHelper.HasMultipleSpaces(title))
                .WithMessage("Title must not contain multiple consecutive spaces.");

            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Text is required.")
                .MaximumLength(500).WithMessage("Text must be at most 500 characters long.");

            RuleFor(x => x.DatePosted)
                .NotEmpty().WithMessage("DatePosted is required.")
                .LessThan(DateTime.Now).WithMessage("DatePosted cannot be in the future.");

            RuleFor(x => x.StartReadDate)
                .LessThanOrEqualTo(x => x.EndReadDate).WithMessage("StartReadDate must be before EndReadDate.")
                .When(x => x.StartReadDate.HasValue && x.EndReadDate.HasValue);

            RuleFor(x => x.EndReadDate)
                .GreaterThanOrEqualTo(x => x.StartReadDate).WithMessage("EndReadDate must be after StartReadDate.")
                .When(x => x.StartReadDate.HasValue && x.EndReadDate.HasValue);

            RuleFor(x => x.RateId)
                .NotEmpty().WithMessage("Rate is required.");
        }
    }

}

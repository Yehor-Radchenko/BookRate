using BookRate.DAL.DTO.Book;
using BookRate.Validation.Extentions;
using FluentValidation;

namespace BookRate.Validation
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.SerieId)
               .Must(serieId => !serieId.HasValue || serieId.Value > 0)
               .WithMessage("SerieId must be a positive integer if provided.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Title must be at least 2 characters long.")
                .Must(title => !ValidationHelper.HasLeadingOrTrailingSpaces(title))
                .WithMessage("Title must not contain leading or trailing spaces.")
                .Must(title => !ValidationHelper.HasMultipleSpaces(title))
                .WithMessage("Title must not contain multiple consecutive spaces.");


            RuleFor(x => x.FirstPublished)
                .NotEmpty().WithMessage("FirstPublished date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("FirstPublished date must be in the past or today.");


            RuleFor(x => x.BookEditionDTO)
                .NotNull().WithMessage("BookEditionDTO is required.")
                .SetValidator(new BookEditionValidator());
        }
    }
}

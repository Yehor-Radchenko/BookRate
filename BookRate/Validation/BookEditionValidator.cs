using BookRate.DAL.DTO.BookEdition;
using FluentValidation;

namespace BookRate.Validation
{
    public class BookEditionValidator : AbstractValidator<BaseBookEditionDTO>
    {
        public BookEditionValidator()
        {
            RuleFor(x => x.CoverType)
                .IsInEnum().WithMessage("Invalid CoverType.");

            RuleFor(x => x.PagesCount)
                .GreaterThan(0).WithMessage("PagesCount must be a positive integer.");

            RuleFor(x => x.EditionDate)
                .NotEmpty().WithMessage("EditionDate is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("EditionDate must be in the past or today.");

            RuleFor(x => x.Ibsn)
                .NotEmpty().WithMessage("Ibsn is required.")
                .Length(10, 13).WithMessage("Ibsn must be between 10 and 13 characters long.")
                .Matches(@"^[0-9\-]+$").WithMessage("Ibsn must contain only digits.");

            RuleFor(x => x.Photo)
                .NotNull().WithMessage("Photo is required.");
        }
    }
}

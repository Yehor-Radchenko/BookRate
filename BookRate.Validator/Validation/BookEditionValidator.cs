﻿using BookRate.DAL.DTO.BookEdition;
using BookRate.Validation.Extentions;
using FluentValidation;

namespace BookRate.Validation
{
    public class BookEditionValidator : AbstractValidator<BookEditionDto>
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

            RuleFor(x => x.Isbn)
                .NotEmpty().WithMessage("Ibsn is required.")
                .Length(10, 13).WithMessage("Ibsn must be between 10 and 13 characters long.")
                .Matches(@"^[0-9\-]+$").WithMessage("Ibsn must contain only digits.");

            RuleFor(x => x.PhotoUrl)
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                .When(x => !string.IsNullOrEmpty(x.PhotoUrl)).WithMessage("Invalid URL format.");
        }
    }
}

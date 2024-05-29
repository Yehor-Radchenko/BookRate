using System;
using System.Collections.Generic;
using FluentValidation;
using System.Linq;
using BookRate.DAL.DTO.Narrative;
using BookRate.Validation.Extentions;

namespace BookRate.Validation
{
    public class NarrativeValidator : AbstractValidator<BaseNarrativeDTO>
    {
        public NarrativeValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Title must be at least 2 characters long.")
                .Must(title => !ValidationHelper.HasLeadingOrTrailingSpaces(title))
                .WithMessage("Title must not contain leading or trailing spaces.")
                .Must(title => !ValidationHelper.HasMultipleSpaces(title))
                .WithMessage("Title must not contain multiple consecutive spaces.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.OriginalTitle)
                .Must(title => title == null || !ValidationHelper.HasLeadingOrTrailingSpaces(title))
                .WithMessage("Original title must not contain leading or trailing spaces.")
                .Must(title => title == null || !ValidationHelper.HasMultipleSpaces(title))
                .WithMessage("Original title must not contain multiple consecutive spaces.");

            RuleFor(x => x.ThreeLetterIsolanguageName)
                .NotEmpty().WithMessage("Three-letter ISO language name is required.")
                .Length(3).WithMessage("Three-letter ISO language name must be exactly 3 characters long.")
                .Matches(@"^[A-Za-z]{3}$")
                .WithMessage("Three-letter ISO language name must contain only Latin letters.");

            RuleFor(x => x.ContributorRoleIds)
                .NotEmpty().WithMessage("At least one contributor role ID is required.");

            RuleFor(x => x.GenresId)
                .NotEmpty().WithMessage("At least one genre ID is required.");
        }
    }
}

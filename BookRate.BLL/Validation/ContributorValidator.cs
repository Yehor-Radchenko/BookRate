using System;
using System.Collections.Generic;
using FluentValidation;
using BookRate.DAL.DTO.Contributor;
using static BookRate.Validation.Extentions.ValidationHelper;
using BookRate.Validation.Extentions;
using BookRate.DAL.Models;

namespace BookRate.Validation
{
    public class ContributorValidator : AbstractValidator<ContributorDto>
    {
        public ContributorValidator()
        {
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.")
                .Matches(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ\s]+$")
                .WithMessage("Last name must contain only letters (Latin or Cyrillic) and spaces.")
                .Must(name => !ValidationHelper.HasLeadingOrTrailingSpaces(name))
                .WithMessage("Last name must not contain leading or trailing spaces.")
                .Must(name => !ValidationHelper.HasMultipleSpaces(name))
                .WithMessage("Last name must not contain multiple consecutive spaces.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MinimumLength(2).WithMessage("First name must be at least 2 characters long.")
                .Matches(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ\s]+$")
                .WithMessage("First name must contain only letters (Latin or Cyrillic) and spaces.")
                .Must(name => !ValidationHelper.HasLeadingOrTrailingSpaces(name))
                .WithMessage("First name must not contain leading or trailing spaces.")
                .Must(name => !ValidationHelper.HasMultipleSpaces(name))
                .WithMessage("First name must not contain multiple consecutive spaces.");

            RuleFor(x => x.Patronymic)
                .Matches(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ\s]*$")
                .WithMessage("Patronymic must contain only letters (Latin or Cyrillic) and spaces if provided.")
                .Must(name => name == null || !ValidationHelper.HasLeadingOrTrailingSpaces(name))
                .WithMessage("Patronymic must not contain leading or trailing spaces.")
                .Must(name => name == null || !ValidationHelper.HasMultipleSpaces(name))
                .WithMessage("Patronymic must not contain multiple consecutive spaces.");

            RuleFor(x => x.BirthDate)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Birth date must be today or earlier.");

            RuleFor(x => x.DeathDate)
                .GreaterThan(x => x.BirthDate).WithMessage("Death date must be later than birth date.")
                .When(x => x.DeathDate.HasValue && x.BirthDate.HasValue)
                .LessThan(DateTime.Today).WithMessage("Death date must be earlier then today.");

            RuleFor(x => x.Biography)
                .NotEmpty().WithMessage("Biography is required.")
                .MaximumLength(2000).WithMessage("Biography must be less than 2000 characters long.")
                .When(x => !string.IsNullOrEmpty(x.Biography));

            RuleFor(x => x.BirthPlace)
                .MaximumLength(100).WithMessage("Birth place must be less than 100 characters long.")
                .Matches(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ\s\-,.\p{P}]*$")
                .WithMessage("Birth place must contain only letters (Latin or Cyrillic), spaces, hyphens, commas, periods, and other punctuation marks if provided.")
                .Must(place => place == null || !ValidationHelper.HasLeadingOrTrailingSpaces(place))
                .WithMessage("Birth place must not contain leading or trailing spaces.")
                .Must(place => place == null || !ValidationHelper.HasMultipleSpaces(place))
                .WithMessage("Birth place must not contain multiple consecutive spaces.");


            RuleFor(x => x.RolesId)
                .NotEmpty().WithMessage("At least one role ID is required.");

            RuleFor(x => x.Photo)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(photo => photo == null || photo.Length > 0)
                .WithMessage("Photo must not be empty.")
                .SetValidator(new PhotoValidator());
        }
    }
}

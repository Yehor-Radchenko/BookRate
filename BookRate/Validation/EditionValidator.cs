using BookRate.DAL.DTO.Edition;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookRate.Validation
{
    public class EditionValidator : AbstractValidator<BaseEditionDTO>
    {
        public EditionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("Invalid email format.");

            RuleFor(x => x.Phone)
                .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$")
                .When(x => !string.IsNullOrEmpty(x.Phone)).WithMessage("Invalid phone number format.");

            RuleFor(x => x.Website)
                .Matches(@"^(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?$")
                .When(x => !string.IsNullOrEmpty(x.Website)).WithMessage("Invalid website format.");
        }
    }
}

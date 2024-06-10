using BookRate.DAL.DTO.User;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace BookRate.Validation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(user => user.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required.")
                .Equal(user => user.Password).WithMessage("Passwords do not match.");

            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters long.")
                .Matches(@"^[a-zA-Z0-9_.-]+$").WithMessage("Username can only contain latin letters, digits, underscores, dots, and hyphens.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name must be less than 100 characters long.");

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name must be less than 100 characters long.");

            RuleFor(user => user.Patronymic)
                .MaximumLength(100).WithMessage("Patronymic must be less than 100 characters long.");

            RuleFor(user => user.Interests)
                .MaximumLength(500).WithMessage("Interests must be less than 500 characters long.");

            RuleFor(user => user.RolesId)
                .NotEmpty().WithMessage("At least one role is required.");

      
        }
    }
}

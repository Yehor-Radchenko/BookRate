using BookRate.DAL.Context;
using BookRate.DAL.DTO.User;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BookRate.Validation
{
    public class UserValidator : AbstractValidator<UserDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(async (email, token) => !await ExisitsAsync(email)).WithMessage("User with this email exist");

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


        private async Task<bool> ExisitsAsync(string email)
        {
            var userRepo = _unitOfWork.GetRepository<User>();

            return await userRepo.ExistsAsync(e => e.Email.ToLower() == email.ToLower());

        }


    }
}

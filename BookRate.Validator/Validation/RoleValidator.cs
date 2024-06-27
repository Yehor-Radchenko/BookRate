using BookRate.DAL.DTO.Role;
using FluentValidation;

namespace BookRate.Validation
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        public RoleValidator() 
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Role name can't be empty.");
        }
    }
}

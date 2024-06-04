using BookRate.DAL.DTO.Role;
using FluentValidation;

namespace BookRate.Validation
{
    public class RoleValidator : AbstractValidator<BaseRoleDTO>
    {
        public RoleValidator() 
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Role name can't be empty.");
        }
    }
}

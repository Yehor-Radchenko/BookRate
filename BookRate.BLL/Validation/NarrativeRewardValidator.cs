using BookRate.DAL.DTO.NarrativeRevard;
using FluentValidation;

namespace BookRate.Validation
{
    public class NarrativeRewardValidator : AbstractValidator<NarrativeRewardDto>
    {
        public NarrativeRewardValidator() 
        {
            RuleFor(x => x.DateRewarded)
                .NotEmpty().WithMessage("Date of receiving the reward must be specified.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Date of receiving the reward must be today or earlier.");
        }
    }
}

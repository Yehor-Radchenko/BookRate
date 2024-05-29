using FluentValidation;
using BookRate.DAL.DTO.Reward;
using BookRate.Validation.Extentions;

namespace BookRate.Validation
{
    public class RewardValidator : AbstractValidator<BaseRewardDTO>
    {
        public RewardValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
                .Must(name => !ValidationHelper.HasLeadingOrTrailingSpaces(name))
                .WithMessage("Name must not contain leading or trailing spaces.")
                .Must(name => !ValidationHelper.HasMultipleSpaces(name))
                .WithMessage("Name must not contain multiple consecutive spaces.");

            RuleFor(x => x.Description)
                .MinimumLength(2).WithMessage("Description must be at least 2 characters long.")
                .MaximumLength(500).WithMessage("Description must exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.Website)
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                .WithMessage("Website must be a valid URL.")
                .When(x => !string.IsNullOrEmpty(x.Website));
        }
    }
}

using BookRate.DAL.DTO.Setting;
using BookRate.Validation.Extentions;
using FluentValidation;

namespace BookRate.Validation
{
    public class SettingValidator : AbstractValidator<BaseSettingDTO>
    {
        public SettingValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Setting name is required.")
                .MinimumLength(2).WithMessage("Setting name must be at least 2 characters long.")
                .Must(name => !ValidationHelper.HasLeadingOrTrailingSpaces(name))
                .WithMessage("Setting name must not contain leading or trailing spaces.")
                .Must(name => !ValidationHelper.HasMultipleSpaces(name))
                .WithMessage("Setting name must not contain multiple consecutive spaces.");
        }
    }
}

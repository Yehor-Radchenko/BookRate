using FluentValidation;

namespace BookRate.Validation
{
    public class PhotoValidator : AbstractValidator<byte[]>   
    {
        public PhotoValidator() 
        {
            RuleFor(photo => photo)
                .NotEmpty().WithMessage("PhotoData missing.");

            RuleFor(photo => photo.Length)
                .LessThanOrEqualTo(5 * 1024 * 1024) 
                .WithMessage("Photo size should not exceed 5 MB.");
        }
    }
}

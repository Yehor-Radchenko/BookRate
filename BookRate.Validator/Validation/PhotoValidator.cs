using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BookRate.Validation
{
    public class PhotoValidator : AbstractValidator<IFormFile>   
    {
        public PhotoValidator() 
        {
            RuleFor(photo => photo)
                .Must(photo => photo.Length > 0)
                .WithMessage("Photo must not be empty.")
                .Must(photo => photo.ContentType.StartsWith("image/"))
                .WithMessage("Photo must be an image.");

            RuleFor(photo => photo.Length)
                .LessThanOrEqualTo(5 * 1024 * 1024) 
                .WithMessage("Photo size should not exceed 5 MB.");
        }
    }
}

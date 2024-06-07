using BookRate.DAL.DTO.Commentary;
using BookRate.Validation.Extentions;
using FluentValidation;

namespace BookRate.Validation
{
    public class CommentaryValidator : AbstractValidator<CommentaryDto>
    {
        public CommentaryValidator() 
        {
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Text is required.")
                .MaximumLength(200).WithMessage("Text must be at most 200 characters long.");

            RuleFor(x => x.DateCommented)
                .NotEmpty().WithMessage("DatePosted is required.")
                .LessThan(DateTime.Now).WithMessage("DatePosted cannot be in the future.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Log in to post a comment.");
        }
    }
}
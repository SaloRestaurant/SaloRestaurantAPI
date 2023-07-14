using FluentValidation;

namespace SaloAPI.Domain.Entities;

public class ImageEntityValidator : AbstractValidator<ImageEntity>
{
    public ImageEntityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.FileName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
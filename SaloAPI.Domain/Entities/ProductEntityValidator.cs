using FluentValidation;

namespace SaloAPI.Domain.Entities;

public class ProductEntityValidator : AbstractValidator<ProductEntity>
{
    public ProductEntityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().Length(2, 50);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Price).NotEmpty().LessThanOrEqualTo(9999);
        RuleFor(x => x.Quantity).NotEmpty();
        RuleFor(x => x.CategoryId).NotEmpty();
    }
}
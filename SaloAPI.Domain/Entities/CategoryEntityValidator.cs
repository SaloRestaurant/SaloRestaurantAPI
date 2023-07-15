using FluentValidation;

namespace SaloAPI.Domain.Entities;

public class CategoryEntityValidator : AbstractValidator<CategoryEntity>
{
    public CategoryEntityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}
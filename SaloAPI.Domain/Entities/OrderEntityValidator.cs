using FluentValidation;
using SaloAPI.Domain.Enums;

namespace SaloAPI.Domain.Entities;

public class OrderEntityValidator : AbstractValidator<OrderEntity>
{
    public OrderEntityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Status).NotEmpty().IsInEnum();
        RuleFor(x => x.Total).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}
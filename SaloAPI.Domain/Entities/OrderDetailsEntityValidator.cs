using FluentValidation;
using System.Xml.Xsl;

namespace SaloAPI.Domain.Entities;

public class OrderDetailsEntityValidator : AbstractValidator<OrderDetailsEntity>
{
    public OrderDetailsEntityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Quantity).NotEmpty().LessThanOrEqualTo(999);
        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
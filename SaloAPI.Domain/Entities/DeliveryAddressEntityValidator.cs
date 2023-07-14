using FluentValidation;

namespace SaloAPI.Domain.Entities;

public class DeliveryAddressEntityValidator : AbstractValidator<DeliveryEntityAddress>
{
    public DeliveryAddressEntityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Address).NotEmpty().MaximumLength(50);
        RuleFor(x => x.District).NotEmpty().MaximumLength(30);
        RuleFor(x => x.City).NotEmpty().MaximumLength(30);
        RuleFor(x => x.ZipCode).NotEmpty().Length(5);
        RuleFor(x => x.AdditionalInfo).NotEmpty().MaximumLength(100);
    }
}
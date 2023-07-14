using FluentValidation;

namespace SaloAPI.Domain.Entities;

public class AdministratorEntityValidator : AbstractValidator<AdministratorEntity>
{
    public AdministratorEntityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty().Length(2, 50);
        RuleFor(x => x.LastName).NotEmpty().Length(2, 50);
        RuleFor(x => x.PasswordHash).NotEmpty();
        RuleFor(x => x.PasswordSalt).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().Length(5, 50)
            .Must(email => email.Contains('@'));
    }
}
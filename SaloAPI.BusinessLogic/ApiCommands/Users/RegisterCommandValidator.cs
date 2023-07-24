using FluentValidation;

namespace SaloAPI.BusinessLogic.ApiCommands.Users;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(firstName => firstName.All(char.IsLetter))
            .WithMessage("FirstName must only contain letters.")
            .Length(2, 50)
            .WithMessage("FirstName must be between 2 and 50 characters.");
        
        RuleFor(x => x.LastName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(lastName => lastName.All(char.IsLetter))
            .WithMessage("LastName must only contain letters.")
            .Length(2, 50)
            .WithMessage("LastName must be between 2 and 50 characters.");
        
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(email => email.Contains('@'))
            .WithMessage("Email must contain @.")
            .Length(5, 50)
            .WithMessage("Email must be between 5 and 50 characters.");
        
        RuleFor(x => x.PhoneNumber)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(phone => phone.Contains("+380"))
            .WithMessage("PhoneNumber must contain +380.")
            .Length(13)
            .WithMessage("PhoneNumber must be 13 characters.");

        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Length(5, 50)
            .WithMessage("Password must be at least 5 characters.");
    }
}
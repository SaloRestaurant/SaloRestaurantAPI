using FluentValidation;

namespace SaloAPI.BusinessLogic.ApiCommands.Sessions;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(email => email.Contains('@'))
            .WithMessage("Email must contain @.")
            .Length(5, 50)
            .WithMessage("Email must be between 5 and 50 characters.");

        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Length(5, 50)
            .WithMessage("Password must be at least 5 characters.");
    }
}
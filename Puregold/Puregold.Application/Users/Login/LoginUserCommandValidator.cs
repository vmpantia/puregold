using FluentValidation;

namespace Puregold.Application.Users.Login;

public sealed class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(luc => luc.Login.UsernameOrEmail).NotEmpty().WithMessage("Invalid username or email.");
        RuleFor(luc => luc.Login.Password).NotEmpty().WithMessage("Invalid password.");
    }
}
using FluentValidation;

namespace Puregold.Application.Users.Login;

public sealed class LoginUserCommandValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserCommandValidator()
    {
        RuleFor(lud => lud.UsernameOrEmail).NotEmpty().WithMessage("Invalid username or email.");
        RuleFor(lud => lud.Password).NotEmpty().WithMessage("Invalid password.");
    }
}
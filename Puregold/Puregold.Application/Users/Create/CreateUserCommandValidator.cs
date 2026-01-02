using FluentValidation;

namespace Puregold.Application.Users.Create;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(cuc => cuc.User.Username).NotEmpty();
        RuleFor(cuc => cuc.User.Email).NotEmpty();
        RuleFor(cuc => cuc.User.Password).NotEmpty();
        RuleFor(cuc => cuc.User.FirstName).NotEmpty();
        RuleFor(cuc => cuc.User.LastName).NotEmpty();
        RuleFor(cuc => cuc.User.Gender)
            .IsInEnum()            
            .WithMessage("Gender must be a valid gender value.");
    }
}
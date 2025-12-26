using MediatR;
using Puregold.Application.Abstractions.Authentication;
using Puregold.Application.Abstractions.Repositories;
using Puregold.Domain.Common.Responses;
using Puregold.Domain.Users;

namespace Puregold.Application.Users.Login;

public sealed class LoginUserCommandHandler(IUserRepository userRepository, 
    IPasswordHasher passwordHasher, ITokenProvider tokenProvider) : IRequestHandler<LoginUserCommand, Result<UserTokenDto>>
{
    public async Task<Result<UserTokenDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameOrEmailAsync(request.Login.UsernameOrEmail, cancellationToken);
        
        // Check if user NULL or not exist
        if (user is null) return UserErrors.UsernameOrEmailAddressNotFound();
        
        // Check if user password matches on the given password using password hasher
        if (!passwordHasher.Verify(request.Login.Password, user.Password)) 
            return UserErrors.PasswordIncorrect();

        // Generate authentication token for user
        return tokenProvider.Create(user);
    }
}
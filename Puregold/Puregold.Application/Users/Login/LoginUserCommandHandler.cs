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
        // Get user stored on the database using a username or email address
        var user = await userRepository.GetOneAsync(expression: u =>
                u.Username == request.Login.UsernameOrEmail || u.Email == request.Login.UsernameOrEmail,
            cancellationToken);

        // Check if user NULL or not exist
        if (user == null) return UserErrors.UsernameOrEmailAddressNotFound();
        
        // Check if user password matches on the given password using password hasher
        if (!passwordHasher.Verify(request.Login.Password, user.Password)) 
            return UserErrors.PasswordIncorrect();

        // Generate authentication token for user
        return tokenProvider.Create(user);
    }
}
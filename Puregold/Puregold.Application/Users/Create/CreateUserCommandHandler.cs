using AutoMapper;
using MediatR;
using Puregold.Application.Abstractions.Authentication;
using Puregold.Application.Abstractions.Repositories;
using Puregold.Domain.Common.Responses;
using Puregold.Domain.Users;

namespace Puregold.Application.Users.Create;

public sealed class CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper) : IRequestHandler<CreateUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Check if username is already used
        if (await userRepository.IsExistAsync(u => u.Username == request.User.Username, cancellationToken))
            return UserErrors.UsernameIsAlreadyUsed();

        // Check if email is already used
        if (await userRepository.IsExistAsync(u => u.Email == request.User.Email, cancellationToken))
            return UserErrors.EmailIsAlreadyUsed();

        var user = mapper.Map<User>(request.User);
        user.Password = passwordHasher.Hash(request.User.Password);
        user.Role = request.Role;
        
        var result = await userRepository.CreateAsync(user, cancellationToken);
        return result.Id;
    }
}
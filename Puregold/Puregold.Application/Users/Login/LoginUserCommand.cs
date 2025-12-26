using MediatR;
using Puregold.Domain.Common.Responses;

namespace Puregold.Application.Users.Login;

public sealed record LoginUserCommand(LoginUserDto Login) : IRequest<Result<UserTokenDto>>;
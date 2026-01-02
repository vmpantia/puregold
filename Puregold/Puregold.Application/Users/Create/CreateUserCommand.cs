using MediatR;
using Puregold.Domain.Common.Responses;
using Puregold.Domain.Enums;

namespace Puregold.Application.Users.Create;

public sealed record CreateUserCommand(CreateUserDto User, UserRole Role) : IRequest<Result<Guid>>;

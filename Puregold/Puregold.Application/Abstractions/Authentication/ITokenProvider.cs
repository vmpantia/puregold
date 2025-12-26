using Puregold.Application.Users;
using Puregold.Application.Users.Login;
using Puregold.Domain.Users;

namespace Puregold.Application.Abstractions.Authentication;

public interface ITokenProvider
{
    UserTokenDto Create(User user);
}
using Puregold.Application.Users;

namespace Puregold.Application.Abstractions.Authentication;

public interface ITokenProvider
{
    UserTokenDto Create(User user);
}
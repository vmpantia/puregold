using Puregold.Domain.Common.Responses;
using Puregold.Domain.Enums;

namespace Puregold.Domain.Users;

public abstract class UserErrors
{
    public static Error UsernameOrEmailAddressNotFound() => new(ErrorType.NotFound, "Username or email address is not found in the database.");
    public static Error PasswordIncorrect() => new(ErrorType.Invalid, "User password is incorrect.");
}
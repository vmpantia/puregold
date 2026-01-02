using Puregold.Domain.Enums;

namespace Puregold.Application.Users.Create;

public sealed class CreateUserDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;
using Puregold.Domain.Common;
using Puregold.Domain.Enums;

namespace Puregold.Domain.Users;

public sealed class User : IEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }  
    public DateTime? CreatedAtUtc { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public string UpdatedBy { get; set; }
    
    [NotMapped]
    public string Name
    {
        get
        {
            var middleInitial = string.IsNullOrWhiteSpace(MiddleName)
                ? string.Empty : $" {MiddleName.Trim()[0].ToString().ToUpper()}.";

            return $"{LastName}, {FirstName}{middleInitial}";
        }
    }

    [NotMapped]
    public string Initials
    {
        get
        {
            var firstInitial = string.IsNullOrWhiteSpace(FirstName) ? string.Empty : FirstName.Trim()[0].ToString().ToUpper();
            var lastInitial = string.IsNullOrWhiteSpace(LastName) ? string.Empty : LastName.Trim()[0].ToString().ToUpper();

            return $"{firstInitial}{lastInitial}";
        }
    }
}
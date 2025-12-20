using Puregold.Domain.Common;

namespace Puregold.Application.Users;

public sealed class User : IEntity
{
    public Guid Id { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public string UpdatedBy { get; set; }
}
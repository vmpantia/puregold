using Puregold.Domain.Common;

namespace Puregold.Domain.Items;

public abstract class ItemCategory : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public string UpdatedBy { get; set; }
    
    public virtual ICollection<Item> Items { get; set; }
}
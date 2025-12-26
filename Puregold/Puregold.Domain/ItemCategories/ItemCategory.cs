using Puregold.Domain.Common.Interfaces;
using Puregold.Domain.Enums;
using Puregold.Domain.Items;

namespace Puregold.Domain.ItemCategories;

public class ItemCategory : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CommonStatus Status { get; set; }  
    public DateTime CreatedAtUtc { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public string? UpdatedBy { get; set; }
    
    public virtual ICollection<Item> Items { get; set; }
}
using Puregold.Domain.Common;
using Puregold.Domain.ItemCategories;

namespace Puregold.Domain.Items;

public class Item : IEntity
{
    public Guid Id { get; set; }
    public Guid ItemCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public string UpdatedBy { get; set; }
    
    public virtual ItemCategory Category { get; set; }
}
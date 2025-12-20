namespace Puregold.Application.Items.Create;

public sealed class CreateItemDto
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
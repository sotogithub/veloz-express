using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class ItemDetail : BaseEntity
{
    public int ItemId { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }

    public Item Item { get; set; }
}

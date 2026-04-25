using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Item : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public ICollection<ItemDetail> ItemDetails { get; set; }
}

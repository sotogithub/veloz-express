using System;
using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Role : BaseEntity
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public ICollection<User> Users { get; set; }
}

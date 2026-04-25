using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class PackageCategory : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? IconUrl { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation
    public ICollection<Rate> Rates { get; set; } = new List<Rate>();
    public ICollection<Package> Packages { get; set; } = new List<Package>();
}

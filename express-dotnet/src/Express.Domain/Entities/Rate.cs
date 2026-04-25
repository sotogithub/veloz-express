using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Rate : BaseEntity
{
    public int PackageCategoryId { get; set; }
    public decimal BasePrice { get; set; }
    public decimal PricePerKm { get; set; } = 0;
    public decimal PricePerKg { get; set; } = 0;
    public decimal? MaxWeightKg { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation
    public PackageCategory Category { get; set; } = default!;
    public ICollection<Package> Packages { get; set; } = [];
}

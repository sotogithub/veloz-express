using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class PackageTracking : BaseEntity
{
    public int PackageId { get; set; }
    public int? UserId { get; set; }
    public string Status { get; set; } = default!;
    public string? Description { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public string? EvidencePhotoUrl { get; set; }

    // Navigation
    public Package Package { get; set; } = default!;
    public User? User { get; set; }
}

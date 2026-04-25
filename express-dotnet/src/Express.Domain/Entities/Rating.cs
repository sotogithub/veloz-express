using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Rating : BaseEntity
{
    public int PackageId { get; set; }
    public int RaterId { get; set; }
    public int RatedUserId { get; set; }
    public byte Score { get; set; }
    public string? Comment { get; set; }

    // Navigation
    public Package Package { get; set; } = default!;
    public User Rater { get; set; } = default!;
    public User RatedUser { get; set; } = default!;
}

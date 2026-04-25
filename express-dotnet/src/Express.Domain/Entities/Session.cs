using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Session : BaseEntity
{
    public int UserId { get; set; }
    public string Token { get; set; } = default!;
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public DateTime ExpiresAt { get; set; }

    // Navigation
    public User User { get; set; } = default!;
}

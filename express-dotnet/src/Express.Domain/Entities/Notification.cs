using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Notification : BaseEntity
{
    public int UserId { get; set; }
    public int? PackageId { get; set; }
    public string Type { get; set; } = "interna";
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public bool IsRead { get; set; } = false;

    // Navigation
    public User User { get; set; } = default!;
    public Package? Package { get; set; }
}

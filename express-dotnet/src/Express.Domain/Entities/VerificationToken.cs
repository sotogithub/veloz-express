using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class VerificationToken : BaseEntity
{
    public int UserId { get; set; }
    public int TokenTypeId { get; set; }
    public string Token { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public bool IsUsed { get; set; } = false;

    // Navigation
    public User User { get; set; } = default!;
    public ItemDetail TokenType { get; set; } = default!;

}

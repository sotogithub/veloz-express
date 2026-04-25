using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Payment : BaseEntity
{
    public int PackageId { get; set; }
    public int CustomerId { get; set; }
    public int PaymentMethodId { get; set; }
    public int PaymentStatusId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "PEN";
    public string? ExternalReference { get; set; }
    public string? ReceiptUrl { get; set; }
    public DateTime? PaidAt { get; set; }

    // Navigation
    public Package Package { get; set; } = default!;
    public User Customer { get; set; } = default!;
    public ItemDetail PaymentMethod { get; set; } = default!;
    public ItemDetail PaymentStatus { get; set; } = default!;
}

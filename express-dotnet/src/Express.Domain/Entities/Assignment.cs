using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Assignment : BaseEntity
{
    public int PackageId { get; set; }
    public int CourierId { get; set; }
    public int AssignedByUserId { get; set; }
    public int AssignmentStatusId { get; set; }
    public string? Notes { get; set; }

    // Navigation
    public Package Package { get; set; } = default!;
    public User Courier { get; set; } = default!;
    public User AssignedByUser { get; set; } = default!;
    public ItemDetail AssignmentStatus { get; set; } = default!;

}

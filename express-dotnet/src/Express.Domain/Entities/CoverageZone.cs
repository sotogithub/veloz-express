using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class CoverageZone : BaseEntity
{
    public int UbigeoId { get; set; }
    public bool IsActive { get; set; } = true;
    public byte? EstimatedTimeHours { get; set; }

    // Navigation
    public Ubigeo Ubigeo { get; set; } = default!;
}

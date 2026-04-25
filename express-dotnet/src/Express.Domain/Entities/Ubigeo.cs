using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Ubigeo : BaseEntity
{
    public string Code { get; set; } = default!;
    public string Department { get; set; } = default!;
    public string Province { get; set; } = default!;
    public string District { get; set; } = default!;

    // Navigation
    public ICollection<Address> Addresses { get; set; } = [];
    public CoverageZone? CoverageZone { get; set; }
}

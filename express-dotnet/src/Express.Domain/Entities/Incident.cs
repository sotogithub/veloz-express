using System;
using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Incident : BaseEntity
{
    public int PackageId { get; set; }
    public int ReportedBy { get; set; }
    public int IncidentTypeId { get; set; }
    public int IncidentStatusId { get; set; }
    public string Description { get; set; } = default!;
    public string? PhotoUrl { get; set; }
    public string? Resolution { get; set; }
    public int ItemDetailId { get; set; }
    public int? ResolvedBy { get; set; }

    // Navigation
    public Package Package { get; set; } = default!;
    public User Reporter { get; set; } = default!;
    public ItemDetail IncidentType { get; set; } = default!;

    public ItemDetail IncidentStatus { get; set; } = default!;
    public User? Resolver { get; set; }
}

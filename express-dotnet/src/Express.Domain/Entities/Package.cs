
using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Package : BaseEntity
{
    public string TrackingCode { get; set; } = default!;
    public int CustomerId { get;set; }
    public int PackageCategoryId { get;set; }
    public int RateId { get;set; }

    // Origin
    public int OriginAddressId { get;set; }
    public string? OriginContactName { get;set; }
    public string? OriginContactPhone { get;set; }

    // Destination
    public int DestinationAddressId { get;set; }
    public string? DestinationContactName { get;set; }
    public string? DestinationContactPhone { get;set; }

    // Details
    public string? Description { get;set; }
    public decimal WeightKg { get;set; } = 0;
    public decimal? HeightCm { get;set; }
    public decimal? WidthCm { get;set; }
    public decimal? LengthCm { get;set; }
    public bool IsFragile { get;set; } = false;
    public decimal? DistanceKm { get;set; }
    public string? Instructions { get;set; }
    public string? PackagePhotoUrl { get;set; }

    // Financial
    public decimal TotalCost { get;set; } = 0;
    public string Currency { get;set; } = "PEN";

    // Status
    public int PackageStatusId { get;set; }
    public DateTime? EstimatedPickupDate { get;set; }
    public DateTime? ActualPickupDate { get;set; }
    public DateTime? EstimatedDeliveryDate { get;set; }
    public DateTime? ActualDeliveryDate { get;set; }

    // Navigation
    public User Customer { get;set; } = default!;
    public PackageCategory PackageCategory { get;set; } = default!;
    public Rate Rate { get;set; } = default!;
    public Address OriginAddress { get;set; } = default!;
    public Address DestinationAddress { get;set; } = default!;
    public ItemDetail PackageStatus { get; set; } = default!;

    public ICollection<PackageTracking> Trackings { get;set; } = new List<PackageTracking>();
    public ICollection<Assignment> Assignments { get;set; } = new List<Assignment>();
    public ICollection<Payment> Payments { get;set; } = new List<Payment>();
    public ICollection<Notification> Notifications { get;set; } = new List<Notification>();
    public Rating? Rating { get;set; }
    public ICollection<Incident> Incidents { get;set; } = new List<Incident>();
}

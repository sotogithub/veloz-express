using System;
using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class DriverProfile : BaseEntity
{
    public int UserId { get; set; }
    public int VehicleTypeId { get; set; }
    public string? LicensePlate { get; set; }
    public string? DriverLicenseNumber { get; set; }
    public bool IsAvailable { get; set; } = true;
    public decimal? CurrentLatitude { get; set; }
    public decimal? CurrentLongitude { get; set; }
    public DateTime? LastLocationUpdate { get; set; }
    public decimal AverageRating { get; set; } = 5.00m;
    public int TotalDeliveries { get; set; } = 0;

    // Navigation
    public User User { get; set; } = default!;
    public ItemDetail VehicleType { get; set; } = default!;

}

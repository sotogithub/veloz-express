using System;
using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class Address : BaseEntity
{
    public int UserId { get; set; }
    public int UbigeoId { get; set; }
    public string? Alias { get; set; }
    public string AddressLine { get; set; } = default!;
    public string? Reference { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public bool IsPrimary { get; set; } = false;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User User { get; set; } = default!;
    public Ubigeo Ubigeo { get; set; } = default!;
}

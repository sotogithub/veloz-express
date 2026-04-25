using Express.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Express.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Address> Addresses { get; }
    DbSet<Assignment> Assignments { get; }
    DbSet<CoverageZone> CoverageZones { get; }
    DbSet<DriverProfile> DriverProfiles { get; }
    DbSet<Incident> Incidents { get; }
    DbSet<Item> Items { get; }
    DbSet<ItemDetail> ItemDetails { get; }
    DbSet<Notification> Notifications { get; }
    DbSet<Package> Packages { get; }
    DbSet<PackageCategory> PackageCategories { get; }

    DbSet<PackageTracking> PackageTrackings { get; }
    DbSet<Payment> Payments { get; }
    DbSet<Rate> Rates { get; }
    DbSet<Rating> Ratings { get; }
    DbSet<Role> Roles { get; }
    DbSet<Session> Sessions { get; }
    DbSet<Ubigeo> Ubigeos { get; }
    DbSet<User> Users { get; }
    DbSet<VerificationToken> VerificationTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
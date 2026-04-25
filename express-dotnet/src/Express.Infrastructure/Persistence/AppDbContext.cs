using Express.Application.Common.Interfaces;
using Express.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Express.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<CoverageZone> CoverageZones => Set<CoverageZone>();
    public DbSet<DriverProfile> DriverProfiles => Set<DriverProfile>();
    public DbSet<Incident> Incidents => Set<Incident>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<ItemDetail> ItemDetails => Set<ItemDetail>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Package> Packages => Set<Package>();
    public DbSet<PackageCategory> PackageCategories => Set<PackageCategory>();
    public DbSet<PackageTracking> PackageTrackings => Set<PackageTracking>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Rate> Rates => Set<Rate>();
    public DbSet<Rating> Ratings => Set<Rating>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Ubigeo> Ubigeos => Set<Ubigeo>();
    public DbSet<User> Users => Set<User>();
    public DbSet<VerificationToken> VerificationTokens => Set<VerificationToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}

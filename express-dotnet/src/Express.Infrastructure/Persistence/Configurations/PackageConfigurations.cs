using Express.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Express.Infrastructure.Persistence.Configurations;

public class AssignmentConfigurations : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("assignments");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("id");
        builder.Property(a => a.PackageId).HasColumnName("package_id");
        builder.Property(a => a.CourierId).HasColumnName("courier_id");
        builder.Property(a => a.AssignedByUserId).HasColumnName("assigned_by");

        builder.Property(a => a.Notes).HasColumnName("notes");
        builder.Property(a => a.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.Property(a => a.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("now()");

        builder.HasOne(a => a.Package).WithMany(p => p.Assignments)
            .HasForeignKey(a => a.PackageId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Courier).WithMany()
            .HasForeignKey(a => a.CourierId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.AssignedByUser).WithMany()
            .HasForeignKey(a => a.AssignedByUserId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.AssignmentStatus).WithMany()
            .HasForeignKey(a => a.AssignmentStatusId).OnDelete(DeleteBehavior.Restrict);
    }
}

public class CoverageZoneConfiguration : IEntityTypeConfiguration<CoverageZone>
{
    public void Configure(EntityTypeBuilder<CoverageZone> builder)
    {
        builder.ToTable("coverage_zones");
        builder.HasKey(z => z.Id);
        builder.Property(z => z.Id).HasColumnName("id");
        builder.Property(z => z.UbigeoId).HasColumnName("ubigeo_id");
        builder.Property(z => z.IsActive).HasColumnName("is_active").HasDefaultValue(true);
        builder.Property(z => z.EstimatedTimeHours).HasColumnName("estimated_time_hours");
        builder.Property(z => z.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");

        builder.HasIndex(z => z.UbigeoId).IsUnique();
        builder.HasOne(z => z.Ubigeo).WithOne(u => u.CoverageZone)
            .HasForeignKey<CoverageZone>(z => z.UbigeoId).OnDelete(DeleteBehavior.Restrict);
    }
}

public class DriverProfileConfiguration : IEntityTypeConfiguration<DriverProfile>
{
    public void Configure(EntityTypeBuilder<DriverProfile> builder)
    {
        builder.ToTable("driver_profiles");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).HasColumnName("id");
        builder.Property(m => m.UserId).HasColumnName("user_id");
        builder.Property(m => m.LicensePlate).HasColumnName("license_plate").HasMaxLength(20);
        builder.Property(m => m.DriverLicenseNumber).HasColumnName("driver_license_number").HasMaxLength(50);
        builder.Property(m => m.IsAvailable).HasColumnName("is_available").HasDefaultValue(true);
        builder.Property(m => m.CurrentLatitude).HasColumnName("current_latitude").HasColumnType("decimal(10,8)");
        builder.Property(m => m.CurrentLongitude).HasColumnName("current_longitude").HasColumnType("decimal(11,8)");
        builder.Property(m => m.LastLocationUpdate).HasColumnName("last_location_update");
        builder.Property(m => m.AverageRating).HasColumnName("average_rating").HasColumnType("decimal(3,2)").HasDefaultValue(5.00m);
        builder.Property(m => m.TotalDeliveries).HasColumnName("total_deliveries").HasDefaultValue(0);
        builder.Property(m => m.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.Property(m => m.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("now()");

        builder.HasOne(m => m.User).WithOne(u => u.DriverProfile)
            .HasForeignKey<DriverProfile>(m => m.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> builder)
    {
        builder.ToTable("incidents");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.PackageId).HasColumnName("package_id");
        builder.Property(i => i.ReportedBy).HasColumnName("reported_by");
        builder.Property(i => i.Description).HasColumnName("description").IsRequired();
        builder.Property(i => i.PhotoUrl).HasColumnName("photo_url").HasMaxLength(500);
        builder.Property(i => i.Resolution).HasColumnName("resolution");
        builder.Property(i => i.ResolvedBy).HasColumnName("resolved_by");
        builder.Property(i => i.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.Property(i => i.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("now()");

        builder.HasOne(i => i.Package).WithMany(p => p.Incidents)
            .HasForeignKey(i => i.PackageId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Reporter).WithMany()
            .HasForeignKey(i => i.ReportedBy).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.IncidentType).WithMany()
            .HasForeignKey(i => i.IncidentTypeId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.IncidentStatus).WithMany()
            .HasForeignKey(i => i.IncidentStatusId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Resolver).WithMany()
            .HasForeignKey(i => i.ResolvedBy).OnDelete(DeleteBehavior.Restrict);
    }
}

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(i => i.Description).HasColumnName("description").HasMaxLength(255).IsRequired();
        
        builder.Property(i => i.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.Property(i => i.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("now()");

    }
}

public class ItemDetailConfiguration : IEntityTypeConfiguration<ItemDetail>
{
    public void Configure(EntityTypeBuilder<ItemDetail> builder)
    {
        builder.ToTable("item_details");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.Name).HasColumnName("name").HasMaxLength(150).IsRequired();
        builder.Property(i => i.Code).HasColumnName("code").HasMaxLength(50);
        builder.Property(i => i.Description).HasColumnName("description").HasMaxLength(500);

        builder.Property(i => i.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.Property(i => i.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("now()");

        builder.HasOne(i => i.Item).WithMany(c => c.ItemDetails)
            .HasForeignKey(i => i.ItemId).OnDelete(DeleteBehavior.Restrict);
    }
}

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("notifications");
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id).HasColumnName("id");
        builder.Property(n => n.UserId).HasColumnName("user_id");
        builder.Property(n => n.PackageId).HasColumnName("package_id");
        builder.Property(n => n.Type).HasColumnName("type").HasMaxLength(20);
        builder.Property(n => n.Title).HasColumnName("title").HasMaxLength(150).IsRequired();
        builder.Property(n => n.Message).HasColumnName("message").IsRequired();
        builder.Property(n => n.IsRead).HasColumnName("is_read").HasDefaultValue(false);
        builder.Property(n => n.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");

        builder.HasOne(n => n.User).WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(n => n.Package).WithMany(p => p.Notifications)
            .HasForeignKey(n => n.PackageId).OnDelete(DeleteBehavior.Restrict);
    }
}

public class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder.ToTable("packages");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.TrackingCode).HasColumnName("tracking_code").HasMaxLength(20).IsRequired();
        builder.Property(p => p.CustomerId).HasColumnName("customer_id");
        builder.Property(p => p.PackageCategoryId).HasColumnName("package_category_id");
        builder.Property(p => p.RateId).HasColumnName("rate_id");
        builder.Property(p => p.OriginAddressId).HasColumnName("origin_address_id");
        builder.Property(p => p.DestinationAddressId).HasColumnName("destination_address_id");
        builder.Property(p => p.OriginContactName).HasColumnName("origin_contact_name").HasMaxLength(150);
        builder.Property(p => p.OriginContactPhone).HasColumnName("origin_contact_phone").HasMaxLength(20);
        builder.Property(p => p.DestinationContactName).HasColumnName("destination_contact_name").HasMaxLength(150);
        builder.Property(p => p.DestinationContactPhone).HasColumnName("destination_contact_phone").HasMaxLength(20);
        builder.Property(p => p.Description).HasColumnName("description").HasMaxLength(500);
        builder.Property(p => p.WeightKg).HasColumnName("weight_kg").HasColumnType("decimal(8,2)").HasDefaultValue(0m);
        builder.Property(p => p.HeightCm).HasColumnName("height_cm").HasColumnType("decimal(8,2)");
        builder.Property(p => p.WidthCm).HasColumnName("width_cm").HasColumnType("decimal(8,2)");
        builder.Property(p => p.LengthCm).HasColumnName("length_cm").HasColumnType("decimal(8,2)");
        builder.Property(p => p.IsFragile).HasColumnName("is_fragile").HasDefaultValue(false);
        builder.Property(p => p.DistanceKm).HasColumnName("distance_km").HasColumnType("decimal(10,2)");
        builder.Property(p => p.Instructions).HasColumnName("instructions");
        builder.Property(p => p.PackagePhotoUrl).HasColumnName("package_photo_url").HasMaxLength(500);
        builder.Property(p => p.TotalCost).HasColumnName("total_cost").HasColumnType("decimal(10,2)").HasDefaultValue(0m);
        builder.Property(p => p.Currency).HasColumnName("currency").HasMaxLength(3).HasDefaultValue("PEN");
        builder.Property(p => p.EstimatedPickupDate).HasColumnName("estimated_pickup_date");
        builder.Property(p => p.EstimatedDeliveryDate).HasColumnName("estimated_delivery_date");
        builder.Property(p => p.ActualDeliveryDate).HasColumnName("actual_delivery_date");
        builder.Property(p => p.ActualPickupDate).HasColumnName("actual_pickup_date");
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("now()");

        builder.HasIndex(p => p.TrackingCode).IsUnique();

        builder.HasOne(p => p.Customer).WithMany(u => u.Packages)
            .HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PackageCategory).WithMany(c => c.Packages)
            .HasForeignKey(p => p.PackageCategoryId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Rate).WithMany(t => t.Packages)
            .HasForeignKey(p => p.RateId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.OriginAddress).WithMany()
            .HasForeignKey(p => p.OriginAddressId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.DestinationAddress).WithMany()
            .HasForeignKey(p => p.DestinationAddressId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PackageStatus).WithMany()
             .HasForeignKey(p => p.PackageStatusId).OnDelete(DeleteBehavior.Restrict);
    }
}

public class PackageCategoryConfiguration : IEntityTypeConfiguration<PackageCategory>
{
    public void Configure(EntityTypeBuilder<PackageCategory> builder)
    {
        builder.ToTable("package_categories");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(80).IsRequired();
        builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(255);
        builder.Property(c => c.IconUrl).HasColumnName("icon_url").HasMaxLength(500);
        builder.Property(c => c.IsActive).HasColumnName("is_active").HasDefaultValue(true);
        builder.Property(c => c.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.HasIndex(c => c.Name).IsUnique();
    }
}

public class PackageTrackingConfiguration : IEntityTypeConfiguration<PackageTracking>
{
    public void Configure(EntityTypeBuilder<PackageTracking> builder)
    {
        builder.ToTable("package_tracking");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(s => s.PackageId).HasColumnName("package_id");
        builder.Property(s => s.UserId).HasColumnName("user_id");
        builder.Property(s => s.Status).HasColumnName("status").HasMaxLength(60).IsRequired();
        builder.Property(s => s.Description).HasColumnName("description").HasMaxLength(500);
        builder.Property(s => s.Latitude).HasColumnName("latitude").HasColumnType("decimal(10,8)");
        builder.Property(s => s.Longitude).HasColumnName("longitude").HasColumnType("decimal(11,8)");
        builder.Property(s => s.EvidencePhotoUrl).HasColumnName("evidence_photo_url").HasMaxLength(500);
        builder.Property(s => s.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");

        builder.HasOne(s => s.Package).WithMany(p => p.Trackings)
            .HasForeignKey(s => s.PackageId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.User).WithMany()
            .HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.SetNull);
    }
}

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payments");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.PackageId).HasColumnName("package_id");
        builder.Property(p => p.CustomerId).HasColumnName("customer_id");
        builder.Property(p => p.Amount).HasColumnName("amount").HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(p => p.Currency).HasColumnName("currency").HasMaxLength(3).HasDefaultValue("PEN");
        builder.Property(p => p.ExternalReference).HasColumnName("external_reference").HasMaxLength(255);
        builder.Property(p => p.ReceiptUrl).HasColumnName("receipt_url").HasMaxLength(500);
        builder.Property(p => p.PaidAt).HasColumnName("paid_at");
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("now()");

        builder.HasOne(p => p.Package).WithMany(pk => pk.Payments)
            .HasForeignKey(p => p.PackageId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Customer).WithMany()
            .HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PaymentMethod).WithMany()
           .HasForeignKey(p => p.PaymentMethodId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PaymentStatus).WithMany()
           .HasForeignKey(p => p.PaymentStatusId).OnDelete(DeleteBehavior.Restrict);
    }
}


public class RateConfiguration : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        builder.ToTable("rates");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("id");
        builder.Property(t => t.PackageCategoryId).HasColumnName("package_category_id");
        builder.Property(t => t.BasePrice).HasColumnName("base_price").HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(t => t.PricePerKm).HasColumnName("price_per_km").HasColumnType("decimal(10,2)").HasDefaultValue(0m);
        builder.Property(t => t.PricePerKg).HasColumnName("price_per_kg").HasColumnType("decimal(10,2)").HasDefaultValue(0m);
        builder.Property(t => t.MaxWeightKg).HasColumnName("max_weight_kg").HasColumnType("decimal(8,2)");
        builder.Property(t => t.IsActive).HasColumnName("is_active").HasDefaultValue(true);
        builder.Property(t => t.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.Property(t => t.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("now()");

        builder.HasOne(t => t.Category).WithMany(c => c.Rates)
            .HasForeignKey(t => t.PackageCategoryId).OnDelete(DeleteBehavior.Restrict);
    }
}

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("ratings");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.PackageId).HasColumnName("package_id");
        builder.Property(c => c.RaterId).HasColumnName("rater_id");
        builder.Property(c => c.RatedUserId).HasColumnName("rated_user_id");
        builder.Property(c => c.Score).HasColumnName("score");
        builder.Property(c => c.Comment).HasColumnName("comment");
        builder.Property(c => c.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");

        builder.HasIndex(c => c.PackageId).IsUnique();

        builder.HasOne(c => c.Package).WithOne(p => p.Rating)
            .HasForeignKey<Rating>(c => c.PackageId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Rater).WithMany()
            .HasForeignKey(c => c.RaterId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.RatedUser).WithMany()
            .HasForeignKey(c => c.RatedUserId).OnDelete(DeleteBehavior.Restrict);
    }
}

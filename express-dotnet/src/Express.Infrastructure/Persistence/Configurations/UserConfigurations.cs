using Express.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Express.Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("addresses");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id");
        builder.Property(d => d.UserId).HasColumnName("user_id");
        builder.Property(d => d.UbigeoId).HasColumnName("ubigeo_id");
        builder.Property(d => d.Alias).HasColumnName("alias").HasMaxLength(80);
        builder.Property(d => d.AddressLine).HasColumnName("address_line").HasMaxLength(300).IsRequired();
        builder.Property(d => d.Reference).HasColumnName("reference").HasMaxLength(300);
        builder.Property(d => d.Latitude).HasColumnName("latitude").HasColumnType("decimal(10,8)");
        builder.Property(d => d.Longitude).HasColumnName("longitude").HasColumnType("decimal(11,8)");
        builder.Property(d => d.IsPrimary).HasColumnName("is_primary").HasDefaultValue(false);
        builder.Property(d => d.IsActive).HasColumnName("is_active").HasDefaultValue(true);
        builder.Property(d => d.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");

        builder.HasOne(d => d.User).WithMany(u => u.Addresses)
            .HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Ubigeo).WithMany(u => u.Addresses)
            .HasForeignKey(d => d.UbigeoId).OnDelete(DeleteBehavior.Restrict);
    }
}

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).HasColumnName("id");
        builder.Property(r => r.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
        builder.Property(r => r.Description).HasColumnName("description").HasMaxLength(255);
        builder.Property(r => r.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.HasIndex(r => r.Name).IsUnique();

        builder.HasData(
            new { Id = 1, Name = "admin", Description = "System administrator", CreatedAt = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new { Id = 2, Name = "customer", Description = "User who creates and requests shipments", CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new { Id = 3, Name = "courier", Description = "Delivery person who picks up and delivers packages", CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("sessions");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(s => s.UserId).HasColumnName("user_id");
        builder.Property(s => s.Token).HasColumnName("token").HasMaxLength(500).IsRequired();
        builder.Property(s => s.IpAddress).HasColumnName("ip").HasMaxLength(45);
        builder.Property(s => s.UserAgent).HasColumnName("user_agent").HasMaxLength(500);
        builder.Property(s => s.ExpiresAt).HasColumnName("expires_at");
        builder.Property(s => s.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.HasIndex(s => s.Token).IsUnique();

        builder.HasOne(s => s.User)
            .WithMany(u => u.Sessions)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
{
    public void Configure(EntityTypeBuilder<Ubigeo> builder)
    {
        builder.ToTable("ubigeos");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id");
        builder.Property(u => u.Code).HasColumnName("code").HasMaxLength(10).IsRequired();
        builder.Property(u => u.Department).HasColumnName("department").HasMaxLength(100).IsRequired();
        builder.Property(u => u.Province).HasColumnName("province").HasMaxLength(100).IsRequired();
        builder.Property(u => u.District).HasColumnName("district").HasMaxLength(100).IsRequired();
        builder.HasIndex(u => u.Code).IsUnique();
    }
}
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id");
        builder.Property(u => u.RoleId).HasColumnName("role_id");
        builder.Property(u => u.FirstName).HasColumnName("first_names").HasMaxLength(100).IsRequired();
        builder.Property(u => u.LastName).HasColumnName("last_names").HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(150).IsRequired();
        builder.Property(u => u.Phone).HasColumnName("phone").HasMaxLength(20);
        builder.Property(u => u.PasswordHash).HasColumnName("password_hash").HasMaxLength(255).IsRequired();
        builder.Property(u => u.AvatarUrl).HasColumnName("avatar_url").HasMaxLength(500);
        builder.Property(u => u.IsActive).HasColumnName("is_active").HasDefaultValue(true);
        builder.Property(u => u.IsEmailVerified).HasColumnName("email_verified").HasDefaultValue(false);
        builder.Property(u => u.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("now()");

        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class VerificationTokenConfiguration : IEntityTypeConfiguration<VerificationToken>
{
    public void Configure(EntityTypeBuilder<VerificationToken> builder)
    {
        builder.ToTable("verification_tokens");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("id");
        builder.Property(t => t.UserId).HasColumnName("user_id");
        builder.Property(t => t.Token).HasColumnName("token").HasMaxLength(255).IsRequired();
        builder.Property(t => t.ExpiresAt).HasColumnName("expires_at");
        builder.Property(t => t.IsUsed).HasColumnName("is_used").HasDefaultValue(false);
        builder.Property(t => t.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
        builder.HasIndex(t => t.Token).IsUnique();

        builder.HasOne(t => t.User)
            .WithMany(u => u.Tokens)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.TokenType)
           .WithMany()
           .HasForeignKey(t => t.TokenTypeId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}


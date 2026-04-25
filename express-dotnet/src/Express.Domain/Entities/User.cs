using Express.Domain.Primitives;

namespace Express.Domain.Entities;

public class User : BaseEntity
{
    public int RoleId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Phone { get; set; }
    public string PasswordHash { get; set; } = default!;
    public string? AvatarUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsEmailVerified { get; set; } = false;

    // Navigation
    public Role Role { get; set; } = default!;
    public DriverProfile? DriverProfile { get; set; }
    public ICollection<Address> Addresses { get; set; } = [];
    public ICollection<Package> Packages { get; set; } = [];
    public ICollection<Notification> Notifications { get; set; } = [];
    public ICollection<VerificationToken> Tokens { get; set; } = [];
    public ICollection<Session> Sessions { get; set; } = [];
}

using Express.Domain.Entities;

namespace Express.Application.Common.Interfaces;

public interface IJwtService
{
    string GenerateAccessToken(User user);
    (string token, DateTime expiresAt) GenerateRefreshToken();
    int? GetUserIdFromToken(string token);
}

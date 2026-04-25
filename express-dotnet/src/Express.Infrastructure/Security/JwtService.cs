using Express.Application.Common.Interfaces;
using Express.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Express.Infrastructure.Security;

public class JwtService(IConfiguration config) : IJwtService
{
    private readonly string _secret = config["Jwt:Secret"] ?? throw new InvalidOperationException("Jwt:Secret no configurado.");
    private readonly string _issuer = config["Jwt:Issuer"] ?? "courier-api";
    private readonly string _audience = config["Jwt:Audience"] ?? "courier-client";
    private readonly int _accessMinutes = int.TryParse(config["Jwt:AccessTokenMinutes"], out var m) ? m : 60;
    private readonly int _refreshDays = int.TryParse(config["Jwt:RefreshTokenDays"], out var d) ? d : 7;

    public string GenerateAccessToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role?.Name ?? "customer"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_accessMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public (string token, DateTime expiresAt) GenerateRefreshToken()
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        return (token, DateTime.UtcNow.AddDays(_refreshDays));
    }

    public int? GetUserIdFromToken(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var sub = jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
            return int.TryParse(sub, out var id) ? id : null;
        }
        catch { return null; }
    }
}


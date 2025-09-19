using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fanap.Shop.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Fanap.Shop.Appliction.Services;

public class JwtService
{
    private readonly string _secret;
    private readonly int _expiryMinutes;

    public JwtService(string secret, int expiryMinutes = 60)
    {
        _secret = secret;
        _expiryMinutes = expiryMinutes;
    }


    public string GenerateToken(User user)
    {
        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
        new Claim(ClaimTypes.Role, user.Role)
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Fanap.Shop",
            audience: "Fanap.Shop",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_expiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

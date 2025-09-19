using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Fanap.Shop.Appliction.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetRole(this ClaimsPrincipal user) =>
        user.FindFirst(ClaimTypes.Role)?.Value;

    public static Guid? GetUserId(this ClaimsPrincipal user) =>
        Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id)
            ? id
            : null;
}

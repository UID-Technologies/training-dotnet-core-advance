using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdvancedAspNetTraining.Web.Auth;

public sealed class JwtTokenService : IJwtTokenService
{
    private readonly JwtSettings _settings;

    private static readonly Dictionary<string, (string Password, string[] Roles, string[] Permissions)> Users =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["admin"] = ("Admin@123", ["Admin"], ["orders:read", "orders:write"]),
            ["reader"] = ("Reader@123", ["User"], ["orders:read"]),
            ["writer"] = ("Writer@123", ["User"], ["orders:read", "orders:write"])
        };

    public JwtTokenService(IOptions<JwtSettings> options)
    {
        _settings = options.Value;
    }

    public (bool Success, string? Token, IReadOnlyList<string> Roles, IReadOnlyList<string> Permissions) Authenticate(
        string username,
        string password)
    {
        if (!Users.TryGetValue(username, out var account) || account.Password != password)
        {
            return (false, null, [], []);
        }

        var token = GenerateToken(username, account.Roles, account.Permissions);
        return (true, token, account.Roles, account.Permissions);
    }

    public string GenerateToken(string username, IEnumerable<string> roles, IEnumerable<string> permissions)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, username),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        claims.AddRange(permissions.Select(permission => new Claim("permission", permission)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SigningKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

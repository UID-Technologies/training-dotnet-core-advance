namespace AdvancedAspNetTraining.Web.Auth;

public interface IJwtTokenService
{
    (bool Success, string? Token, IReadOnlyList<string> Roles, IReadOnlyList<string> Permissions) Authenticate(
        string username,
        string password);

    string GenerateToken(string username, IEnumerable<string> roles, IEnumerable<string> permissions);
}

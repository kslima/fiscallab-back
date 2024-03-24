using Microsoft.IdentityModel.Tokens;

namespace FiscalLabService.Identity.Resources;

public class JwtOptions
{
    public string Key { get; set; } = string.Empty;
    public SecurityKey SecurityKey { get; set; } = null!;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int Expiration { get; set; }
}
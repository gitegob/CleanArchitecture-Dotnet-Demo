namespace BuberDinner.Infrastructure.Config;

public class JwtSettings
{
    public const string SectionName = "Jwt";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable. 
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpirationInMinutes { get; set; }
}
namespace VaccinationSystem.Infrastructure.Auth
{
    public class JwtConfig
    {
        public string Key { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public int ExpirationMinutes { get; init; }
    }
}

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Infrastructure.Auth
{
    public class JwtTokenGenerator(JwtConfig config) : IJwtTokenGenerator
    {
        private readonly JwtConfig _config = config;

        public string GenerateToken(User user)
        {
            // Criar claims
            List<Claim> claims =
            [
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, user.Name),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];

            // Criar assinatura
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_config.Key));
            
            SigningCredentials credentials = new(
                key,
                SecurityAlgorithms.HmacSha256);

            // Criar token
            JwtSecurityToken token = new(
                issuer: _config.Issuer,
                audience: _config.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_config.ExpirationMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

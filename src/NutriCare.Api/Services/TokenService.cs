using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NutriCare.Api.Interfaces;

namespace NutriCare.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey; // Your secret key for signing tokens

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:Key"] ?? throw new InvalidOperationException("MyConfig:MySetting is missing in appsettings.json");
        }
        public TokenService(string secretKey)
        {
            _secretKey = secretKey;
        }

        public string GenerateToken(string userId, string userEmail)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Email, userEmail)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Set token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

using prueba_tecnica_backend.Models;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace prueba_tecnica_backend.Utils
{
    public class GenerateJWTToken
    {
        private IConfiguration _configuration;
        public GenerateJWTToken(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public IConfiguration Get_configuration()
        {
            return _configuration;
        }

        public string GenerateJWT(User user, IConfiguration _configuration)
        {
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_TOKEN"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtConfiguration = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfiguration);
        }
    }
}

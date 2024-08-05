using prueba_tecnica_backend.Models;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

// Clase para generar el token como pase con JWTBearer

namespace prueba_tecnica_backend.Utils
{
    public class GenerateJWTToken
    {
        // Para obtener la configuración de nuestro archivo secreto generado (secrets.json)
        private IConfiguration _configuration;
        // Creamos un constructor para inyectar nuestra configuración aqui
        public GenerateJWTToken(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public IConfiguration Get_configuration()
        {
            return _configuration;
        }

        // Método que nos permitirá generar nuestro token teniendo como parametros la clase User y la configuracion de nuestro archivo secrets.json
        public string GenerateJWT(User user, IConfiguration _configuration)
        {
            // Creando claims para indicar que información del usuario será encriptada en nuestro token
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            // Codificando nuestro token que hemos generado de manera aleatoria
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_TOKEN"]!));
            // Realizando la firma de nuestras credenciales con el token codificado
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Realizando la configuración de nuestro JWT enviando nuestros claims, las horas que tendra vigencia y las credenciales firmadas
            var jwtConfiguration = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            // Retornamos nuestro token JWT generado
            return new JwtSecurityTokenHandler().WriteToken(jwtConfiguration);
        }
    }
}

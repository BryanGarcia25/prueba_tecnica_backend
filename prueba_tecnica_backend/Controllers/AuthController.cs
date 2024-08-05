using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Data;
using prueba_tecnica_backend.Models;
using prueba_tecnica_backend.Utils;
using System.Text;

namespace prueba_tecnica_backend.Controllers
{
    // Indicamos que este controlador recibira solicitudes HTTP
    [ApiController]
    // La clase hereda de ControllerBase del modelo MVC
    public class AuthController : ControllerBase
    {
        // variable privada que hace referencia a la clase donde se encuentra nuestra conexión con la base de datos
        private readonly ConnectDB _connectDB;
        // Variable privada que hace referencia a la clase donde se genera nuestro token de pase con JWTBearer
        private readonly GenerateJWTToken _generateJWTToken;

        // Constructor para injectar las clases ConnectDB y GenerateJWTToken
        public AuthController(ConnectDB connectDB, GenerateJWTToken generateJWTToken) 
        {
            _connectDB = connectDB;
            _generateJWTToken = generateJWTToken;
        }

        // Método para determinar si el usuario existe o no en la base de datos
        [HttpPost]
        [Route("auth/login")]
        public async Task<IActionResult> getUsername(Authentication authentication)
        {
            // Verifica si el nombre del usuario y su email existen
            var registeredUser = await _connectDB.Users.Where(x => x.Name == authentication.Name && x.Email == authentication.Email).FirstOrDefaultAsync();

            if (registeredUser != null)
            {
                // Si el usuario existe procede a generarle un token para acceder a la aplicación
                return Ok(_generateJWTToken.GenerateJWT(registeredUser, _generateJWTToken.Get_configuration()));                
            }
            else
            {
                // En caso de que no exista retornará un 404
                return NotFound();
            }
        }
    }
}

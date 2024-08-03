using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Data;
using prueba_tecnica_backend.Models;
using prueba_tecnica_backend.Utils;
using System.Text;

namespace prueba_tecnica_backend.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ConnectDB _connectDB;
        private readonly GenerateJWTToken _generateJWTToken;

        public AuthController(ConnectDB connectDB, GenerateJWTToken generateJWTToken) 
        {
            _connectDB = connectDB;
            _generateJWTToken = generateJWTToken;
        }

        [HttpPost]
        [Route("auth/login")]
        public async Task<IActionResult> getUsername(Authentication authentication)
        {
            var registeredUser = await _connectDB.Users.Where(x => x.Name == authentication.Name && x.Email == authentication.Email).FirstOrDefaultAsync();

            if (registeredUser != null)
            {
                return Ok(_generateJWTToken.GenerateJWT(registeredUser, _generateJWTToken.Get_configuration()));                
            }
            else
            {
                return NotFound();
            }
        }
    }
}

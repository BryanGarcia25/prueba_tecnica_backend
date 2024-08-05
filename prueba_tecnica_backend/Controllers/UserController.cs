using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Data;
using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Controllers
{
    // Indicamos que este controlador recibira solicitudes HTTP
    [ApiController]
    // Indicamos que este controlador debe tener una autorización especifica para hacer uso de estas peticiones, por ejemplo tener un Token JWT
    [Authorize]
    // La clase hereda de ControllerBase del modelo MVC
    public class UserController : ControllerBase
    {
        // variable privada que hace referencia a la clase donde se encuentra nuestra conexión con la base de datos
        private readonly ConnectDB _connectDB;

        // Constructor para injectar la clase ConnectDB
        public UserController(ConnectDB connectDB)
        {
            _connectDB = connectDB;
        }

        // Método para crear un nuevo usuario con un contacto asignado
        [HttpPost]
        [Route("users/create")]
        public async Task<IActionResult> CreateUser(User user)
        {
            _connectDB.Users.Add(user);
            await _connectDB.SaveChangesAsync();
            return Ok(user);
        }

        // Método para obtener todos los usuarios registrados con su contacto asignado
        [HttpGet]
        [Route("users/registered_users")]
        public async Task<IActionResult> GetUsers()
        {
            var registeredUsers = await _connectDB.Users.Include(a => a.Contacts).ToListAsync();
            return Ok(registeredUsers);
        }

        // Método para obtener un usuario en especifico con su contacto asignado
        [HttpGet]
        [Route("users/registered_user/{id}")]
        public IActionResult GetUserById(int id)
        {
            // Busca si existe el usuario con el id enviado y si tiene un contacto asignado también
            var registeredUser = _connectDB.Users.Include(a => a.Contacts).FirstOrDefault(x => x.Id == id);
            return Ok(registeredUser);
        }

        // Método para actualizar el usuario y contacto en especifico
        [HttpPost]
        [Route("users/update")]
        public async Task<IActionResult> UpdateUserById(User user)
        {
            _connectDB.Users.Update(user);
            await _connectDB.SaveChangesAsync();
            return Ok(user);
        }

        // Método para eliminar el usuario y contacto por medio de su id
        [HttpPost]
        [Route("users/delete/{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            // Busca si existe el usuario con el id enviado
            var registeredUser = _connectDB.Users.Find(id);

            if (registeredUser != null)
            {
                // En caso de que exista el usuario procede a eliminarlo de la base de datos
                _connectDB.Users.Remove(registeredUser);
                await _connectDB.SaveChangesAsync();
                return Ok("Usuario eliminado con el id " + id);
            }
            else
            {
                // En caso de que no exista retorna un 404
                return NotFound();
            }
        }
    }
}

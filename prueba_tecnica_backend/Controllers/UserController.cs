using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Data;
using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly ConnectDB _connectDB;

        public UserController(ConnectDB connectDB)
        {
            _connectDB = connectDB;
        }

        [HttpPost]
        [Route("users/create")]
        public async Task<IActionResult> CreateUser(User user)
        {
            _connectDB.Users.Add(user);
            await _connectDB.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("users/registered_users")]
        public async Task<IActionResult> GetUsers()
        {
            var registeredUsers = await _connectDB.Users.Include(a => a.Contacts).ToListAsync();
            return Ok(registeredUsers);
        }

        [HttpGet]
        [Route("users/registered_user/{id}")]
        public IActionResult GetUserById(int id)
        {
            var registeredUser = _connectDB.Users.Include(a => a.Contacts).FirstOrDefault(x => x.Id == id);
            return Ok(registeredUser);
        }

        [HttpPost]
        [Route("users/update")]
        public async Task<IActionResult> UpdateUserById(User user)
        {
            _connectDB.Users.Update(user);
            await _connectDB.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost]
        [Route("users/delete/{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var registeredUser = _connectDB.Users.Find(id);

            if (registeredUser != null)
            {
                _connectDB.Users.Remove(registeredUser);
                await _connectDB.SaveChangesAsync();
                return Ok("Usuario eliminado con el id " + id);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

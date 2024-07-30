using Microsoft.AspNetCore.Mvc;

namespace prueba_tecnica_backend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("users/create")]
        public string CreateUser()
        {
            return "Creando nuevo usuario";
        }

        [HttpGet]
        [Route("users/registered_users")]
        public string GetUsers()
        {
            return "Hola usuario";
        }

        [HttpGet]
        [Route("users/registered_user/{id}")]
        public string GetUserById(int id)
        {
            return "Usuario con el id " + id;
        }

        [HttpPost]
        [Route("users/update/{id}")]
        public string UpdateUserById(int id)
        {
            return "Actualizando usuario con el id " + id;
        }

        [HttpPost]
        [Route("users/delete/{id}")]
        public string DeleteUserById(int id)
        {
            return "Eliminando usuario con el id " + id;
        }
    }
}

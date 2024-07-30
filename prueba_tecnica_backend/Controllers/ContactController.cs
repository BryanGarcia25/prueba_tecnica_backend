using Microsoft.AspNetCore.Mvc;

namespace prueba_tecnica_backend.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        [Route("contact/create")]
        public string CreateContact()
        {
            return "Creando contacto nuevo";
        }

        [HttpPost]
        [Route("contact/registered_contacts")]
        public string GetContacts()
        {
            return "Obteniendo contactos registrados";
        }

        [HttpPost]
        [Route("contact/registered_contact/{id}")]
        public string GetContactById(int id)
        {
            return "Obteniendo contacto con el id " + id;
        }

        [HttpPost]
        [Route("contact/update/{id}")]
        public string UpdateContactById(int id)
        {
            return "Actualizando contacto con el id " + id;
        }

        [HttpPost]
        [Route("contact/delete{id}")]
        public string DeleteContactById(int id)
        {
            return "Eliminando contacto con el id " + id;
        }
    }
}

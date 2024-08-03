using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Data;
using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ConnectDB _connectDB;
        public ContactController(ConnectDB connectDB) 
        {
            _connectDB = connectDB;
        }

        [HttpPost]
        [Route("contact/create")]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            _connectDB.Contacts.Add(contact);
            await _connectDB.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpGet]
        [Route("contact/registered_contacts")]
        public async Task<IActionResult> GetContacts()
        {
            var registeredContacts = await _connectDB.Contacts.ToListAsync();
            return Ok(registeredContacts);
        }

        [HttpGet]
        [Route("contact/registered_contact/{id}")]
        public IActionResult GetContactById(int id)
        {
            var registeredContact = _connectDB.Contacts.Find(id);

            if (registeredContact == null) 
            {
                return NotFound();
            } else
            {
                return Ok(registeredContact);
            }

        }

        [HttpPost]
        [Route("contact/update")]
        public async Task<IActionResult> UpdateContactById(Contact contact)
        {
            _connectDB.Contacts.Update(contact);
            await _connectDB.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPost]
        [Route("contact/delete{id}")]
        public async Task<IActionResult> DeleteContactById(int id)
        {
            var registerContact = _connectDB.Contacts.Find(id);
            if (registerContact == null)
            {
                return NotFound();
            }
            else
            {
                _connectDB.Contacts.Remove(registerContact);
                await _connectDB.SaveChangesAsync();
                return Ok("Se ha eliminado el contacto con el id " + id);
            }
        }
    }
}

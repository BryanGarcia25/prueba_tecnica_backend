using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_tecnica_backend.Models
{

    // Creando clase como modelo llamada Contact con los atributos Id, Name, Phone, Email y References, creando una llave foránea llamada UserId para hacer referencia a la tabla Users
    public class Contact
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string References { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

    }
}

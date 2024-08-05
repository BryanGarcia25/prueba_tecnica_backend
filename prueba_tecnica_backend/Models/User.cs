using System.ComponentModel.DataAnnotations;

namespace prueba_tecnica_backend.Models
{
    // Creando clase como modelo llamada User con los atributos Id, Name, Email y CreateDate
    public class User
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required DateTime CreateDate { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace prueba_tecnica_backend.Models
{
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

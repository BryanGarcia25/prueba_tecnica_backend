namespace prueba_tecnica_backend.Models
{
    // Creando clase como modelo llamada Authentication con los atributos Name y Email
    public class Authentication
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Models;

// Clase para realizar las configuraciones necesarias que establecerán la conexión con la base de datos MySQL

namespace prueba_tecnica_backend.Data
{
    // Heredando la clase DbContext para establecer una sesión con la base de datos y empezar a crear nuestras tablas con base a nuestras entidades
    public class ConnectDB : DbContext
    {
        // Para obtener la configuración de nuestro archivo secreto generado (secrets.json)
        private IConfiguration _configuration;
        // Creamos nuestra instancia a la entidad Users
        public DbSet<User> Users { get; set; }
        // Creamos nuestra instancia a la entidad Contacts
        public DbSet<Contact> Contacts { get; set; }

        // Creamos un constructor para inyectar nuestra configuración aqui
        public ConnectDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Método para establecer la configuración inicial que permita conectarnos a la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Obteniendo la version actual de MySQL
            var serverVersion = ServerVersion.AutoDetect(_configuration["CONNECT_DB"]);
            // Creando la conexión con la información de nuestra base de datos MySQL que tenemos (Ejemplo: usuario, password y nombre de la base de datos) y la versión que se detecto
            optionsBuilder.UseMySql(_configuration["CONNECT_DB"], serverVersion);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Data
{
    public class ConnectDB : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public ConnectDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = ServerVersion.AutoDetect(_configuration["CONNECT_DB"]);
            optionsBuilder.UseMySql(_configuration["CONNECT_DB"], serverVersion);
        }
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_tecnica_backend.Models
{
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

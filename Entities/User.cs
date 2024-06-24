using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Usuario")]
    public class User
    {
        [Column("id_usuario")]
        [Key]
        public int IdUser { get; set; }
        
        [Column("identificacion_usuario")]
        public int IdentificationUser { get; set; }

        [Column("destino_email")]
        public string? EmailDestination { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("contrasena")]
        public string? Password { get; set; }
    }
}
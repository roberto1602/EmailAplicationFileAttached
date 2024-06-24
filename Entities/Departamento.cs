using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Keyless]
    public class Departamento
    {
        [Column("DepartamentoID")]
        public int DepartamentoID { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("PaisID")]
        public int PaisID { get; set; }
    }
}
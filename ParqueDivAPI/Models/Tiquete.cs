using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParqueDivAPI.Models
{
    public class Tiquete
    {
        [Key]
        public int TiqueteId { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaCierre { get; set; }
        public string? Ubicacion { get; set; }
        [ForeignKey("Empleados")]
        public int EmpleadoId { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }
    }
}

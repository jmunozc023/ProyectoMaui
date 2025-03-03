using System.ComponentModel.DataAnnotations;

namespace ParqueDivAPI.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Cargo { get; set; }
        public string? Password { get; set; }
    }
}

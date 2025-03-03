using System.ComponentModel.DataAnnotations;

namespace ParqueDivAPI.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParqueDivAPI.Models
{
    public class Favorito
    {
        [Key]
        public int FavoritoId { get; set; }

        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }
        [ForeignKey("Tiquetes")]
        public int TiqueteId { get; set; }
    }
}

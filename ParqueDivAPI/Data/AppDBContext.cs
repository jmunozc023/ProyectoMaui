using Microsoft.EntityFrameworkCore;
using ParqueDivAPI.Models;


namespace ParqueDivAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleados => Set<Empleado>();
        public DbSet<Favorito> Favoritos => Set<Favorito>();
        public DbSet<Tiquete> Tiquetes => Set<Tiquete>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
    }
}

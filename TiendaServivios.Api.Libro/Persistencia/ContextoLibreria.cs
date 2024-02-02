using Microsoft.EntityFrameworkCore;
using TiendaServivios.Api.Libro.Modelo;

namespace TiendaServivios.Api.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria() { }
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options) { }

        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}

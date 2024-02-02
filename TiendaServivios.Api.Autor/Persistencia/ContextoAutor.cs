using Microsoft.EntityFrameworkCore;
using TiendaServivios.Api.Autor.Modelo;

namespace TiendaServivios.Api.Autor.Persistencia
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options) { }

        public DbSet<AutorLibro> AutorLibro { get; set; }  

        public DbSet<GradoAcademico> GradoAcademico { get; set; }


    }
}

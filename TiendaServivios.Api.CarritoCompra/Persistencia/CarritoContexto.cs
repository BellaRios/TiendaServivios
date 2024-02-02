using Microsoft.EntityFrameworkCore;
using TiendaServivios.Api.CarritoCompra.Modelo;

namespace TiendaServivios.Api.CarritoCompra.Persistencia
{
    public class CarritoContexto : DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> options) : base(options) { }

        public DbSet<CarritoSesion> CarritoSesion { get; set;}

        public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set;}    
    }
}

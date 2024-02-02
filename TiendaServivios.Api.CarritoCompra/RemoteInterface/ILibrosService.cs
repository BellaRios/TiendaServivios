using System;
using System.Threading.Tasks;
using TiendaServivios.Api.CarritoCompra.RemoteModel;

namespace TiendaServivios.Api.CarritoCompra.RemoteInterface
{
    public interface ILibrosService
    {
        Task<(bool resultado, LibroRemote Libro,string ErrorMessage)>  GetLibro(Guid LibroId);
    }
}

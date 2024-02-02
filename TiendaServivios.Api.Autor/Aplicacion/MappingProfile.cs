using AutoMapper;
using TiendaServivios.Api.Autor.Modelo;

namespace TiendaServivios.Api.Autor.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
           CreateMap<AutorLibro,AutorDto>();
        }
    }
}

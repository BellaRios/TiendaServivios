using AutoMapper;
using TiendaServivios.Api.Libro.Modelo;

namespace TiendaServivios.Api.Libro.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaServivios.Api.Libro.Modelo;
using TiendaServivios.Api.Libro.Aplicacion;

namespace TiendaServivios.Api.Libro.Tests
{
    public class MappingTest : Profile
    {
        public MappingTest() 
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        
        }
    }
}

using System.Collections.Generic;
using System;
using TiendaServivios.Api.Autor.Modelo;

namespace TiendaServivios.Api.Autor.Aplicacion
{
    public class AutorDto
    {
        
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }       

        public string AutorLibroGuid { get; set; }
    }
}

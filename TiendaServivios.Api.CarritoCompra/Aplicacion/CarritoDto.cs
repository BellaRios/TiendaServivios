using System;
using System.Collections.Generic;

namespace TiendaServivios.Api.CarritoCompra.Aplicacion
{
    public class CarritoDto
    {
        public int CarritoId { get; set; }  

        public DateTime? FechaCreacionSesion { get; set; }  

        public List<CarritoDetalleDto> ListaProductos { get; set; }


    }
}

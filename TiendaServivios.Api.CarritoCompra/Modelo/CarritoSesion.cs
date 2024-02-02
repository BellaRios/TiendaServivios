using System;
using System.Collections;
using System.Collections.Generic;

namespace TiendaServivios.Api.CarritoCompra.Modelo
{
    public class CarritoSesion
    {
        public int CarritoSesionId {  get; set; }

        public DateTime? FechaCreacion { get; set; }

        public ICollection<CarritoSesionDetalle> ListaDetalle { get; set; }
    }
}

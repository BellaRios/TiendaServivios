using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServivios.Api.Autor.Modelo;
using TiendaServivios.Api.Autor.Persistencia;

namespace TiendaServivios.Api.Autor.Aplicacion
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDto>> {
        }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador (ContextoAutor contexto , IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }       

            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutorLibro.ToListAsync();
                var autoresDto = _mapper.Map<List<AutorLibro>,List<AutorDto>>(autores);

                return autoresDto;

            }
        }
    }
}

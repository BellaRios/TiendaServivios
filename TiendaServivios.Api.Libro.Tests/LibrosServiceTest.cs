using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaServivios.Api.Libro.Aplicacion;
using TiendaServivios.Api.Libro.Modelo;
using TiendaServivios.Api.Libro.Persistencia;
using Xunit;

namespace TiendaServivios.Api.Libro.Tests
{
    public class LibrosServiceTest
    {

        private IEnumerable<LibreriaMaterial> ObtenerDataPrueba() 
        {
          A.Configure<LibreriaMaterial>()
                .Fill(x=> x.Titulo).AsArticleTitle()
                .Fill(x=> x.LibreriaMaterialId,() => { return Guid.NewGuid(); });


            var lista = A.ListOf<LibreriaMaterial>(30);
            lista[0].LibreriaMaterialId = Guid.Empty;   
            return lista;

         
        }

        private Mock<ContextoLibreria> CrearContexto() 
        {

            //clase de tipo entidad
          var dataPrueba = ObtenerDataPrueba().AsQueryable();

          var dbSet = new Mock<DbSet<LibreriaMaterial>>();
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator);

            dbSet.As<IAsyncEnumerable<LibreriaMaterial>>().Setup(x=>x.GetAsyncEnumerator(new System.Threading.CancellationToken())).Returns(new AsyncEnumerator<LibreriaMaterial>(dataPrueba.GetEnumerator()));
            
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x=> x.Provider).Returns(new AsyncQueryProvider<LibreriaMaterial>(dataPrueba.Provider));
            
            
            
            var contexto= new Mock<ContextoLibreria>();
            contexto.Setup(x => x.LibreriaMaterial).Returns(dbSet.Object);
            return contexto;
        
        }

        [Fact]
        public async void GetLibroPorId() 
        {

            var mockContexto = CrearContexto();

            var mapConfig = new MapperConfiguration( cfg => { cfg.AddProfile(new MappingTest());});

            var mapper = mapConfig.CreateMapper();

            var request = new ConsultaFiltro.LibroUnico();
            request.LibroId = Guid.Empty;

            var manejador = new ConsultaFiltro.Manejador(mockContexto.Object, mapper);

            var libro= await  manejador.Handle(request,new System.Threading.CancellationToken());

            Assert.NotNull(libro); // esto significa que al hacer la transaccion y devuelva un valor correctamente este va hacer verdadero y va a pasar el test pero si regresa en nullo se marcara de rojo

            Assert.True(libro.LibreriaMaterialId == Guid.Empty);
        
        }

        [Fact]
        public async void GetLibros() 
        {
                        
            //1.Emular a la instancia de entity framework core -  ContextoLibreria
            // para emular las acciones y eventos de un objeto en un ambiente de unit test
            // utilizaremos objetos de tipo Mock

            var mockContexto = CrearContexto();

            //2. Emular al mapping IMapper

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());


            });


            var mapper = mapConfig.CreateMapper();

            //3.Instanciar a la clase Manejador y pasarle como parametros los mocks que he creado

            Consulta.Manejador manejador = new Consulta.Manejador(mockContexto.Object, mapper);

            Consulta.Ejecuta request = new Consulta.Ejecuta();

            var lista = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(lista.Any());

        
        }


        [Fact]

        public async void GuardarLibro() 
        {
            System.Diagnostics.Debugger.Launch();


            var options = new DbContextOptionsBuilder<ContextoLibreria>()
                 .UseInMemoryDatabase(databaseName: "BaseDatosLibro")
                 .Options;

            var contexto= new ContextoLibreria(options);
            var request = new Nuevo.Ejecuta();
            request.Titulo = "Libro de Microservice";
            request.AutorLibro = Guid.Empty;
            request.FechaPublicacion= DateTime.Now;

            var manejador = new Nuevo.Manejador(contexto);
            var libro= await manejador.Handle(request,new System.Threading.CancellationToken());

            Assert.True(libro!=null);// si libro es diferente a nullo va a significar que paso el test porque esta devolviendo el objeto task unit en caso contrario va a disparar un exception y el valor del libro va hacer nullo

        }

    }
}

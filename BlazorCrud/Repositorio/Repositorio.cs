using BlazorCrud.Data;
using BlazorCrud.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly ApplicationDbContext _contexto;

        public Repositorio(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Libro> ActualizarLibro(int libroId, Libro actualizarLibro)
        {
           var libroDesdeBD = await _contexto.libro.FindAsync(libroId);

            libroDesdeBD.Titulo = actualizarLibro.Titulo;
            libroDesdeBD.Descripcion = actualizarLibro.Descripcion;
            libroDesdeBD.Autor = actualizarLibro.Autor;
            libroDesdeBD.Paginas = actualizarLibro.Paginas;
            libroDesdeBD.Precio = actualizarLibro.Precio;

            await _contexto.SaveChangesAsync();

            return libroDesdeBD;
        }

        public async Task<Libro> CrearLibro(Libro crearLibro)
        {
            if (crearLibro != null)
            {
                crearLibro.Fecha = DateTime.Now;
                await _contexto.libro.AddAsync(crearLibro);
                await _contexto.SaveChangesAsync();
                return crearLibro;
            }
            else
            {
                return new Libro();
            }
        }

        public async Task EliminarLibro(int libroId)
        {
            var libroDesdeBD = await _contexto.libro.FindAsync(libroId);
            _contexto.Remove(libroDesdeBD);

            await _contexto.SaveChangesAsync();
        }

        public async Task<Libro> GetLibroId(int libroId)
        {
            var libroDesdeBD = await _contexto.libro.FindAsync(libroId);
            if (libroDesdeBD == null)
            {
                return new Libro();
            }
            return libroDesdeBD;
        }

        public Task<List<Libro>> GetLibros()
        {
            return _contexto.libro.ToListAsync();
        }
    }
}

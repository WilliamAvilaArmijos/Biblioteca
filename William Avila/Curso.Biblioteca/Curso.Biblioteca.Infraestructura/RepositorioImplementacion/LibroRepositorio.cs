using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Infraestructura.Context;

namespace Curso.Biblioteca.Infraestructura.RepositorioImplementacion
{
    public class LibroRepositorio:ILibroRepositorio
    {
        private readonly BibliotecaContexto contexto;
        public LibroRepositorio(BibliotecaContexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task CreateAsync(Libro libro)
        {
            await contexto.AddAsync(libro);
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Libro libro)
        {
            contexto.Remove(libro);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Libro> GetAll()
        {
            return contexto.Libros.AsQueryable();
        }

        public async Task UpdateAsync(Libro libro)
        {
            contexto.Update(libro);
            await contexto.SaveChangesAsync();
        }
    }
}

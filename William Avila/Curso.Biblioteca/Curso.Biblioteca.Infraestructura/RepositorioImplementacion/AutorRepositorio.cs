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
    public class AutorRepositorio : IAutorRepositorio
    {

        private readonly BibliotecaContexto contexto;
        public AutorRepositorio(BibliotecaContexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task CreateAsync(Autor autor)
        {
            await contexto.AddAsync(autor);
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Autor autor)
        {
            contexto.Remove(autor);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Autor> GetAll()
        {
            return contexto.Autores.AsQueryable();
        }

        public async Task UpdateAsync(Autor autor)
        {
            contexto.Update(autor);
            await contexto.SaveChangesAsync();
        }
    }
}

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
    public class EditorialRepositorio:IEditorialRepositorio
    {
        private readonly BibliotecaContexto contexto;
        public EditorialRepositorio(BibliotecaContexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task CreateAsync(Editorial editorial)
        {
            await contexto.AddAsync(editorial);
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Editorial editorial)
        {
            contexto.Remove(editorial);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Editorial> GetAll()
        {
            return contexto.Editoriales.AsQueryable();
        }

        public async Task UpdateAsync(Editorial editorial)
        {
            contexto.Update(editorial);
            await contexto.SaveChangesAsync();
        }
    }
}

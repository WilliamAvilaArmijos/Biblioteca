using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Biblioteca.Dominio.Entidades;

namespace Curso.Biblioteca.Dominio.RepositorioDefinicion
{
    public interface IAutorRepositorio
    {
        IQueryable<Autor> GetAll();
        Task CreateAsync(Autor autor);
        Task UpdateAsync(Autor autor);
        Task DeleteAsync(Autor autor);
    }
}

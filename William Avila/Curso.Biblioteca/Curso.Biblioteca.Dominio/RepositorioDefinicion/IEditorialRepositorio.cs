using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Biblioteca.Dominio.Entidades;

namespace Curso.Biblioteca.Dominio.RepositorioDefinicion
{
    public interface IEditorialRepositorio
    {
        IQueryable<Editorial> GetAll();
        Task CreateAsync(Editorial editorial);
        Task UpdateAsync(Editorial editorial);
        Task DeleteAsync(Editorial editorial);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Biblioteca.Aplicacion.Dtos;

namespace Curso.Biblioteca.Aplicacion.ServicioDefinicion
{
    public interface ILibroServicio
    {
        Task<ICollection<LibroDto>> GetAllAsync();
        Task<LibroDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CrearActualizarLibroDto libroDto);
        Task<bool> UpdateAsync(int id, CrearActualizarLibroDto libroDto);
        Task<bool> DeleteAsync(int id);
    }
}

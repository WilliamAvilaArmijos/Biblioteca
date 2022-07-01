using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Biblioteca.Aplicacion.Dtos;

namespace Curso.Biblioteca.Aplicacion.ServicioDefinicion
{
    public interface IEditorialServicio
    {
        Task<ICollection<EditorialDto>> GetAllAsync();
        Task<EditorialDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CrearActualizarEditorialDto editorialDto);
        Task<bool> UpdateAsync(int id, CrearActualizarEditorialDto editorialDto);
        Task<bool> DeleteAsync(int id);
    }
}

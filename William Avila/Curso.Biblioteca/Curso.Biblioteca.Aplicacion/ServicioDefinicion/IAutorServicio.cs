using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Biblioteca.Aplicacion.Dtos;

namespace Curso.Biblioteca.Aplicacion.ServicioDefinicion
{
    public interface IAutorServicio
    {
        Task<ICollection<AutorDto>> GetAllAsync();
        Task<AutorDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CrearActualizarAutorDto autorDto);
        Task<bool> UpdateAsync(int id, CrearActualizarAutorDto autorDto);
        Task<bool> DeleteAsync(int id);
    }
}

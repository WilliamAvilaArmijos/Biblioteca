using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServicioDefinicion;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase, ILibroServicio
    {
        private readonly ILibroServicio servicio;

        public LibroController(ILibroServicio servicio)
        {
            this.servicio = servicio;
        }
        [HttpPost]
        public async Task<bool> CreateAsync(CrearActualizarLibroDto libroDto)
        {
            return await servicio.CreateAsync(libroDto);
        }
        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await servicio.DeleteAsync(id);
        }
        [HttpGet]
        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            return await servicio.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<LibroDto> GetByIdAsync(int id)
        {
            return await servicio.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CrearActualizarLibroDto libroDto)
        {
            return await servicio.UpdateAsync(id, libroDto);
        }
    }
}

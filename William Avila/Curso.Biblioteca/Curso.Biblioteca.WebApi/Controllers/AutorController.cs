using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServicioDefinicion;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase, IAutorServicio
    {
        private readonly IAutorServicio servicio;

        public AutorController(IAutorServicio servicio)
        {
            this.servicio = servicio;
        }
        [HttpPost]
        public async Task<bool> CreateAsync(CrearActualizarAutorDto autorDto)
        {
            return await servicio.CreateAsync(autorDto);
        }
        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await servicio.DeleteAsync(id);
        }
        [HttpGet]
        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            return await servicio.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<AutorDto> GetByIdAsync(int id)
        {
            return await servicio.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CrearActualizarAutorDto autorDto)
        {
            return await servicio.UpdateAsync(id, autorDto);
        }
    }
}

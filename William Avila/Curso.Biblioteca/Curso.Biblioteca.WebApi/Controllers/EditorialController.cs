using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServicioDefinicion;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase, IEditorialServicio
    {
        private readonly IEditorialServicio servicio;

        public EditorialController(IEditorialServicio servicio)
        {
            this.servicio = servicio;
        }
        [HttpPost]
        public async Task<bool> CreateAsync(CrearActualizarEditorialDto editorialDto)
        {
            return await servicio.CreateAsync(editorialDto);
        }
        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await servicio.DeleteAsync(id);
        }
        [HttpGet]
        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            return await servicio.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            return await servicio.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CrearActualizarEditorialDto editorialDto)
        {
            return await servicio.UpdateAsync(id, editorialDto);
        }
    }
}

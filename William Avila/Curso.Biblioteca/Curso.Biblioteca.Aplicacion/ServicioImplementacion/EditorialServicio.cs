using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServicioDefinicion;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Microsoft.EntityFrameworkCore;

namespace Curso.Biblioteca.Aplicacion.ServicioImplementacion
{
    public class EditorialServicio:IEditorialServicio
    {
        readonly IEditorialRepositorio repositorio;

        public EditorialServicio(IEditorialRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        public async Task<bool> CreateAsync(CrearActualizarEditorialDto editorialDto)
        {
            var editorial = new Editorial
            {
                Nombre = editorialDto.Nombre,
                Direccion = editorialDto.Direccion
            };
            await repositorio.CreateAsync(editorial);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var editorial = consulta.SingleOrDefault();

            await repositorio.DeleteAsync(editorial);
            return true;
        }

        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            var consulta = repositorio.GetAll();
            var listaEditorial = await consulta.Select(c => new EditorialDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Direccion = c.Direccion
            }).ToListAsync();
            return listaEditorial;
        }

        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var editorial = await consulta.Select(c => new EditorialDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Direccion = c.Direccion
            }).SingleOrDefaultAsync();
            return editorial;
        }

        public async Task<bool> UpdateAsync(int id, CrearActualizarEditorialDto editorialDto)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var editorial = consulta.SingleOrDefault();
            editorial.Nombre = editorialDto.Nombre;
            editorial.Direccion = editorialDto.Direccion;
            await repositorio.UpdateAsync(editorial);
            return true;
        }
    }
}

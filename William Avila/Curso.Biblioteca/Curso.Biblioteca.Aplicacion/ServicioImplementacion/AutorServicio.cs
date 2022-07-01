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
    public class AutorServicio : IAutorServicio
    {
        readonly IAutorRepositorio repositorio;

        public AutorServicio(IAutorRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        public async Task<bool> CreateAsync(CrearActualizarAutorDto autorDto)
        {
            var autor = new Autor
            {
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido
            };
            await repositorio.CreateAsync(autor);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var autor = consulta.SingleOrDefault();

            await repositorio.DeleteAsync(autor);
            return true;
        }

        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            var consulta = repositorio.GetAll();
            var listaAutor = await consulta.Select(c => new AutorDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido
            }).ToListAsync();
            return listaAutor;
        }

        public async Task<AutorDto> GetByIdAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var autor = await consulta.Select(c => new AutorDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido
            }).SingleOrDefaultAsync();
            return autor;
        }

        public async Task<bool> UpdateAsync(int id, CrearActualizarAutorDto autorDto)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var autor = consulta.SingleOrDefault();
            autor.Nombre = autorDto.Nombre;
            autor.Apellido = autorDto.Apellido;
            await repositorio.UpdateAsync(autor);
            return true;
        }
    }
}

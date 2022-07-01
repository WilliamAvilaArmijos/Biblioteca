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
    public class LibroServicio:ILibroServicio
    {
        readonly ILibroRepositorio repositorio;

        public LibroServicio(ILibroRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        public async Task<bool> CreateAsync(CrearActualizarLibroDto libroDto)
        {
            var libro = new Libro
            {
                Titulo = libroDto.Titulo,
                ISBN = libroDto.ISBN,
                AutorId = libroDto.AutorId,
                EditorialId = libroDto.EditorialId,
            };
            await repositorio.CreateAsync(libro);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = consulta.SingleOrDefault();

            await repositorio.DeleteAsync(libro);
            return true;
        }

        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            var consulta = repositorio.GetAll();
            var listaLibro = await consulta.Select(c => new LibroDto
            {
                Id = c.Id,
                Titulo = c.Titulo,
                ISBN= c.ISBN,
                Autor = $"{c.Autor.Nombre} {c.Autor.Apellido}",
                Editorial = c.Editorial.Nombre,
            }).ToListAsync();
            return listaLibro;
        }

        public async Task<LibroDto> GetByIdAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = await consulta.Select(c => new LibroDto
            {
                Id = c.Id,
                Titulo = c.Titulo,
                ISBN = c.ISBN,
                Autor = $"{c.Autor.Nombre} {c.Autor.Apellido}",
                Editorial = c.Editorial.Nombre,
            }).SingleOrDefaultAsync();
            return libro;
        }

        public async Task<bool> UpdateAsync(int id, CrearActualizarLibroDto libroDto)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = consulta.SingleOrDefault();
            libro.Titulo = libroDto.Titulo;
            libro.ISBN = libroDto.ISBN;
            libro.AutorId = libroDto.AutorId;
            libro.EditorialId = libroDto.EditorialId;
            await repositorio.UpdateAsync(libro);
            return true;
        }
    }
}

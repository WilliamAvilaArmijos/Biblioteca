using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Curso.Biblioteca.Infraestructura.Context
{
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder constructor)
        {
            var conexion = @"Server=(localdb)\mssqllocaldb;Database=Biblioteca;Trusted_Connection=True";
            constructor.UseSqlServer(conexion);
        }
    }
}

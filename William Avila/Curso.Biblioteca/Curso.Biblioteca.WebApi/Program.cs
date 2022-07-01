using Curso.Biblioteca.Aplicacion.ServicioDefinicion;
using Curso.Biblioteca.Aplicacion.ServicioImplementacion;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Infraestructura.Context;
using Curso.Biblioteca.Infraestructura.RepositorioImplementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BibliotecaContexto>();

builder.Services.AddTransient<IAutorRepositorio, AutorRepositorio>();
builder.Services.AddTransient<IEditorialRepositorio, EditorialRepositorio>();
builder.Services.AddTransient<ILibroRepositorio, LibroRepositorio>();

builder.Services.AddTransient<IAutorServicio, AutorServicio>();
builder.Services.AddTransient<IEditorialServicio, EditorialServicio>();
builder.Services.AddTransient<ILibroServicio, LibroServicio>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

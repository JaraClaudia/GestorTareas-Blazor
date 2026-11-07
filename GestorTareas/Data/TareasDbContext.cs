using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas.Data;

public class TareasDbContext : DbContext
{
    public TareasDbContext(DbContextOptions<TareasDbContext> options)
        : base(options)
    {
    }

    public DbSet<TareaEntity> Tareas => Set<TareaEntity>();
    public DbSet<Categoria> Categorias => Set<Categoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TareaEntity>(e =>
        {
            e.HasIndex(t => t.Prioridad);

            e.HasOne(t => t.Categoria)
                .WithMany(c => c.Tareas)
                .HasForeignKey(t => t.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<Categoria>().HasData(
    new Categoria { Id = 1, Nombre = "Trabajo" },
    new Categoria { Id = 2, Nombre = "Estudio" },
    new Categoria { Id = 3, Nombre = "Personal" },
    new Categoria { Id = 4, Nombre = "Hogar" },
    new Categoria { Id = 5, Nombre = "Compras" }
);

        modelBuilder.Entity<TareaEntity>().HasData(
            new TareaEntity { Id = 1, Titulo = "Entregar TP integrador de Blazor", Descripcion = "Proyecto final de la materia", Prioridad = "Alta", FechaVencimiento = new DateTime(2026, 10, 26), Completada = false, CreadaEn = new DateTime(2026, 10, 1), CategoriaId = 2 },
            new TareaEntity { Id = 2, Titulo = "Repasar migraciones de EF Core", Descripcion = "Up, Down y snapshot", Prioridad = "Alta", FechaVencimiento = new DateTime(2026, 10, 22), Completada = false, CreadaEn = new DateTime(2026, 10, 1), CategoriaId = 2 },
            new TareaEntity { Id = 3, Titulo = "Subir el proyecto a GitHub", Descripcion = "Con commits convencionales", Prioridad = "Media", FechaVencimiento = new DateTime(2026, 10, 23), Completada = false, CreadaEn = new DateTime(2026, 10, 2), CategoriaId = 2 },
            new TareaEntity { Id = 4, Titulo = "Armar el informe mensual", Descripcion = "Resumen de actividades", Prioridad = "Media", FechaVencimiento = new DateTime(2026, 10, 30), Completada = false, CreadaEn = new DateTime(2026, 10, 3), CategoriaId = 1 },
            new TareaEntity { Id = 5, Titulo = "Responder correos pendientes", Descripcion = null, Prioridad = "Baja", FechaVencimiento = new DateTime(2026, 10, 21), Completada = true, CreadaEn = new DateTime(2026, 10, 3), CategoriaId = 1 },
            new TareaEntity { Id = 6, Titulo = "Hacer ejercicio", Descripcion = "Caminata de 30 minutos", Prioridad = "Baja", FechaVencimiento = new DateTime(2026, 10, 20), Completada = false, CreadaEn = new DateTime(2026, 10, 4), CategoriaId = 3 },
            new TareaEntity { Id = 7, Titulo = "Llamar a la familia", Descripcion = null, Prioridad = "Media", FechaVencimiento = new DateTime(2026, 10, 25), Completada = false, CreadaEn = new DateTime(2026, 10, 4), CategoriaId = 3 },
            new TareaEntity { Id = 8, Titulo = "Limpiar la casa", Descripcion = "Cocina y baño", Prioridad = "Media", FechaVencimiento = new DateTime(2026, 10, 24), Completada = false, CreadaEn = new DateTime(2026, 10, 5), CategoriaId = 4 },
            new TareaEntity { Id = 9, Titulo = "Arreglar la canilla", Descripcion = null, Prioridad = "Baja", FechaVencimiento = new DateTime(2026, 11, 2), Completada = false, CreadaEn = new DateTime(2026, 10, 5), CategoriaId = 4 },
            new TareaEntity { Id = 10, Titulo = "Comprar insumos de la semana", Descripcion = "Verdulería y almacén", Prioridad = "Alta", FechaVencimiento = new DateTime(2026, 10, 20), Completada = false, CreadaEn = new DateTime(2026, 10, 6), CategoriaId = 5 }
        );
    }
}
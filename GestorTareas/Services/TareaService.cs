using GestorTareas.Data;
using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas.Services;

public class TareaService : ITareaService
{
    private readonly IDbContextFactory<TareasDbContext> _factory;
    private readonly ILogger<TareaService> _logger;

    public TareaService(IDbContextFactory<TareasDbContext> factory, ILogger<TareaService> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public async Task<List<TareaEntity>> ObtenerTodas()
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Tareas
            .Include(t => t.Categoria)
            .OrderByDescending(t => t.CreadaEn)
            .AsNoTracking()
            .ToListAsync();
    }

    // Paginación + búsqueda (el parámetro texto es la búsqueda por título)
    public async Task<PagedResult<TareaEntity>> ObtenerPaginado(int pagina, int tamanio, string? texto = null)
    {
        pagina = Math.Max(1, pagina);

        await using var ctx = await _factory.CreateDbContextAsync();

        IQueryable<TareaEntity> consulta = ctx.Tareas;

        if (!string.IsNullOrWhiteSpace(texto))
        {
            consulta = consulta.Where(t => t.Titulo.Contains(texto));
        }

        var total = await consulta.CountAsync();

        var items = await consulta
            .Include(t => t.Categoria)
            .OrderByDescending(t => t.CreadaEn)
            .ThenBy(t => t.Id)
            .Skip((pagina - 1) * tamanio)
            .Take(tamanio)
            .AsNoTracking()
            .ToListAsync();

        return new PagedResult<TareaEntity>
        {
            Items = items,
            TotalItems = total,
            Pagina = pagina,
            TamanioPagina = tamanio
        };
    }

    public async Task<TareaEntity?> ObtenerPorId(int id)
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Tareas
            .Include(t => t.Categoria)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TareaEntity> Crear(TareaEntity tarea)
    {
        try
        {
            await using var ctx = await _factory.CreateDbContextAsync();
            ctx.Tareas.Add(tarea);
            await ctx.SaveChangesAsync();
            return tarea;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Error al crear la tarea {Titulo}", tarea.Titulo);
            throw;
        }
    }

    public async Task<TareaEntity> Actualizar(TareaEntity tarea)
    {
        try
        {
            await using var ctx = await _factory.CreateDbContextAsync();

            // Evita que EF intente reconciliar la categoría vieja con el nuevo CategoriaId
            tarea.Categoria = null;

            ctx.Tareas.Update(tarea);
            await ctx.SaveChangesAsync();
            return tarea;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Error al actualizar la tarea {Id}", tarea.Id);
            throw;
        }
    }

    public async Task ToggleCompletar(int id)
    {
        try
        {
            await using var ctx = await _factory.CreateDbContextAsync();
            var tarea = await ctx.Tareas.FindAsync(id);
            if (tarea is not null)
            {
                tarea.Completada = !tarea.Completada;
                await ctx.SaveChangesAsync();
            }
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Error al cambiar el estado de la tarea {Id}", id);
            throw;
        }
    }

    public async Task Eliminar(int id)
    {
        try
        {
            await using var ctx = await _factory.CreateDbContextAsync();
            var tarea = await ctx.Tareas.FindAsync(id);
            if (tarea is not null)
            {
                ctx.Tareas.Remove(tarea);
                await ctx.SaveChangesAsync();
            }
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Error al eliminar la tarea {Id}", id);
            throw;
        }
    }

    public async Task<List<Categoria>> ObtenerCategorias()
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Categorias
            .OrderBy(c => c.Nombre)
            .AsNoTracking()
            .ToListAsync();
    }

    // Estadísticas calculadas en la base de datos (GroupBy se traduce a SQL)
    public async Task<EstadisticasTareas> ObtenerEstadisticas()
    {
        await using var ctx = await _factory.CreateDbContextAsync();

        var porPrioridad = await ctx.Tareas
            .GroupBy(t => t.Prioridad)
            .Select(g => new { Prioridad = g.Key, Cantidad = g.Count() })
            .ToDictionaryAsync(x => x.Prioridad, x => x.Cantidad);

        return new EstadisticasTareas
        {
            Total = await ctx.Tareas.CountAsync(),
            Completadas = await ctx.Tareas.CountAsync(t => t.Completada),
            PorPrioridad = porPrioridad
        };
    }
}

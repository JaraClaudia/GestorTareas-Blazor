using GestorTareas.Data;
using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas.Services;

public class TareaConsultas
{
    private readonly TareasDbContext _context;

    public TareaConsultas(TareasDbContext context)
    {
        _context = context;
    }

    // 1. Eager loading: tareas pendientes con su categoría
    public async Task<List<TareaEntity>> ObtenerPendientes()
    {
        return await _context.Tareas
            .Include(t => t.Categoria)
            .Where(t => !t.Completada)
            .OrderBy(t => t.FechaVencimiento)
            .AsNoTracking()
            .ToListAsync();
    }

    // 2. Búsqueda por título (se traduce a SQL LIKE '%texto%')
    public async Task<List<TareaEntity>> Buscar(string texto)
    {
        return await _context.Tareas
            .Include(t => t.Categoria)
            .Where(t => t.Titulo.Contains(texto))
            .AsNoTracking()
            .ToListAsync();
    }

    // 3. Paginación con conteo total
    public async Task<PagedResult<TareaEntity>> ObtenerPaginado(int pagina, int tamanio)
    {
        var total = await _context.Tareas.CountAsync();

        var items = await _context.Tareas
            .Include(t => t.Categoria)
            .OrderBy(t => t.Id)
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
}

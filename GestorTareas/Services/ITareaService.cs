using GestorTareas.Models;

namespace GestorTareas.Services;

public interface ITareaService
{
    Task<List<TareaEntity>> ObtenerTodas();
    Task<PagedResult<TareaEntity>> ObtenerPaginado(int pagina, int tamanio, string? texto = null);
    Task<TareaEntity?> ObtenerPorId(int id);
    Task<TareaEntity> Crear(TareaEntity tarea);
    Task<TareaEntity> Actualizar(TareaEntity tarea);
    Task ToggleCompletar(int id);
    Task Eliminar(int id);
    Task<List<Categoria>> ObtenerCategorias();
    Task<EstadisticasTareas> ObtenerEstadisticas();
}
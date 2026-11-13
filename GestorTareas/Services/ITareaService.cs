using GestorTareas.Models;

namespace GestorTareas.Services;

/// <summary>
/// Servicio principal para la gestión de tareas y categorías.
/// Encapsula el acceso a la base de datos para que los componentes Blazor no usen el DbContext directamente.
/// </summary>
public interface ITareaService
{
    /// <summary>Obtiene todas las tareas con su categoría, de la más reciente a la más antigua.</summary>
    /// <returns>Lista de entidades <see cref="TareaEntity"/>.</returns>
    Task<List<TareaEntity>> ObtenerTodas();

    /// <summary>
    /// Obtiene una página de tareas ordenadas por fecha de creación (más recientes primero),
    /// con búsqueda opcional por título.
    /// </summary>
    /// <param name="pagina">Número de página, empezando en 1. Los valores menores a 1 se toman como 1.</param>
    /// <param name="tamanio">Cantidad de tareas por página.</param>
    /// <param name="texto">Texto a buscar dentro del título. Si es <c>null</c>, vacío o solo espacios, no se filtra.</param>
    /// <returns>Un <see cref="PagedResult{T}"/> con los elementos de la página y los datos de paginación.</returns>
    Task<PagedResult<TareaEntity>> ObtenerPaginado(int pagina, int tamanio, string? texto = null);

    /// <summary>Busca una tarea por su identificador, incluyendo su categoría.</summary>
    /// <param name="id">Id de la tarea.</param>
    /// <returns>La tarea encontrada, o <c>null</c> si no existe.</returns>
    Task<TareaEntity?> ObtenerPorId(int id);

    /// <summary>Crea una nueva tarea en la base de datos.</summary>
    /// <param name="tarea">Entidad con los datos de la nueva tarea.</param>
    /// <returns>La entidad creada, con el Id asignado.</returns>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException">Si falla la persistencia (el error se registra en el log y se relanza).</exception>
    Task<TareaEntity> Crear(TareaEntity tarea);

    /// <summary>Actualiza los datos de una tarea existente.</summary>
    /// <param name="tarea">
    /// Entidad con los datos modificados. Su propiedad <c>Categoria</c> se establece en <c>null</c>
    /// para que se use solo el <c>CategoriaId</c>.
    /// </param>
    /// <returns>La entidad actualizada.</returns>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException">Si falla la persistencia (el error se registra en el log y se relanza).</exception>
    Task<TareaEntity> Actualizar(TareaEntity tarea);

    /// <summary>
    /// Alterna el estado de una tarea entre completada y pendiente.
    /// Si el Id no existe, no hace nada.
    /// </summary>
    /// <param name="id">Id de la tarea a modificar.</param>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException">Si falla la persistencia (el error se registra en el log y se relanza).</exception>
    Task ToggleCompletar(int id);

    /// <summary>Elimina una tarea por su identificador. Si el Id no existe, no hace nada.</summary>
    /// <param name="id">Id de la tarea a eliminar.</param>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException">Si falla la persistencia (el error se registra en el log y se relanza).</exception>
    Task Eliminar(int id);

    /// <summary>Obtiene las categorías ordenadas por nombre, por ejemplo para llenar el selector del formulario.</summary>
    /// <returns>Lista de entidades <see cref="Categoria"/>.</returns>
    Task<List<Categoria>> ObtenerCategorias();

    /// <summary>
    /// Calcula las estadísticas de las tareas (total, completadas y cantidad por prioridad)
    /// con consultas a la base de datos.
    /// </summary>
    /// <returns>Un objeto <see cref="EstadisticasTareas"/> con los conteos.</returns>
    Task<EstadisticasTareas> ObtenerEstadisticas();
}
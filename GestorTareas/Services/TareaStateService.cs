using GestorTareas.Models;

namespace GestorTareas.Services;

/// <summary>
/// Estado compartido de la aplicación. Se registra como Scoped: una instancia por usuario conectado.
/// Guarda las últimas estadísticas de tareas y avisa a los componentes suscriptos cuando cambian.
/// </summary>
public class TareaStateService
{
    /// <summary>Últimas estadísticas conocidas, o <c>null</c> si todavía no se cargaron.</summary>
    public EstadisticasTareas? Estadisticas { get; private set; }

    /// <summary>Se dispara cada vez que cambia el estado, para que los componentes se vuelvan a dibujar.</summary>
    public event Action? OnChange;

    /// <summary>Guarda las nuevas estadísticas y notifica a los componentes suscriptos.</summary>
    public void ActualizarEstadisticas(EstadisticasTareas estadisticas)
    {
        Estadisticas = estadisticas;
        OnChange?.Invoke();
    }
}

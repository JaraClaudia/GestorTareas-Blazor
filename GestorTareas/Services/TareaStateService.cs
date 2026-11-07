using GestorTareas.Models;

namespace GestorTareas.Services
{
    public class TareaStateService
    {
        private List<TareaModel> tareas = new()
    {
        new() { Id = 1, Titulo = "Entregar TP Blazor", Descripcion = "Terminar el proyecto integrador", Prioridad = "Alta" },
        new() { Id = 2, Titulo = "Comprar insumos", Descripcion = "Para la semana", Prioridad = "Media" },
        new() { Id = 3, Titulo = "Estudiar SQL Server", Descripcion = "Repasar joins", Prioridad = "Baja" }
    };

        private int siguienteId = 4;

        // Evento que avisa a cualquier componente suscripto que los datos cambiaron
        public event Action? OnChange;

        public List<TareaModel> ObtenerTodas() => tareas;

        public TareaModel? ObtenerPorId(int id) => tareas.FirstOrDefault(t => t.Id == id);

        public void Agregar(TareaModel tarea)
        {
            tarea.Id = siguienteId++;
            tareas.Add(tarea);
            NotificarCambio();
        }

        public void Eliminar(int id)
        {
            var tarea = ObtenerPorId(id);
            if (tarea is not null)
            {
                tareas.Remove(tarea);
                NotificarCambio();
            }
        }

        private void NotificarCambio() => OnChange?.Invoke();

    }
}

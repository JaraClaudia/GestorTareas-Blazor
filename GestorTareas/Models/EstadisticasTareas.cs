namespace GestorTareas.Models
{
    public class EstadisticasTareas
    {
        public int Total { get; set; }
        public int Completadas { get; set; }
        public int Pendientes => Total - Completadas;
        public Dictionary<string, int> PorPrioridad { get; set; } = new();
    }
}

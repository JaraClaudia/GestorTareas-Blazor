namespace GestorTareas.Models
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalItems { get; set; }
        public int Pagina { get; set; }
        public int TamanioPagina { get; set; }

        public int TotalPaginas =>
            (int)Math.Ceiling(TotalItems / (double)TamanioPagina);
    }
}

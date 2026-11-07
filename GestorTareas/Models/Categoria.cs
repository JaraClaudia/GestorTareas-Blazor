using System.ComponentModel.DataAnnotations;

namespace GestorTareas.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<TareaEntity> Tareas { get; set; } = new List<TareaEntity>();
    }
}

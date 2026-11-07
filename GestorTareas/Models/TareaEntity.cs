using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTareas.Models;

public class TareaEntity : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio")]
    [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "Máximo 500 caracteres")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una prioridad")]
    public string Prioridad { get; set; } = "Media";

    [FechaFutura]
    public DateTime? FechaVencimiento { get; set; }

    public bool Completada { get; set; }

    public DateTime CreadaEn { get; set; } = DateTime.UtcNow;

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría")]
    public int CategoriaId { get; set; }

    [ForeignKey(nameof(CategoriaId))]
    public Categoria? Categoria { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (FechaVencimiento is null)
        {
            yield return new ValidationResult(
                "La fecha de vencimiento es obligatoria.",
                new[] { nameof(FechaVencimiento) });
        }
        else if (Prioridad == "Alta" && FechaVencimiento > DateTime.Today.AddDays(7))
        {
            yield return new ValidationResult(
                "Las tareas de prioridad Alta deben vencer dentro de los próximos 7 días.",
                new[] { nameof(FechaVencimiento) });
        }
    }
}

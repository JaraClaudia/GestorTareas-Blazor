using System.ComponentModel.DataAnnotations;

namespace GestorTareas.Models
{
    public class TareaModel:IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Entre 3 y 50 caracteres")]
        public string Titulo { get; set; } = string.Empty;


        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string? Descripcion { get; set; }
       
        [Required(ErrorMessage = "Debe seleccionar una prioridad")] 
        public string Prioridad { get; set; } = "Media"; // Alta / Media / Baja

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        [FechaFutura]
        public DateTime FechaVencimiento { get; set; } = DateTime.Today.AddDays(1);
        public bool Completada { get; set; }
        // Validación cruzada: si la prioridad es Alta, el vencimiento no puede superar los 7 días
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Prioridad == "Alta" && FechaVencimiento > DateTime.Today.AddDays(7))
            {
                yield return new ValidationResult(
                    "Las tareas de prioridad Alta deben vencer dentro de los próximos 7 días.",
                    new[] { nameof(FechaVencimiento) });
            }
        }

    }
}

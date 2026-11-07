using System.ComponentModel.DataAnnotations;
namespace GestorTareas.Models
{
    public class FechaFuturaAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime fecha && fecha.Date < DateTime.Today)
            {
                return new ValidationResult("La fecha de vencimiento no puede ser una fecha pasada.");
            }

            return ValidationResult.Success;
        }
    }
}

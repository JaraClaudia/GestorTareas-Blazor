using System.ComponentModel.DataAnnotations;
namespace GestorTareas.Models
{
    /// <summary>
    /// Valida que la fecha ingresada no sea anterior a hoy.
    /// </summary>
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

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProyectoFichaMedica.Validation
{
    public class RutValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string rut || string.IsNullOrEmpty(rut))
            {
                return ValidationResult.Success!;
            }

            rut = rut.Replace(".", "");

            var rutPattern = @"^(\d{1,8}-[\dkK])$";

            if (!Regex.IsMatch(rut, rutPattern))
            {
                return new ValidationResult(ErrorMessage ?? "El formato del RUT no es válido.");
            }

            return ValidationResult.Success!;
        }
    }
}
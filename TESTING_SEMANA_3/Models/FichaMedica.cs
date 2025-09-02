using ProyectoFichaMedica.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFichaMedica.Models
{
    [Table("FichasMedicas")]
    public class FichaMedica
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El RUT es un campo obligatorio.")]
        [Display(Name = "RUT del Paciente")]
        [StringLength(12)]
        [RutValido(ErrorMessage = "El formato del RUT no es válido. Use el formato 12345678-9.")]
        public string Rut { get; set; } = string.Empty;


        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es un campo obligatorio.")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "El apellido solo puede contener letras y espacios.")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es un campo obligatorio.")]
        [StringLength(200)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es un campo obligatorio.")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "La ciudad solo puede contener letras y espacios.")]
        public string Ciudad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es un campo obligatorio.")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "El teléfono debe tener 12 caracteres (ej: +56912345678).")]
        [RegularExpression(@"^\+569\d{8}$", ErrorMessage = "El formato debe ser +569 seguido de 8 dígitos.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es un campo obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El formato del email no es válido.")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Debe seleccionar una opción para el sexo.")]
        public string Sexo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado civil es un campo obligatorio.")]
        [Display(Name = "Estado Civil")]
        [StringLength(50)]
        public string? EstadoCivil { get; set; }

        [Required(ErrorMessage = "El campo de comentarios es obligatorio.")]
        [DataType(DataType.MultilineText)]
        public string Comentarios { get; set; } = string.Empty;
    }
}
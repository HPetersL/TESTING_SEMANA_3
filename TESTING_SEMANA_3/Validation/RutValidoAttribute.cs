using System.ComponentModel.DataAnnotations;

namespace ProyectoFichaMedica.Validation
{
    public class RutValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string rut || string.IsNullOrEmpty(rut))
            {
                return ValidationResult.Success; 
            }

            try
            {
                rut = rut.ToUpper().Replace(".", "").Replace("-", "");

                string cuerpo = rut.Substring(0, rut.Length - 1);
                char dv = rut[rut.Length - 1];

                //modulo 11
                int suma = 0;
                int multiplo = 2;

                for (int i = cuerpo.Length - 1; i >= 0; i--)
                {
                    suma += int.Parse(cuerpo[i].ToString()) * multiplo;
                    if (multiplo < 7)
                    {
                        multiplo++;
                    }
                    else
                    {
                        multiplo = 2;
                    }
                }

                int digitoEsperado = 11 - (suma % 11);
                string dvEsperado = digitoEsperado.ToString();

                if (digitoEsperado == 11)
                {
                    dvEsperado = "0";
                }
                if (digitoEsperado == 10)
                {
                    dvEsperado = "K";
                }

                if (dv.ToString() == dvEsperado)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage ?? "El RUT no es válido (dígito verificador incorrecto).");
                }
            }
            catch (Exception)
            {
                return new ValidationResult(ErrorMessage ?? "El RUT no tiene un formato válido.");
            }
        }
    }
    
}
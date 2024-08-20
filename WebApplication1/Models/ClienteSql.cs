using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ClienteSql
    {
        public int Codigo {get;set;}
        [Required]
        [StringLength(10)]
        public string Cedula {get;set;}
        [Required]
        [StringLength(100)]
        public string Apellidos {get;set;}
        [Required]
        [StringLength(10)]
        public string Nombres {get;set;}
        public DateTime FechaNacimiento {get;set;}
        public string Mail {get;set;}
        [MaxLength(10,ErrorMessage ="El número de teléfono debe ser de 10 caracteres")]
        public string Telefono { get; set; }
        // public string Direccion { get; set; }
        public Boolean Estado { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El saldo no puede ser negativo")]
        public decimal Saldo { get; set; } = 0;
        [Required]
        public string Provincia { get; set; }

    }

    // Validación personalizada para la cédula
    public class CustomValidationCedula : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cedula = value as string;

            if (cedula == null || cedula.Length != 10)
            {
                return new ValidationResult("La cédula debe tener 10 dígitos.");
            }

            int provincia = int.Parse(cedula.Substring(0, 2));
            int tercerDigito = int.Parse(cedula.Substring(2, 1));

            if (!EsProvinciaValida(provincia))
            {
                return new ValidationResult("Los dos primeros dígitos de la cédula no corresponden a una provincia válida.");
            }

            if (tercerDigito < 0 || tercerDigito > 5)
            {
                return new ValidationResult("El tercer dígito de la cédula es inválido.");
            }

            if (!EsCedulaValida(cedula))
            {
                return new ValidationResult("La cédula es inválida.");
            }

            return ValidationResult.Success;
        }

        private bool EsProvinciaValida(int provincia)
        {
            int[] provinciasValidas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 30 };
            return Array.Exists(provinciasValidas, p => p == provincia);
        }

        private bool EsCedulaValida(string cedula)
        {
            int sumaImpares = 0;
            int sumaPares = 0;

            for (int i = 0; i < 9; i++)
            {
                int digito = int.Parse(cedula.Substring(i, 1));

                if (i % 2 == 0) // Posiciones impares
                {
                    digito *= 2;
                    if (digito > 9)
                    {
                        digito -= 9;
                    }
                    sumaImpares += digito;
                }
                else // Posiciones pares
                {
                    sumaPares += digito;
                }
            }

            int totalSuma = sumaImpares + sumaPares;
            int modulo = totalSuma % 10;
            int digitoVerificador = modulo == 0 ? 0 : 10 - modulo;

            return digitoVerificador == int.Parse(cedula.Substring(9, 1));
        }
    }
}
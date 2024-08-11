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
    }
}
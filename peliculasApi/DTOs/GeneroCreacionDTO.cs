using peliculasApi.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace peliculasApi.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [StringLength(maximumLength: 50)]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}

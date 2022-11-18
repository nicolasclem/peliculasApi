using peliculasApi.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace peliculasApi.Entidades
{
    public class Genero 
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="el campo {0} es requerido")]
        [StringLength(maximumLength:50)]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public List<PeliculasGeneros> PeliculasGeneros { get; set; }


    }
}

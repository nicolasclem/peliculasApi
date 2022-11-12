using peliculasApi.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace peliculasApi.Entidades
{
    public class Genero : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="el campo {0} es requerido")]
        [StringLength(maximumLength:10)]
        //[PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primerLetra= Nombre[0].ToString();
                if(primerLetra != primerLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser maysucula",
                        new string[] { nameof(Nombre) });
                }
            }
        }
    }
}

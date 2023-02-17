using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Vehicles.API.Data.Entities
{
    public class Procedure
    {
        public int Id { get; set; }

        [Display(Name = "Procedimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression((@"^(0|-?\d{0,16}(\.\d{0,2})?)$"))]
        [Range(0, 9999999999.999999)]
        public decimal Price { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Vehicles.API.Data.Entities
{
    public class Detail
    {
        public int Id { get; set; }

        //[JsonIgnore]
        [Display(Name = "Historia")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public History History { get; set; }

        [Display(Name = "Procedimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Procedure Procedure { get; set; }

        [Display(Name = "Precio Mano de Obra")]
        [RegularExpression((@"^(0|-?\d{0,16}(\.\d{0,2})?)$"))]
        [Range(0, 9999999999.999999)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal LaborPrice { get; set; }

        [Display(Name = "Precio Repuestos")]
        [RegularExpression((@"^(0|-?\d{0,16}(\.\d{0,2})?)$"))]
        [Range(0, 9999999999.999999)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal SparePartsPrice { get; set; }

        [Display(Name = "Total")]
        [RegularExpression((@"^(0|-?\d{0,16}(\.\d{0,2})?)$"))]
        [Range(0, 9999999999.999999)]
        public decimal TotalPrice => LaborPrice + SparePartsPrice;

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}

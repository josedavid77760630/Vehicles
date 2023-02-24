using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Vehicles.API.Models
{
    public class DetailViewModel
    {
        public int Id { get; set; }

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

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public int HistoryId { get; set; }

        [Display(Name = "Procedimiento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un procedimiento.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ProcedureId { get; set; }

        public IEnumerable<SelectListItem> Procedures { get; set; }
    }
}

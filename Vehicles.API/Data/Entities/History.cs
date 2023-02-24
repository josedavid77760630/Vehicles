using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Linq;

namespace Vehicles.API.Data.Entities
{
    public class History
    {
        public int Id { get; set; }

        [Display(Name = "Vehículo")]
        //[JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM tt}")]
        public DateTime Date { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM tt}")]
        public DateTime DateLocal => Date.ToLocalTime();

        [Display(Name = "Kilometraje")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Mileage { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "Mecanico")]
        //[JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public User User { get; set; }

        public ICollection<Detail> Details { get; set; }

        [Display(Name = "# Detalles")]
        public int DetailsCount => Details == null ? 0 : Details.Count;

        [Display(Name = "Total Mano de Obra")]
        [RegularExpression((@"^(0|-?\d{0,16}(\.\d{0,2})?)$"))]
        [Range(0, 9999999999.999999)]
        public decimal TotalLabor => Details == null ? 0 : Details.Sum(x => x.LaborPrice);

        [Display(Name = "Total Repuestos")]
        [RegularExpression((@"^(0|-?\d{0,16}(\.\d{0,2})?)$"))]
        [Range(0, 9999999999.999999)]
        public decimal TotalSpareParts => Details == null ? 0 : Details.Sum(x => x.SparePartsPrice);

        [Display(Name = "Total")]
        [RegularExpression((@"^(0|-?\d{0,16}(\.\d{0,2})?)$"))]
        [Range(0, 9999999999.999999)]
        public decimal Total => Details == null ? 0 : Details.Sum(x => x.TotalPrice);
    }
}

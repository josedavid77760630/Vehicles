using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Vehicles.API.Data.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(40, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

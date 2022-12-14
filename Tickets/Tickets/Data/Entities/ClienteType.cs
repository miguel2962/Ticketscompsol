using System.ComponentModel.DataAnnotations;

namespace Tickets.Data.Entities
{
    public class ClienteType
    {
        public int Id { get; set; }

        [Display(Name ="Tipo de Cliente")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        public string Descripcion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class Treatment
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Código")]
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100)]
        [Display(Name = "Nombre del tratamiento")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255)]
        [Display(Name = "Descripción")]
        public string Description { get; set; } = string.Empty;



        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Currency)]
        [Range(5,300)]
        [RegularExpression(@"^\$?\d+(\.(\d{1,2}))?$", ErrorMessage = "Debe ser un precio válido")]
        [Display(Name = "Precio")]
        public double Price { get; set; }


        [DataType(DataType.Duration)]
        [Display(Name = "Tiempo de duración")]
        public double? Duration{ get; set; }


    }
}

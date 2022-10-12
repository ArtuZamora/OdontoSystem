using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class Inventory
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Código")]
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Marca")]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Nombre del material")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Únicamente valores numéricos reales.")]
        [Display(Name = "Existencia")]
        public int Stock { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de registro")]
        public DateTime CreateDate { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de riesgo")]
        public DateTime RiskDate{ get; set; }




    }
}

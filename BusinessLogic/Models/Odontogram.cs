using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BusinessLogic.Models
{
    public   class Odontogram
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]
        public long Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Diente")]
        public int ToothNumber { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Fila")]
        public int Row { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Lado")]
        public string Side { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [MaxLength(255)]
        [Display(Name = "Descripción")]
        public string Description { get; set; } = string.Empty;
        [ForeignKey("PatientId")]
        [Display(Name = "Paciente")]
        public virtual Patient Patient { get; set; }
    }
}

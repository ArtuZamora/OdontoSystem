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

        [Key]
        [Display(Name = "Paciente")]
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Diente")]
        public int ToothNumber { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [MaxLength(255)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}

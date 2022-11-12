using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class PatientHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Código")]
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de cita")]
        public DateTime AppointmentDate { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string DoctorId { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        [Display(Name = "Descripción")]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("PatientId")]
         [Display(Name = "Paciente")]
        public virtual Patient Patient{ get; set; } 


        /* [ForeignKey("DoctorId")]
         [Display(Name = "Doctor")]
        public virtual Doctor Doctor { get; set; }  */

    }
}
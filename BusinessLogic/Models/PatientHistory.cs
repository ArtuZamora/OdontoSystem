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
        [Key]
        [Display(Name = "Paciente")]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de cita")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Doctor")]
        public int DoctorID { get; set; }


        //agregar la relacion de doctor
    }
}
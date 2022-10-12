using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BusinessLogic.Models
{
    public class Agenda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]
   
        public long Id { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }



        [Required(ErrorMessage = "El campo es requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh:mm}")]
        [Display(Name = "Hora")]
        public TimeOnly Hour { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Estado")]

        public string? State { get; set; }


        [ForeignKey("TreatmentId")]
        [Display(Name = "Tratamiento")]
        public virtual Treatment Treatment { get; set; } 



        [ForeignKey("PatientId")]
        [Display(Name = "Paciente")]
        public virtual Patient Patient { get; set; }

        /* [ForeignKey("DoctorId")]
         [Display(Name = "Doctor")]
        public virtual Doctor Doctor { get; set; }  */






    }
}

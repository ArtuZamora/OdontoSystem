using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class AppointmentHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Código")]
        public long Id { get; set; }

        [ForeignKey("TreatmentId")]
        [Display(Name = "Tratamiento")]
        public virtual Treatment Treatment { get; set; }


        [ForeignKey("AgendaId")]
        [Display(Name = "Agenda id")]
        public virtual Agenda Agenda { get; set; }

        [ForeignKey("PatientId")]
        [Display(Name = "Paciente")]
        public virtual Patient Patient { get; set; }


    }
}

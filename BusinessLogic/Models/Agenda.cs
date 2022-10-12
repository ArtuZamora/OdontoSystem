using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

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


        [Display(Name = "Tratamiento")]
        public int TreatmentID { get; set; }

        public Treatment Treatment { get; set; }


        [Display(Name = "Doctor")]
        public int DocID { get; set; }
        //bovioo dudas
        public IdentityUser? IdentityUser { get; set; }

        [Display(Name = "Paciente")]
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }    






    }
}

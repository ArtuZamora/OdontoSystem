using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
   public class Schedule
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Código")]
        public long Id { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name = "Fecha")]
        public DateTime SelectDate { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{hh:mm}")]
        [Display(Name = "Hora inicio")]
        public  DateTime StartTime { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh:mm}")]
        [Display(Name = "Hora Fin")]
        public DateTime EndTime { get; set; }


        /* [ForeignKey("DoctorId")]
         [Display(Name = "Doctor")]
        public virtual Doctor Doctor { get; set; }  */





    }
}

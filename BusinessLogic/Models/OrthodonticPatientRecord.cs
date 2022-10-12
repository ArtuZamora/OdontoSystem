using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class OrthodonticPatientRecord:PatientRecord
    {
        [Key]
        [Display(Name = "Paciente")]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Duración del tratamiento")]
        public string TxDuration { get; set; }

     
        [MaxLength(255)]
        [Display(Name = "Tratamiento previo")]
        public string? TxPrev { get; set; }

        [MaxLength(255)]
        [Display(Name = "Líneas medias")]
        public string? Midlines { get; set; }

        [MaxLength(255)]
        [Display(Name = "Diastemas")]
        public string? Diastemas { get; set; }

      
        [Display(Name = "Tipo de mordida")]
        public int BiteType { get; set; }

        [Display(Name = "Tipo de apiñamiento")]
        public bool Crowding { get; set; }

        [MaxLength(255)]
        [Display(Name = "Hábitos")]
        public string? Habits { get; set; }

    }
}

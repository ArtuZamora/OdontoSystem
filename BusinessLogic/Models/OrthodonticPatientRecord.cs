using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class OrthodonticPatientRecord : PatientRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]

        public long Id { get; set; }



        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Duración del tratamiento")]
        public string TxDuration { get; set; } = string.Empty;


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
        public string? Crowding { get; set; }

        [MaxLength(255)]
        [Display(Name = "Hábitos")]
        public string? Habits { get; set; }


        [ForeignKey("PatientId")]
        [Display(Name = "Paciente")]

        public virtual Patient Patient { get; set; }

        [Display(Name = "Perfil")]
        public string? Profile { get; set; }

    }
}

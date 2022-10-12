using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class PatientRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Código")]
        public long Id { get; set; }



        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(255)]
        [Display(Name = "Motivo de consulta")]
        public string RFC { get; set; } = string.Empty;



        [MaxLength(255)]
        [Display(Name = "Hospitalizaciones")]
        public string? Hospitalizations { get; set; }

        [MaxLength(255)]
        [Display(Name = "Tratamiento médico actual")]
        public string? CurrentMedicTx { get; set; }

        [MaxLength(255)]
        [Display(Name = "Problemas de coagulación")]
        public string? CoagulationP { get; set; }

        [MaxLength(255)]
        [Display(Name = "Problemas respiratorios")]
        public string? RespiratoryP { get; set; }

        [MaxLength(255)]
        [Display(Name = "Traumatismos")]
        public string? Trauma { get; set; }

        [MaxLength(255)]
        [Display(Name = "Alergias")]
        public string? Allergies { get; set; }

        [MaxLength(255)]
        [Display(Name = "Enfermedades sistémicas")]
        public string? SystemicDiseases { get; set; }


        [MaxLength(255)]
        [Display(Name = "Antecedentes odontológicos")]
        public string? DentalHistory { get; set; }

     
        [Display(Name = "Bebidas alcohólicas")]
        public bool AlcoholicDrinks { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(255)]
        [Display(Name = "Diagnóstico")]
        public string Diagnostic { get; set; } = string.Empty;


        [MaxLength(255)]
        [Display(Name = "Extracciones")]

        public string? Extractions { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(255)]
        [Display(Name = "Cordales")]
        public string WisdomTeeht { get; set; } = string.Empty;

        [MaxLength(255)]
        [Display(Name = "Prostodoncia")]
        public string? Prosthodontics { get; set; }

        [MaxLength(255)]
        [Display(Name = "Rx panorámica")]
        public string? PanoramicRx { get; set; }

        [MaxLength(255)]
        [Display(Name = "Rx cefalométrica")]
        public string? CephalometricRx{ get; set; }

        [MaxLength(255)]
        [Display(Name = "Rx periapical")]
        public string? PeriapicalRx { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(255)]
        [Display(Name = "Tipo de limpieza")]
        public string TypeDentalClean { get; set; }=string.Empty;


        /* [ForeignKey("DoctorId")]
         [Display(Name = "Doctor")]
        public virtual Doctor Doctor { get; set; }  */


    }
}

using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using OdontoSystem.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace OdontoSystem.Controllers
{
    public class PatientRecordViewModel
    {
        [Key]
        [Required(ErrorMessage = "El campo es requerido")]
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
        [Display(Name = "Fuma?")]
        public bool Smokes { get; set; }
        [Display(Name = "Bebidas alcohólicas?")]
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
        public string? CephalometricRx { get; set; }
        [MaxLength(255)]
        [Display(Name = "Rx periapical")]
        public string? PeriapicalRx { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(255)]
        [Display(Name = "Tipo de limpieza")]
        public string TypeDentalClean { get; set; } = string.Empty;
        // Ortodoncia
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
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Paciente")]
        public long PatientId { get; set; }
        [Display(Name = "Perfil")]
        public string? Profile { get; set; }
    }
    public class AttendAgendaController : Controller
    {
        protected readonly IOrthodonticPatientRecordRepository _record;
        protected readonly IPatientRepository _patient;
        protected readonly UserManager<OdontoSystemUser> _userManager;
        protected readonly IPatientHistoryRepository _history;
        protected readonly IOdontogramRepository _odontogram;
        public AttendAgendaController(IOrthodonticPatientRecordRepository record,
                                        IPatientRepository patient, 
                                        UserManager<OdontoSystemUser> userManager,
                                        IPatientHistoryRepository history,
                                        IOdontogramRepository odontogram)
        {
            _record = record;
            _patient = patient;
            _userManager = userManager;
            _history = history;
            _odontogram = odontogram;
        }
        // GET: AgendaController
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}

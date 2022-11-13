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
        public long? AgendaId { get; set; }
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
        protected readonly ITreatmentRepository _treatment;
        public AttendAgendaController(IOrthodonticPatientRecordRepository record,
                                        IPatientRepository patient,
                                        UserManager<OdontoSystemUser> userManager,
                                        IPatientHistoryRepository history,
                                        IOdontogramRepository odontogram,
                                        ITreatmentRepository treatment)
        {
            _record = record;
            _patient = patient;
            _userManager = userManager;
            _history = history;
            _odontogram = odontogram;
            _treatment = treatment;
        }
        // GET: AgendaController
        public async Task<IActionResult> Create(long id, long? agendaId)
        {
            var paciente = await _patient.DetailsAsync(id);
            if (paciente == null)
                return NotFound();
            ViewData["Tratamientos"] = await _treatment.GetAllAsync();
            ViewData["Doctores"] = (await _userManager.Users.ToListAsync()).Where(u => u.Speciality == "Doctor");
            ViewData["Historia"] = (await _history.GetAllAsync()).Where(u => u.Patient.Id == id);
            ViewData["Odontograma"] = (await _odontogram.GetAllAsync()).Where(u => u.Patient.Id == id);
            ViewData["MyData"] = await _userManager.FindByIdAsync(User.Claims.First().Value);
            ViewData["Paciente"] = paciente;
            var record = (await _record.GetAllAsync()).Where(r => r.Patient.Id == id).FirstOrDefault();
            if (record != default)
            {
                var @object = BuildObject(record);
                return View(@object);
            }
            else if (agendaId != null)
            {
                var @object = BuildObject(id, (long)agendaId);
                return View(@object);
            }
            else
            {
                var @object = BuildObject(id);
                return View(@object);
            }
        }
        [HttpGet]
        public async Task<IEnumerable<Odontogram>> GetOdontograms(long id)
        {
            return (await _odontogram.GetAllAsync()).Where(u => u.Patient.Id == id);
        }
        [HttpDelete]
        public async Task<bool> DeleteOdontogram(long id)
        {
            return await _odontogram.DeleteAsync(id);
        }
        [HttpPost]
        public async Task<bool> PostOdontogram(Odontogram odontogram)
        {
            var flag = true;
            try
            {
                var patient = await _patient.DetailsAsync(odontogram.Patient.Id);
                if (patient != null)
                {
                    odontogram.Patient = patient;
                    if (odontogram.Id == 0)
                    {
                        //create
                        flag = await _odontogram.CreateAsync(odontogram);
                    }
                    else
                    {
                        //update
                        flag = await _odontogram.UpdateAsync(odontogram);
                    }
                }
                else
                    flag = false;
            }
            catch (Exception)
            {
                flag = false;
                throw;
            }
            return flag;
        }
        private PatientRecordViewModel BuildObject(OrthodonticPatientRecord record)
        {
            return new PatientRecordViewModel
            {

            };
        }
        private PatientRecordViewModel BuildObject(long patientId)
        {
            return new PatientRecordViewModel
            {
                PatientId = patientId
            };
        }
        private PatientRecordViewModel BuildObject(long patientId, long agendaId)
        {
            return new PatientRecordViewModel
            {
                PatientId = patientId,
                AgendaId = agendaId
            };
        }
    }
}

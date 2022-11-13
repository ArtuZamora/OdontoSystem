using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using OdontoSystem.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace OdontoSystem.Controllers
{
    public class PatientRecordViewModel
    {
        public long RecordId { get; set; }
        public long? AgendaId { get; set; }
        [MaxLength(255)]
        [Display(Name = "Motivo de consulta")]
        public string? RFC { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Hospitalizaciones")]
        public string? Hospitalizations { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Tratamiento médico actual")]
        public string? CurrentMedicTx { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Problemas de coagulación")]
        public string? CoagulationP { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Problemas respiratorios")]
        public string? RespiratoryP { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Traumatismos")]
        public string? Trauma { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Alergias")]
        public string? Allergies { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Enfermedades sistémicas")]
        public string? SystemicDiseases { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Antecedentes odontológicos")]
        public string? DentalHistory { get; set; } = string.Empty;
        [Display(Name = "Fuma?")]
        public bool Smokes { get; set; }
        [Display(Name = "Bebidas alcohólicas?")]
        public bool AlcoholicDrinks { get; set; }
        [MaxLength(255)]
        [Display(Name = "Diagnóstico")]
        public string? Diagnostic { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Extracciones")]
        public string? Extractions { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Cordales")]
        public string? WisdomTeeht { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Prostodoncia")]
        public string? Prosthodontics { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Rx panorámica")]
        public string? PanoramicRx { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Rx cefalométrica")]
        public string? CephalometricRx { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Rx periapical")]
        public string? PeriapicalRx { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Tipo de limpieza")]
        public string? TypeDentalClean { get; set; } = string.Empty;
        // Ortodoncia
        [Display(Name = "Duración del tratamiento")]
        public string? TxDuration { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Tratamiento previo")]
        public string? TxPrev { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Líneas medias")]
        public string? Midlines { get; set; } = string.Empty;
        [MaxLength(255)]
        [Display(Name = "Diastemas")]
        public string? Diastemas { get; set; } = string.Empty;

        [Display(Name = "Tipo de mordida")]
        public int BiteType { get; set; }

        [Display(Name = "Tipo de apiñamiento")]
        public string? Crowding { get; set; } = string.Empty;

        [MaxLength(255)]
        [Display(Name = "Hábitos")]
        public string? Habits { get; set; } = string.Empty;
        [Display(Name = "Paciente")]
        public long PatientId { get; set; }
        [Display(Name = "Perfil")]
        public string? Profile { get; set; } = string.Empty;
        public string? PatientType { get; set; } = string.Empty;
    }
    public class AttendAgendaController : Controller
    {
        protected readonly IOrthodonticPatientRecordRepository _record;
        protected readonly IPatientRepository _patient;
        protected readonly UserManager<OdontoSystemUser> _userManager;
        protected readonly IPatientHistoryRepository _history;
        protected readonly IOdontogramRepository _odontogram;
        protected readonly ITreatmentRepository _treatment;
        protected readonly IAgendaRepository _agenda;
        protected readonly IWebHostEnvironment _env;
        public AttendAgendaController(IOrthodonticPatientRecordRepository record,
                                        IPatientRepository patient,
                                        UserManager<OdontoSystemUser> userManager,
                                        IPatientHistoryRepository history,
                                        IOdontogramRepository odontogram,
                                        ITreatmentRepository treatment,
                                        IAgendaRepository agenda,
                                        IWebHostEnvironment env)
        {
            _record = record;
            _patient = patient;
            _userManager = userManager;
            _history = history;
            _odontogram = odontogram;
            _treatment = treatment;
            _agenda = agenda;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Usuarios"] = await _userManager.Users.ToListAsync();
            var dateNow = DateTime.Now.ToString("dd/MM/yyyy");
            return View((await _agenda.GetAllAsync()).Where(a => a.Date.ToString("dd/MM/yyyy") == dateNow));
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
                var @object = BuildObject(record, agendaId);
                @object.PatientType = paciente.TypeName;
                return View(@object);
            }
            else if (agendaId != null)
            {
                var @object = BuildObject(id, (long)agendaId);
                @object.PatientType = paciente.TypeName;
                return View(@object);
            }
            else
            {
                var @object = BuildObject(id);
                @object.PatientType = paciente.TypeName;
                return View(@object);
            }
        }
        [HttpPost]
        public async Task<bool> Post(string recordJSON, string historyJSON, IFormFile panoramicRx, IFormFile cephalometricRx, IFormFile periapicalRx)
        {
            var record = JsonConvert.DeserializeObject<PatientRecordViewModel>(recordJSON);
            var history = JsonConvert.DeserializeObject<PatientHistory>(historyJSON);
            var flag = true;
            try
            {
                var patient = await _patient.DetailsAsync(record.PatientId);
                OrthodonticPatientRecord recordOr = null;
                if (record.RecordId != 0)
                    recordOr = await _record.DetailsAsync(record.RecordId);
                if (patient != null)
                {
                    var recordObj = new OrthodonticPatientRecord()
                    {
                        Id = record.RecordId,
                        RFC = record.RFC == null ? "" : record.RFC,
                        Hospitalizations = record.Hospitalizations == null ? "" : record.Hospitalizations,
                        CurrentMedicTx = record.CurrentMedicTx == null ? "" : record.CurrentMedicTx,
                        CoagulationP = record.CoagulationP == null ? "" : record.CoagulationP,
                        RespiratoryP = record.RespiratoryP == null ? "" : record.RespiratoryP,
                        Trauma = record.Trauma == null ? "" : record.Trauma,
                        Allergies = record.Allergies == null ? "" : record.Allergies,
                        SystemicDiseases = record.SystemicDiseases == null ? "" : record.SystemicDiseases,
                        DentalHistory = record.DentalHistory == null ? "" : record.DentalHistory,
                        Smokes = record.Smokes,
                        AlcoholicDrinks = record.AlcoholicDrinks,
                        Diagnostic = record.Diagnostic == null ? "" : record.Diagnostic,
                        Extractions = record.Extractions == null ? "" : record.Extractions,
                        WisdomTeeht = record.WisdomTeeht == null ? "" : record.WisdomTeeht,
                        Prosthodontics = record.Prosthodontics == null ? "" : record.Prosthodontics,
                        PanoramicRx = panoramicRx == null ? recordOr != null ? recordOr.PanoramicRx : "" : panoramicRx.FileName,
                        CephalometricRx = cephalometricRx == null ? recordOr != null ? recordOr.CephalometricRx : "" : cephalometricRx.FileName,
                        PeriapicalRx = periapicalRx == null ? recordOr != null ? recordOr.PeriapicalRx : "" : periapicalRx.FileName,
                        TypeDentalClean = record.TypeDentalClean == null ? "" : record.TypeDentalClean,
                        TxDuration = record.TxDuration == null ? "" : record.TxDuration,
                        TxPrev = record.TxPrev == null ? "" : record.TxPrev,
                        Midlines = record.Midlines == null ? "" : record.Midlines,
                        Diastemas = record.Diastemas == null ? "" : record.Diastemas,
                        Crowding = record.Crowding == null ? "" : record.Crowding,
                        Habits = record.Habits == null ? "" : record.Habits,
                        Patient = patient,
                        Profile = record.Profile == null ? "" : record.Profile,
                        BiteType = record.BiteType,
                    };
                    ((OrthodonticPatientRecord)recordObj).Id = record.RecordId;
                    ((PatientRecord)recordObj).Id = record.RecordId;
                    if (recordObj.Id == 0)
                    {
                        //create
                        flag &= await _record.CreateAsync(recordObj);
                    }
                    else
                    {
                        //update
                        flag &= await _record.UpdateAsync(recordObj);
                    }
                    patient.TypeName = record.PatientType;
                    if (panoramicRx != null)
                        flag &= await SaveFileAsync(panoramicRx);
                    if (cephalometricRx != null)
                        flag &= await SaveFileAsync(cephalometricRx);
                    if (periapicalRx != null)
                        flag &= await SaveFileAsync(periapicalRx);
                    flag &= await _patient.UpdateAsync(patient);
                    if (history.Description != null && history.Description.Trim() != "")
                    {
                        history.Patient = patient;
                        flag &= await _history.CreateAsync(history);
                    }
                    if (record.AgendaId != null)
                    {
                        var agenda = await _agenda.DetailsAsync((long)record.AgendaId);
                        if (agenda != null)
                        {
                            var treatment = await _treatment.DetailsAsync(Convert.ToInt64(record.CurrentMedicTx));
                            agenda.State = "Finalizada";
                            if (treatment != null)
                                agenda.Treatment = treatment;
                            flag &= await _agenda.UpdateAsync(agenda);
                        }
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
        public async Task<bool> SaveFileAsync(IFormFile file)
        {
            if (file != null)
            {
                string directory = Path.Combine(_env.ContentRootPath, "wwwroot/files");
                Directory.CreateDirectory(directory);
                string filePath = Path.Combine(directory, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                }
                return true;
            }
            return false;

        }
        private PatientRecordViewModel BuildObject(OrthodonticPatientRecord record, long? agendaId)
        {
            return new PatientRecordViewModel
            {
                RecordId = ((BusinessLogic.Models.PatientRecord)record).Id,
                AgendaId = agendaId,
                RFC = record.RFC,
                Hospitalizations = record.Hospitalizations,
                CurrentMedicTx = record.CurrentMedicTx,
                CoagulationP = record.CoagulationP,
                RespiratoryP = record.RespiratoryP,
                Trauma = record.Trauma,
                Allergies = record.Allergies,
                SystemicDiseases = record.SystemicDiseases,
                DentalHistory = record.DentalHistory,
                Smokes = record.Smokes,
                AlcoholicDrinks = record.AlcoholicDrinks,
                Diagnostic = record.Diagnostic,
                Extractions = record.Extractions,
                WisdomTeeht = record.WisdomTeeht,
                Prosthodontics = record.Prosthodontics,
                PanoramicRx = record.PanoramicRx,
                CephalometricRx = record.CephalometricRx,
                PeriapicalRx = record.PeriapicalRx,
                TypeDentalClean = record.TypeDentalClean,
                TxDuration = record.TxDuration,
                TxPrev = record.TxPrev,
                Midlines = record.Midlines,
                Diastemas = record.Diastemas,
                Crowding = record.Crowding,
                Habits = record.Habits,
                PatientId = record.Patient.Id,
                Profile = record.Profile,
                BiteType = record.BiteType
            };
        }
        private PatientRecordViewModel BuildObject(long patientId)
        {
            return new PatientRecordViewModel
            {
                RecordId = 0,
                PatientId = patientId
            };
        }
        private PatientRecordViewModel BuildObject(long patientId, long agendaId)
        {
            return new PatientRecordViewModel
            {
                RecordId = 0,
                PatientId = patientId,
                AgendaId = agendaId
            };
        }
    }
}

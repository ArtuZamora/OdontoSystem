using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OdontoSystem.Controllers
{
    public class AgendaViewModel
    {
        public long? Id { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha y hora")]
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime Date { get; set; }
        [Display(Name = "Estado")]
        public string? State { get; set; }
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es requerido")]
        public long PatientId { get; set; }
    }
    public class AgendaController : Controller
    {
        protected readonly IAgendaRepository _agenda;
        protected readonly IPatientRepository _paciente;
        public AgendaController(IAgendaRepository agenda,
                                IPatientRepository paciente)
        {
            _agenda = agenda;
            _paciente = paciente;
        }
        // GET: AgendaController
        public async Task<IActionResult> Index()
        {
            return View(await _agenda.GetAllAsync());
        }

        // GET: AgendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgendaController/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Pacientes"] = await _paciente.GetAllAsync();
            return View();
        }

        // POST: AgendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgendaViewModel agenda)
        {
            ViewData["Pacientes"] = await _paciente.GetAllAsync();
            try
            {
                if (ModelState.IsValid)
                {
                    await _agenda.CreateAsync(new Agenda
                    {
                        Date = agenda.Date,
                        Hour = agenda.Date,
                        State = "Agendada",
                        Patient = new Patient
                        {
                            Id = agenda.PatientId
                        },
                        Treatment = null
                    });
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AgendaController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            ViewData["Pacientes"] = await _paciente.GetAllAsync();
            var agenda = await _agenda.DetailsAsync(id);
            if (agenda != null)
            {
                var agendaObj = new AgendaViewModel
                {
                    Id = agenda.Id,
                    Date = agenda.Hour,
                    PatientId = agenda.Patient.Id,
                    State = agenda.State
                };
                return View(agendaObj);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: AgendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AgendaViewModel agenda)
        {
            ViewData["Pacientes"] = await _paciente.GetAllAsync();
            try
            {
                if (ModelState.IsValid)
                {
                    await _agenda.UpdateAsync(new Agenda
                    {
                        Id = (long)agenda.Id,
                        Date = agenda.Date,
                        Hour = agenda.Date,
                        State = "Agendada",
                        Patient = new Patient
                        {
                            Id = agenda.PatientId
                        },
                        Treatment = null
                    });
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
        // POST: AgendaController/Create
        public async Task<IActionResult> Cancelar(long id)
        {
            var agenda = await _agenda.DetailsAsync(id);
            if (agenda != null)
            {
                try
                {
                    await _agenda.UpdateAsync(new Agenda
                    {
                        Id = agenda.Id,
                        Date = agenda.Date,
                        Hour = agenda.Date,
                        State = "Cancelada",
                        Patient = agenda.Patient,
                        Treatment = agenda.Treatment
                    });
                }
                catch
                {
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

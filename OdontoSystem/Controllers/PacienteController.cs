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
    public class PacienteViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50)]
        [Display(Name = "Primer nombre")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50)]
        [Display(Name = "Segundo nombre")]
        public string MiddleName { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{4}(['\'-]?|['\'s])[0-9]{4}$", ErrorMessage = "Digita un número de telefono válido")]
        [Display(Name = "Teléfono")]
        public string? CellPhone { get; set; }
    }
    public class PacienteController : Controller
    {
        protected readonly IPatientRepository _paciente;
        protected readonly UserManager<OdontoSystemUser> _userManager;
        public PacienteController(IPatientRepository paciente, UserManager<OdontoSystemUser> userManager)
        {
            _paciente = paciente;
            _userManager = userManager;
        }
        // GET: AgendaController
        public async Task<IActionResult> Index()
        {
            ViewData["Usuarios"] = await _userManager.Users.ToListAsync();
            return View(await _paciente.GetAllAsync());
        }
        public async Task<IEnumerable<Patient>> GetDDL()
        {
            return await _paciente.GetAllAsync();
        }

        // GET: AgendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> CreateTemporal(PacienteViewModel paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _paciente.CreateAsync(new Patient
                    {
                        FirstName = paciente.FirstName,
                        MiddleName = paciente.MiddleName,
                        LastName = paciente.LastName,
                        Address = "",
                        Age = 0,
                        BirthDate = DateTime.Now,
                        CellPhone = paciente.CellPhone,
                        CreateDate = DateTime.Now,
                        email = "",
                        TypeName = ""
                    });
                    return "Se ha creado el paciente exitosamente";
                }
                else
                    return "Verifique que todos los campos estén rellenados correctamente";
            }
            catch
            {
                return "Han existido errores procesando su solicitud. Porfavor intente más tarde";
            }
        }

        // GET: AgendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

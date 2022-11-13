using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OdontoSystem.Controllers
{
    public class TreatmentViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100)]
        [Display(Name = "Nombre del tratamiento")]
        public string Name { get; set; } = string.Empty;
        [DataType(DataType.MultilineText)]
        [MaxLength(255)]
        [Display(Name = "Descripción")]
        public string Description { get; set; } = string.Empty;
        [DataType(DataType.Currency)]
        [Range(5, 300)]
        [RegularExpression(@"^\$?\d+(\.(\d{1,2}))?$", ErrorMessage = "Debe ser un precio válido")]
        [Display(Name = "Precio")]
        public double Price { get; set; }
        [DataType(DataType.Duration)]
        [Display(Name = "Tiempo de duración")]
        public double? Duration { get; set; }

    }
    public class TreatmentController : Controller
    {
        protected readonly ITreatmentRepository _treatment;
        public TreatmentController(ITreatmentRepository treatment)
        {
            _treatment = treatment;

        }
        // GET: TreatmentController
        public async Task<IActionResult> Index()
        {
            return View(await _treatment.GetAllAsync());
        }
        // GET: TreatmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: TreatmentController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        // POST: AgendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TreatmentViewModel treatment)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    await _treatment.CreateAsync(new Treatment
                    {
                        Name = treatment.Name,
                        Description = treatment.Description,
                        Price = treatment.Price,
                        Duration = treatment.Duration
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
        // GET: TreatmentController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var treatment = await _treatment.DetailsAsync(id);
            if (treatment != null)
            {
                var treatmentObj = new TreatmentViewModel
                {
                    Id = treatment.Id,
                    Name = treatment.Name,
                    Description = treatment.Description,
                    Price = treatment.Price,
                    Duration = treatment.Duration
                };
                return View(treatmentObj);
            }
            return RedirectToAction(nameof(Index));
        }
        // POST: TreatmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TreatmentViewModel treatment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _treatment.UpdateAsync(new Treatment
                    {
                        Id = (long)treatment.Id,
                        Name = treatment.Name,
                        Description = treatment.Description,
                        Price = treatment.Price,
                        Duration = treatment.Duration
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
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var resultFlag = false;
            var result = await _treatment.DeleteAsync(id);
            if (result)
            {
                resultFlag = true;
            }
            TempData["ResultFlag"] = resultFlag;
            return RedirectToAction("Index");
        }
    }
}

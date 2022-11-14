using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace OdontoSystem.Controllers
{
    public class InventoryController : Controller

    {
        protected readonly IInventoryRepository _inventory;
        public InventoryController(IInventoryRepository inventory)
        {
            _inventory = inventory;


        }
        // GET: InventoryController
        public async Task<IActionResult> Index()
        {

            return View(await _inventory.GetAllAsync());
        }

        // GET: InventoryController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("acá");
                return View("NotFound");
            }
            var cita = await _inventory.DetailsAsync((long)id);
            return View(cita);
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
              return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventory inv)
        {
            try
            {
                await _inventory.CreateAsync(inv);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(inv);
            }
        }

        // GET: InventoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _inventory.DetailsAsync(id);
            return View(producto);
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Inventory inv)
        {
            try
            {
                await _inventory.UpdateAsync(inv);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("NotFound");
            }
        }

        // GET: InventoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _inventory.DetailsAsync(id);
            return View(producto);
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Inventory inv)
        {
            try
            {
                Console.WriteLine("entro en el post");
                await _inventory.DeleteAsync((long)inv.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("NotFound");
            }
        }
    }
}

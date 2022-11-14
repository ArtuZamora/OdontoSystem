using BusinessLogic.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OdontoSystem.Models;
using OdontoSystem.Areas.Identity.Data;
using System.Diagnostics;

namespace OdontoSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<OdontoSystemUser> _user;
        public UserController(UserManager<OdontoSystemUser> user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OdontoSystemUser user)
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OdontoSystemUser user)
        {
            return View();
        }
        [HttpDelete]
        public async Task<bool> Delete(string id)
        {
            return false;
        }
    }
}
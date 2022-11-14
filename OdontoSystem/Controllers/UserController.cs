using BusinessLogic.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OdontoSystem.Models;
using OdontoSystem.Areas.Identity.Data;
using System.Diagnostics;
using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OdontoSystem.Controllers
{
    public class EditUserViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Id { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido")]
        public string Email { get; set; }
        [Display(Name = "Nombre(s)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Name { get; set; }
        [Display(Name = "Apellido(s)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string LastName { get; set; }
        [Display(Name = "DUI")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression("^[0-9]{8}-?[0-9]{1}$", ErrorMessage = "Debe ingresar un DUI válido (Ej. XXXXXXXX-X o XXXXXXXXX)")]
        public string DUI { get; set; }
        [Display(Name = "Contacto")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Telephone { get; set; }
        [Display(Name = "Dirección")]
        public string? Address { get; set; }
        [Display(Name = "Tipo de usuario")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Speciality { get; set; }
    }
    public class UserViewModel
    {
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido")]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "La contraseña debe contener: \n- Al menos 8 caracteres\n - 1 Mayúscula\n - 1 minúscula\n - 1 número\n - 1 caracter especial")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Repita contraseña")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string RepeatPassword { get; set; }
        [Display(Name = "Nombre(s)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Name { get; set; }
        [Display(Name = "Apellido(s)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string LastName { get; set; }
        [Display(Name = "DUI")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression("^[0-9]{8}-?[0-9]{1}$", ErrorMessage = "Debe ingresar un DUI válido (Ej. XXXXXXXX-X o XXXXXXXXX)")]
        public string DUI { get; set; }
        [Display(Name = "Contacto")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Telephone { get; set; }
        [Display(Name = "Dirección")]
        public string? Address { get; set; }
        [Display(Name = "Tipo de usuario")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Speciality { get; set; }
    }
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<OdontoSystemUser> _user;
        public UserController(UserManager<OdontoSystemUser> user)
        {
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _user.Users.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userToCreate = new OdontoSystemUser
                {
                    Email = user.Email,
                    EmailConfirmed = true,
                    UserName = user.Email,
                    Name = user.Name,
                    LastName = user.LastName,
                    Speciality = user.Speciality,
                    Address = user.Address,
                    Telephone = user.Telephone,
                    DUI = user.DUI,
                    PhoneNumber = user.Telephone
                };
                var res = await _user.CreateAsync(userToCreate, user.Password);
                if (res.Succeeded)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            return View();
        }
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _user.FindByIdAsync(id);
            return View(new EditUserViewModel
            {
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                Speciality = user.Speciality,
                Address = user.Address,
                Telephone = user.Telephone,
                DUI = user.DUI
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userToUpdate = await _user.FindByIdAsync(user.Id);
                if (userToUpdate != null)
                {
                    userToUpdate.Email = user.Email;
                    userToUpdate.NormalizedEmail = user.Email.ToUpper();
                    userToUpdate.UserName = user.Email;
                    userToUpdate.NormalizedUserName = user.Email.ToUpper();
                    userToUpdate.Name = user.Name;
                    userToUpdate.LastName = user.LastName;
                    userToUpdate.Speciality = user.Speciality;
                    userToUpdate.Address = user.Address;
                    userToUpdate.Telephone = user.Telephone;
                    userToUpdate.DUI = user.DUI;
                    userToUpdate.PhoneNumber = user.Telephone;

                    var res = await _user.UpdateAsync(userToUpdate);
                    if (res.Succeeded)
                        return RedirectToAction("Index");
                    else
                        return View();
                }
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var userToDelete = await _user.FindByIdAsync(id);
            var res =await _user.DeleteAsync(userToDelete);
            return RedirectToAction("Index");
        }
    }
}